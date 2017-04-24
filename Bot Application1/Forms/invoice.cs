using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApplication1.Forms
{
    [Serializable]
    public class Invoice
    {
        public static IForm<Invoice> MakeForm()
        {
            FormBuilder<Invoice> _Invoice = new FormBuilder<Invoice>();
            return _Invoice
                .Message("Ok, in need your phone number or the number of the invoice in question. Can you give it to me?")
                .Field(nameof(PhoneNumber)) //, active: ValidatePhoneNumber) - not required, but will be nice later
                .Field(nameof(InvoiceNumber)) //, active: ValiateInvoiceumber)
                .Field(nameof(Feedback))
                .AddRemainingFields()
                //save the user phone number to the bot brain
                .OnCompletion(async (context, invoice) =>
                {
                    context.PrivateConversationData.SetValue("PhoneNumber", invoice.PhoneNumber);
                })
                .Build();
        }

        [Prompt("What is your phone number? {||}")]
        [Describe("I need it to find your invoice, but an invoice number is OK as well")]
        public string PhoneNumber;

        [Prompt("If you have an invoice number, please enter that too. If not, just say so! {||}")]
        [Describe("Don't worry - I'll just get the latest invoice")]
        public string InvoiceNumber;

        [Prompt("Thanks, I have everything I need now. Anything else you want to tell me before we move on? {||}")]
        [Describe("I have your phone number and know what invoice you are talking about")]
        public string Feedback;

    }
}