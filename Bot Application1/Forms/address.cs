using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApplication1.Forms
{
    [Serializable]
    public class AddressChange
    {
        public static IForm<AddressChange> MakeForm()
        {
            FormBuilder<AddressChange> _AddressChange = new FormBuilder<AddressChange>();
            return _AddressChange
                .Message("Ok, in need your phone number or your social security number for identification. Can you give it to me?")
                .Field(nameof(UserNumber)) //, active: ValidateUserNumber) - not required, but will be nice later
                .AddRemainingFields()
                .Build();
        }

        [Prompt("Tell me any. I'll recognize which one it is.")]
        [Describe("I could use it to find your current address. Or give me your social security number.")]
        public string UserNumber;

    }

    [Serializable]
    public class NewAddress
    {
        public static IForm<NewAddress> MakeForm()
        {
            FormBuilder<NewAddress> _NewAddress = new FormBuilder<NewAddress>();
            return _NewAddress
                .Message("Please help me with your new address details.")
                .Field(nameof(StreetAddress))
                .Field(nameof(ZipCode))
                .Field(nameof(City))
                .Field(nameof(Additional))
                .AddRemainingFields()
                .Build();
        }

        [Prompt("Your street address? {||}")]
        [Describe("Address for the invoice to be sent to.")]
        public string StreetAddress;

        [Prompt("Zip Code? {||}")]
        [Describe("Address for the invoice to be sent to.")]
        public string ZipCode;

        [Prompt("City? {||}")]
        [Describe("Address for the invoice to be sent to.")]
        public string City;

        [Prompt("Anything else I need to know about your new address? {||}")]
        [Describe("Address for the invoice to be sent to.")]
        public string Additional;

    }

    [Serializable]
    public class FBNewAddress
    {
        public static IForm<FBNewAddress> MakeForm()
        {
            FormBuilder<FBNewAddress> _NewAddress = new FormBuilder<FBNewAddress>();
            return _NewAddress
                .Message("Ok, I need your new address details.")
                .Field(nameof(StreetAddress))
                .Field(nameof(ZipCode))
                .Field(nameof(City))
                .Field(nameof(Additional))
                .AddRemainingFields()
                .Build();
        }

        [Prompt("What is your new street address?")]
        [Describe("Address for the invoice to be sent to.")]
        public string StreetAddress;

        [Prompt("Zip Code?")]
        [Describe("Address for the invoice to be sent to.")]
        public string ZipCode;

        [Prompt("City?")]
        [Describe("Address for the invoice to be sent to.")]
        public string City;

        [Prompt("Anything else I need to know about your new address?")]
        [Describe("Address for the invoice to be sent to.")]
        public string Additional;

    }

}