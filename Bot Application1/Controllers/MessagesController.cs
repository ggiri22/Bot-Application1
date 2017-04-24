using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using BotApplication1.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using BotApplication1.Forms;

namespace BotApplication1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        // <summary>
        // POST: api/Messages
        // Receive a message from a user and reply to it
        // </summary>
        internal static IDialog<object> MakeDialogRoot()
        { 
            return Chain.From(() => new DefaultDialog());
        }

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            #region Set CurrentBaseURL
            // Get the base URL that this service is running at
            // This is used to show images
            // Create an instance of BotData to store data
            // Instantiate a StateClient to save BotData            
            // Use stateClient to get current userData
            // Update userData by setting CurrentBaseURL and Recipient
            // Save changes to userData
            string CurrentBaseURL = this.Url.Request.RequestUri.AbsoluteUri.Replace(@"api/messages", "");
            BotData objBotData = new BotData();
            StateClient stateClient = activity.GetStateClient();
            BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
            userData.SetProperty<string>("CurrentBaseURL", CurrentBaseURL);
            await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
            #endregion

            if (activity.Type == ActivityTypes.Message)
            {
                Activity isTypingReply = activity.CreateReply();
                isTypingReply.Type = ActivityTypes.Typing;
                var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                await connector.Conversations.ReplyToActivityAsync(isTypingReply);
                await Conversation.SendAsync(activity, MakeDialogRoot);
             }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
                string replyMessage = string.Empty;
                replyMessage += $"Ok, I deleted what I stored about you and our conversation.";
                return message.CreateReply(replyMessage);
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
                Activity isUserAdded = message.CreateReply();
                isUserAdded.Type = ActivityTypes.Message;
                isUserAdded.Text = response.introduction();
                var connector = new ConnectorClient(new Uri(message.ServiceUrl));
                connector.Conversations.ReplyToActivityAsync(isUserAdded);

                //return message.CreateReply(replyMessage);

            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}