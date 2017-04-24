using Microsoft.Bot.Builder.FormFlow;
using System;

namespace BotApplication1.Forms
{
    [Serializable]
    public class SimpleFeedbackCollection
    {
        public static IForm<SimpleFeedbackCollection> MakeForm()
        {
            FormBuilder<SimpleFeedbackCollection> _FeedbackCollection = new FormBuilder<SimpleFeedbackCollection>();
            return _FeedbackCollection
                .Message(response.askfornextsteps())
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

        [Prompt("I only want a quick response. Once you hit 'ENTER' I'll send your comment away.{||}")] // If you want to send more feedback after this quick question, just tell me.
        [Describe("If you want to send more feedback, just say so.")]
        public string Comment;

        [Prompt("If you want us to tell you how we used your feedback, please tell me your email. If you don't, just say so. {||}")]
        [Describe("We will publish our priorities on my facebook page as well")]
        public string email;


    }
}