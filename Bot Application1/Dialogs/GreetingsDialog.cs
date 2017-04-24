using BestMatchDialog;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;
using System;
using Microsoft.Bot.Builder.Luis;
using System.Collections.Generic;
using System.Threading;

namespace BotApplication1.Dialogs
{
    [LuisModel("95bf7f1b-ec5d-48bc-bcd9-a6f7aab4886d", "9aa44ab5065546aeba065088b15b23d1")]

    [Serializable]
    public class LuisGreetingsDialog : LuisDialog<bool>
    {
        public const string Intent_Greet = "Hi";
        public const string Intent_Farewell = "Bye";

        [LuisIntent(Intent_Greet)]

        public async Task Greet(IDialogContext context, string result)
        {

            await context.PostAsync("Hi! I'm your Telenor Internet Patronus. But you can just call me Tip. Nice to meet you.");
            result = "";
            context.Done(true);
        }

        [LuisIntent(Intent_Farewell)]

        public async Task Bye(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            await context.PostAsync("Bye. Hope to see you soon again. Have a good day!");
            context.Done(true);
        }

    }

    [Serializable]
    public class GreetingsDialog : BestMatchDialog<bool>
    {
        [BestMatch(new string[] { "Hi", "Hi There", "Hello there", "Hey", "Hello",
            "Hey there", "Greetings", "Good morning", "Good afternoon", "Good evening", "Good day" },
           threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: false)]
        public async Task WelcomeGreeting(IDialogContext context, string messageText)
        {
            await context.PostAsync("Hi there! I'm your Patronus. How can I help you?");
            context.Done(true);
        }

        [BestMatch(new string[] { "bye", "bye bye", "got to go",
            "see you later", "laters", "adios" })]
        public async Task FarewellGreeting(IDialogContext context, string messageText)
        {
            await context.PostAsync("Bye. Hope to see you soon again. Have a good day.");
            context.Done(true);
        }

        public override async Task NoMatchHandler(IDialogContext context, string messageText)
        {
            context.Done(false);
        }


    }

}