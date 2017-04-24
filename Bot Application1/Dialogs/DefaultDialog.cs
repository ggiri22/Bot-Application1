using System;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BotApplication1.Dialogs
{
    [LuisModel("95bf7f1b-ec5d-48bc-bcd9-a6f7aab4886d", "9aa44ab5065546aeba065088b15b23d1")]
    [Serializable]

    public class DefaultDialog : LuisDialog<object>
    {
        [LuisIntent("")]

        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, that goes beyond the scope of my knowledge.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Get address")]

        public async Task GetAddress(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("The address!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Get current weather")]

        public async Task GetWeather(IDialogContext context, LuisResult result)
        {
            string responseMessage = "";
            var entities = new List<EntityRecommendation>(result.Entities);

            await context.PostAsync(responseMessage);
            context.Wait(MessageReceived);
            //original code
            //context.Wait(MessageReceived);
        }


    }
}