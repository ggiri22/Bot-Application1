using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApplication1.Forms
{
    [Serializable]
    public class NormalFeedbackCollection
    {
        public static IForm<NormalFeedbackCollection> MakeForm()
        {
            FormBuilder<NormalFeedbackCollection> _FeedbackCollection = new FormBuilder<NormalFeedbackCollection>();
            return _FeedbackCollection
                .Message(response.askforgeneralfeedback())
                .Field(nameof(Comment)) //, active: ValidatePhoneNumber) - not required, but will be nice later
                .Field(nameof(email)) //, active: ValiateInvoiceumber)
                .AddRemainingFields()
                //save the user phone number to the bot brain
                .OnCompletion(async (context, feedbackform) =>
                {
                    string lm = null;
                    lm = feedbackform.Comment + "/n/n Returnmail: " + feedbackform.email;
                    context.PrivateConversationData.SetValue<string>("LastMessage", lm );   //implement send mail here
                })
                .Build();
        }

        [Prompt("I do look forward to your feedback. Go ahead")] // {||}
        [Describe("If you want to send more feedback, just say so.")]
        public string Comment;

        [Prompt(":-) If you want us to tell you how we used your feedback, please tell me your email. If you don't, just say so.")] // {||}
        [Describe("We will publish our priorities on my facebook page as well")]
        public string email;
        
    }
}