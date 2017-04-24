//System
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
//Microsoft Bot
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
//Application specific
using BotApplication1.Forms;
using BotApplication1.Dialogs;

// to do - askPart1 users about what to implement next

namespace BotApplication1.Dialogs
{

    [LuisModel("95bf7f1b-ec5d-48bc-bcd9-a6f7aab4886d", "9aa44ab5065546aeba065088b15b23d1")]
    [Serializable]

    public class SubscriptionDialog : LuisDialog<object>
    {  

	
    }
}
