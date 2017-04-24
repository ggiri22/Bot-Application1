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
using BotApplication1;
using BotApplication1.Forms;
using BotApplication1.Dialogs;

namespace BotApplication1.Dialogs
{
    [Serializable]
    public class AddressDialog
    {
        public async Task NewAddressComplete(IDialogContext context, IAwaitable<NewAddress> result)
        {
            //to be completed
            var address = await result;
            Thread.Sleep(500);

            string AddressConfirmation = response._confirm();
            AddressConfirmation += response._streetaddress(address.StreetAddress);
            AddressConfirmation += response._zipcode(address.ZipCode);
            AddressConfirmation += response._city(address.City);

            await context.PostAsync(AddressConfirmation);
            //TBD: change into using LUIS
            if ((address.Additional != "no") & (address.Additional != "nope") & (address.Additional != "No")) //förfina med LUIS
            {
                await context.PostAsync(response._youalsotoldme() + ": *" + address.Additional + " * ");
            }
            Thread.Sleep(400);
            PromptDialog.Confirm(context, AfterConfirming_ChangeAddress, response.isthisright(), response.onlyyesornoplease()); //, promptStyle: PromptStyle.None
        }
        public async Task AfterConfirming_ChangeAddress(IDialogContext context, IAwaitable<bool> confirmation)
        {

            if (await confirmation)
            {
                await context.PostAsync("Thanks again. I'll learn what to do with the information soon.");
                //implement the address change here
                Thread.Sleep(900);
                await context.PostAsync("By the way, I see that you are running out of data on your subscription."); // *NB! in a full implementation this would be a based on we think you might need help with*

                SelectUpgradeOption(context);
            }
            else
            {
                await context.PostAsync("Ok! I didn't change anything. Let's try from the start.");
                //context.Wait(MessageReceived);
            }
        }
        public void SelectUpgradeOption(IDialogContext context)
        {
            UpgradeOption[] optionArray = new UpgradeOption[4]
            {
                new UpgradeOption("6GB", "SEK50"),
                new UpgradeOption("12GB", "SEK80"),
                new UpgradeOption("24GB", "SEK130"),
                new UpgradeOption("50GB", "SEK180"),
            };
            UpgradeOptions optionList = new UpgradeOptions(optionArray);

            string[] upgradeoptions = new string[optionArray.Length];
            for (int i = 0; i <= optionArray.Length - 1; i++)
            {
                upgradeoptions[i] += $"{optionArray[i].dataAmount}, (+{optionArray[i].monthlyCost}/month)";
            }

            var dialog = new PromptDialog.PromptChoice<string>(upgradeoptions, response.askforoptions(), "Sorry, that wansn't a valid option", 3);
            Thread.Sleep(700);
            context.Call(dialog, UpgradeMobileData);

        }
        private async Task UpgradeMobileData(IDialogContext context, IAwaitable<string> result)
        {
            string userChoice = await result;
            PromptDialog.Confirm(context, AfterUpgradingData, "Just checking, did you want " + userChoice + "?"); //, promptStyle: PromptStyle.None
        }
        private async Task AfterUpgradingData(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                await context.PostAsync(response.ifthiswaslive());
                Thread.Sleep(900);
                //await context.PostAsync(response.askforfeedback());
                //Thread.Sleep(500);
                FeedbackDialog SD = new FeedbackDialog();
                PromptDialog.Confirm(context, SD.AskForFeedback, response.feedbacktip()); //, promptStyle: PromptStyle.None
            }
            else
            {
                await context.PostAsync(response.nochangesmade());
            }
        }
        public async Task FBAddressComplete(IDialogContext context, IAwaitable<FBNewAddress> result)
        {
            //to be completed
            var address = await result;
            Thread.Sleep(500);

            string AddressConfirmation = response._confirm();
            AddressConfirmation += response._streetaddress(address.StreetAddress);
            AddressConfirmation += response._zipcode(address.ZipCode);
            AddressConfirmation += response._city(address.City);

            await context.PostAsync(AddressConfirmation);
            if ((address.Additional != "no") & (address.Additional != "nope") & (address.Additional != "No")) //förfina med LUIS
            {
                await context.PostAsync(response._youalsotoldme() + ": *" + address.Additional + " * ");
            }
            Thread.Sleep(400);

            AddressDialog AD = new AddressDialog();
            PromptDialog.Confirm(context, AD.AfterConfirming_ChangeAddress, response.isthisright(), response.onlyyesornoplease()); //, promptStyle: PromptStyle.None
        }

    }
}