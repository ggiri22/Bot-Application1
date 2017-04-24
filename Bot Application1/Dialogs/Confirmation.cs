using BestMatchDialog;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;
using System;
using Microsoft.Bot.Builder.Luis;

namespace BotApplication1.Dialogs
{
    [LuisModel("95bf7f1b-ec5d-48bc-bcd9-a6f7aab4886d", "9aa44ab5065546aeba065088b15b23d1")]

    [Serializable]
    public class LuisConfirmation : LuisDialog<bool>
    {
        //TBC
        public const string Intent_Yes = "general.Yes";
        public const string Intent_No = "general.No";

        [LuisIntent(Intent_Yes)]

        //public async Task Yes(IDialogContext context, string result)
        public async Task Yes(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {

            await context.PostAsync("Hi! I think you said 'Yes'. This is not ready yet.");
        }

        [LuisIntent(Intent_No)]

        //public async Task No(IDialogContext context, string result)
        public async Task No(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            await context.PostAsync("Hi! I think you said 'No'. This is not ready yet.");
        }
        public void confirmation()
        {
            //TBC
        }
    }
}