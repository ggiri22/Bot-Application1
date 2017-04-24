using System;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace BotApplication1.Forms
{
    [Serializable]
    public class PhoneNoForm
    {
        [Prompt("What is it? {||}")]
        [Describe("phone number please")]
        public string PNumber;

        public static IForm<PhoneNoForm> MakeForm()
        {
            FormBuilder<PhoneNoForm> _PhoneNo = new FormBuilder<PhoneNoForm>();
            return _PhoneNo
                .Message("I seem to have lost your phone number")
                .Field(nameof(PNumber), active: CheckForPhoneNumber) //, active: CheckForPhoneNumber
                .AddRemainingFields()
                //save the user phone number to the bot brain
                .OnCompletion(async (context, phonenumber) =>
                {
                    context.PrivateConversationData.SetValue("PhoneNumber", phonenumber.PNumber);
                })
                .Build();
        }

        private static bool CheckForPhoneNumber(PhoneNoForm state)
        {
            if (string.IsNullOrWhiteSpace(state.PNumber))
                return (true);
            else
                return (false);
        }
    }
}