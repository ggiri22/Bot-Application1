 // 
    2 // Copyright (c) Microsoft. All rights reserved.
    3 // Licensed under the MIT license.
    4 // 
    5 // Microsoft Bot Framework: http://botframework.com
    6 // 
    7 // Bot Builder SDK Github:
    8 // https://github.com/Microsoft/BotBuilder
    9 // 
   10 // Copyright (c) Microsoft Corporation
   11 // All rights reserved.
   12 // 
   13 // MIT License:
   14 // Permission is hereby granted, free of charge, to any person obtaining
   15 // a copy of this software and associated documentation files (the
   16 // "Software"), to deal in the Software without restriction, including
   17 // without limitation the rights to use, copy, modify, merge, publish,
   18 // distribute, sublicense, and/or sell copies of the Software, and to
   19 // permit persons to whom the Software is furnished to do so, subject to
   20 // the following conditions:
   21 // 
   22 // The above copyright notice and this permission notice shall be
   23 // included in all copies or substantial portions of the Software.
   24 // 
   25 // THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
   26 // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
   27 // MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
   28 // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
   29 // LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
   30 // OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
   31 // WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
   32 //
   33 
   34 using System;
   35 using System.Collections.Generic;
   36 using System.Linq;
   37 using System.Reflection;
   38 using System.Runtime.Serialization;
   39 using System.Threading;
   40 using System.Threading.Tasks;
   41 
   42 using Microsoft.Bot.Connector;
   43 using Microsoft.Bot.Builder.Dialogs.Internals;
   44 using Microsoft.Bot.Builder.Internals.Fibers;
   45 using Microsoft.Bot.Builder.Internals.Scorables;
   46 using Microsoft.Bot.Builder.Luis;
   47 using Microsoft.Bot.Builder.Luis.Models;
   48 
   49 namespace Microsoft.Bot.Builder.Dialogs
   50 {
   54     [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
   55     [Serializable]
   56     public class LuisIntentAttribute : AttributeString
   57     {
   61         public readonly string IntentName;
   62 
   67         public LuisIntentAttribute(string intentName)
   68         {
   69             SetField.NotNull(out this.IntentName, nameof(intentName), intentName);
   70         }
   71 
   72         protected override string Text
   73         {
   74             get
   75             {
   76                 return this.IntentName;
   77             }
   78         }
   79     }
   80 
   87     public delegate Task IntentHandler(IDialogContext context, LuisResult luisResult);
   88 
   96     public delegate Task IntentActivityHandler(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult luisResult);
   97 
  101     [Serializable]
  102     public sealed class InvalidIntentHandlerException : InvalidOperationException
  103     {
  104         public readonly MethodInfo Method;
  105 
  106         public InvalidIntentHandlerException(string message, MethodInfo method)
  107             : base(message)
  108         {
  109             SetField.NotNull(out this.Method, nameof(method), method);
  110         }
  111 
  112         private InvalidIntentHandlerException(SerializationInfo info, StreamingContext context)
  113             : base(info, context)
  114         {
  115         }
  116     }
  117 
  121     public class LuisServiceResult
  122     {
  123         public LuisServiceResult(LuisResult result, IntentRecommendation intent)
  124         {
  125             this.Result = result;
  126             this.BestIntent = intent;
  127         }
  128 
  129         public LuisResult Result { get; }
  130 
  131         public IntentRecommendation BestIntent { get; }
  132     }
  133 
  137     [Serializable]
  138     public class LuisDialog<R> : IDialog<R>
  139     {
  140         protected readonly IReadOnlyList<ILuisService> services;
  141 
  143         [NonSerialized]
  144         protected Dictionary<string, IntentActivityHandler> handlerByIntent;
  145 
  146         public ILuisService[] MakeServicesFromAttributes()
  147         {
  148             var type = this.GetType();
  149             var luisModels = type.GetCustomAttributes<LuisModelAttribute>(inherit: true);
  150             return luisModels.Select(m => new LuisService(m)).Cast<ILuisService>().ToArray();
  151         }
  152 
  157         public LuisDialog(params ILuisService[] services)
  158         {
  159             if (services.Length == 0)
  160             {
  161                 services = MakeServicesFromAttributes();
  162             }
  163 
  164             SetField.NotNull(out this.services, nameof(services), services);
  165         }
  166 
  167         public virtual async Task StartAsync(IDialogContext context)
  168         {
  169             context.Wait(MessageReceived);
  170         }
  171 
  177         protected virtual IntentRecommendation BestIntentFrom(LuisResult result)
  178         {
  179             return result.Intents.MaxBy(i => i.Score ?? 0d);
  180         }
  181 
  188         protected virtual LuisServiceResult BestResultFrom(IEnumerable<LuisResult> results)
  189         {
  190             var winners = from result in results
  191                           let resultWinner = BestIntentFrom(result)
  192                           where resultWinner != null
  193                           select new LuisServiceResult(result, resultWinner);
  194             return winners.MaxBy(i => i.BestIntent.Score ?? 0d);
  195         }
  196 
  197         protected virtual async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
  198         {
  199             if (this.handlerByIntent == null)
  200             {
    201                 this.handlerByIntent = new Dictionary<string, IntentActivityHandler>(GetHandlersByIntent());
    202             }
  203 
  204             var message = await item;
  205             var messageText = await GetLuisQueryTextAsync(context, message);
  206             var tasks = this.services.Select(s => s.QueryAsync(messageText, context.CancellationToken)).ToArray();
  207             var winner = this.BestResultFrom(await Task.WhenAll(tasks));
  208 
  209             IntentActivityHandler handler = null;
  210             if (winner == null || !this.handlerByIntent.TryGetValue(winner.BestIntent.Intent, out handler))
  211             {
    212                 handler = this.handlerByIntent[string.Empty];
    213             }
  214 
  215             if (handler != null)
  216             {
    217                 await handler(context, item, winner?.Result);
    218             }
  219             else
  220             {
    221                 var text = $"No default intent handler found.";
    222                 throw new Exception(text);
    223             }
  224         }
  225 
  226         protected virtual Task<string> GetLuisQueryTextAsync(IDialogContext context, IMessageActivity message)
  227         {
  228             return Task.FromResult(message.Text);
  229         }
  230 
  231         protected virtual IDictionary<string, IntentActivityHandler> GetHandlersByIntent()
  232         {
  233             return LuisDialog.EnumerateHandlers(this).ToDictionary(kv => kv.Key, kv => kv.Value);
  234         }
  235     }
  236 
  237     internal static class LuisDialog
  238     {
  244         public static IEnumerable<KeyValuePair<string, IntentActivityHandler>> EnumerateHandlers(object dialog)
  245         {
  246             var type = dialog.GetType();
  247             var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
  248             foreach (var method in methods)
  249             {
  250                 var intents = method.GetCustomAttributes<LuisIntentAttribute>(inherit: true).ToArray();
  251                 IntentActivityHandler intentHandler = null;
  252 
  253                 try
  254                 {
  255                     intentHandler = (IntentActivityHandler)Delegate.CreateDelegate(typeof(IntentActivityHandler), dialog, method, throwOnBindFailure: false);
  256                 }
  257                 catch (ArgumentException)
  258                 {
  259                     // "Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type."
  260                     // https://github.com/Microsoft/BotBuilder/issues/634
  261                     // https://github.com/Microsoft/BotBuilder/issues/435
  262                 }
  263 
  264                 // fall back for compatibility
  265                 if (intentHandler == null)
  266                 {
  267                     try
  268                     {
  269                         var handler = (IntentHandler)Delegate.CreateDelegate(typeof(IntentHandler), dialog, method, throwOnBindFailure: false);
  270 
  271                         if (handler != null)
  272                         {
  273                             // thunk from new to old delegate type
  274                             intentHandler = (context, message, result) => handler(context, result);
  275                         }
  276                     }
  277                     catch (ArgumentException)
  278                     {
  279                         // "Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type."
  280                         // https://github.com/Microsoft/BotBuilder/issues/634
  281                         // https://github.com/Microsoft/BotBuilder/issues/435
  282                     }
  283                 }
  284 
  285                 if (intentHandler != null)
  286                 {
  287                     var intentNames = intents.Select(i => i.IntentName).DefaultIfEmpty(method.Name);
  288 
  289                     foreach (var intentName in intentNames)
  290                     {
  291                         var key = string.IsNullOrWhiteSpace(intentName) ? string.Empty : intentName;
  292                         yield return new KeyValuePair<string, IntentActivityHandler>(intentName, intentHandler);
  293                     }
  294                 }
  295                 else
  296                 {
  297                     if (intents.Length > 0)
  298                     {
  299                         throw new InvalidIntentHandlerException(string.Join(";", intents.Select(i => i.IntentName)), method);
  300                     }
  301                 }
  302             }
  303         }
  304     }
  305 }