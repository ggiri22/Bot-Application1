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

// to do - askPart1 users about what to implement next

namespace BotApplication1.Dialogs
{

    [LuisModel("95bf7f1b-ec5d-48bc-bcd9-a6f7aab4886d", "9aa44ab5065546aeba065088b15b23d1")]
    [Serializable]

    public class DefaultDialog : LuisDialog<object>
    {
        //broadband intents
        public const string Intent_Select_Fiber = "broadband.Select fiber";
        public const string Intent_Select_PhoneSocket = "broadband.Select phone socket";
        public const string Intent_Select_TVSocket = "broadband.Select TV socket";

        //general intents
        public const string Intent_None = "";
        public const string Intent_Check_Result = "general.Check result";
        public const string Intent_Farewell = "general.Bye";
        public const string Intent_Feedback = "general.Provide feedback";
        public const string Intent_Forget = "general.Forget";
        public const string Intent_Greet = "general.Hi";
        public const string Intent_Greet_Swedish = "general.Hi.swedish";
        public const string Intent_OK = "general.OK";
        public const string Intent_RelayToPerson = "general.Relay To Person";
        public const string Intent_Retry = "general.Retry";
        public const string Intent_SignIn = "general.Sign On";
        public const string Intent_Skills = "general.Ask for Skills";
        public const string Intent_ThankYou = "general.Thank You";
        public const string Intent_Tip = "general.Ask for Tip";
        //intents related to broadband
        public const string Intent_Router_Installation_Help = "broadband.Install router help";
        //intents related to a subscription
        public const string Intent_Cancel_Subscription = "subscription.Cancel subscription";
        public const string Intent_Change_Address = "subscription.Change address";
        public const string Intent_Get_Invoice = "subscription.Get invoice";
        public const string Intent_Increase_Mobile_Data = "subscription.Increase mobile data";
        public const string Intent_New_Subscription = "subscription.New Subscription";
        public const string Intent_VoiceMailOn = "subscription.Turn on voice mail";
        public const string Intent_VoiceMailOff = "subscription.Turn off voice mail";
        //intents related to internal use
        public const string Intent_Book_Conference_Rooms = "internal.Book conference rooms";
        public const string Intent_Conf_Room_Equipment = "internal.Conf room equipment";
        public const string Intent_Get_Participants = "internal.Get participants";
        //intents for projet development
        public const string Intent_Test_HeroCard = "development.Test Hero Card";
        const string herocardwidth = "280";
        const string herocardheight = "146";

        string strBaseURL;
        
        
        //broadband specific intents
        [LuisIntent(Intent_Select_Fiber)]
        public async Task InstallFiber(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var buttonimage = new CardImage($"{strBaseURL}Images\bredband-technicolor799-1-fiber.jpg");
            await ShowBroadbandConnection(context, buttonimage);
        }

        [LuisIntent(Intent_Select_PhoneSocket)]
        public async Task InstallPhoneSocket(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var buttonimage = new CardImage($"{strBaseURL}Images/bredband-technicolor799-1-telejack.jpg");
            await ShowBroadbandConnection(context, buttonimage);
        }

        [LuisIntent(Intent_Select_TVSocket)]
        public async Task InstallTVSocket(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var buttonimage = new CardImage($"{strBaseURL}Images/bredband-technicolor799-1-antenn.jpg");
            await ShowBroadbandConnection(context, buttonimage);
        }

        private async Task ShowBroadbandConnection(IDialogContext context, CardImage btnimage)
        {
            var heroreply = ShowConnectNetworkCable(context, btnimage);
            await context.PostAsync(response.moveon());
            Thread.Sleep(400);
            await context.PostAsync(heroreply);
            var yesorno = new PromptOptions<string>(response.connectednetwork());
            var connectiondialog = new PromptDialog.PromptConfirm(yesorno);
            context.Call(connectiondialog, ConnectPowerCord); //, promptStyle: PromptStyle.None
        }

        private IMessageActivity ShowConnectNetworkCable(IDialogContext context, CardImage btnimage)
        {
            var reply = context.MakeMessage();
            reply = ShowRichMessage(context, btnimage, response.connectto(response._network()), response._connecttonetworkheader());
            return reply;
        }

        private async Task ConnectPowerCord(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                var btnimage = new CardImage($"{strBaseURL}Images/bredband-technicolor799-2.jpg");
                await context.PostAsync(response.moveon());
                Thread.Sleep(300);
                var reply = context.MakeMessage();
                reply = ShowRichMessage(context, btnimage, response.connectto(response._power()), response._connecttopowerheader());
                await context.PostAsync(reply);
                var yesorno = new PromptOptions<string>(response.connectedpower());
                var connectiondialog = new PromptDialog.PromptConfirm(yesorno);
                context.Call(connectiondialog, ConnectLAN);
            }
            else
            {
                PromptDialog.Confirm(context, ConnectPowerCord, response.abort());
            }
        }

        private async Task ConnectLAN(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                var btnimage = new CardImage($"{strBaseURL}Images/bredband-technicolor799-lan.jpg");
                await context.PostAsync(response.moveon());
                Thread.Sleep(300);
                var reply = context.MakeMessage();
                reply = ShowRichMessage(context, btnimage, response.connectto(response._lan()), response._connecttolanheader());
                await context.PostAsync(reply);
                Thread.Sleep(600);
                await context.PostAsync(response.youredoneconnectingbroadband());

                var yesorno = new PromptOptions<string>(response.connectedLAN());
                var connectiondialog = new PromptDialog.PromptConfirm(yesorno);
                context.Call(connectiondialog, VeryfyLAN);
            }
            else
            {
                PromptDialog.Confirm(context, ConnectPowerCord, response.abort());
            }
        }

        private async Task VeryfyLAN(IDialogContext context, IAwaitable<bool> result)
        {
            await context.PostAsync(response.confirmeverythingOK());
            Thread.Sleep(400);
            PromptDialog.Confirm(context, AskAboutWireless, response.askaboutwireless());
        }

        private async Task AskAboutWireless(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                await context.PostAsync("...sorry, haven't learnt that yet...");
            }
            else
            {
                await context.PostAsync(response.youredonewithbroadband());
            }
            context.Done(true);
        }

        private IMessageActivity ShowRichMessage(IDialogContext context, CardImage btnimage, string hTitle, string hText)
        {
            var heroCard = new HeroCard()
            {
                Title = hTitle,
                Images = new List<CardImage> { btnimage },
                Buttons = new List<CardAction> {
                    new CardAction()
                    {
                        Value = response._yes(),
                        Type = "imBack",
                        Title = response._itsdone()
                    }
                }
            };
            var reply = context.MakeMessage();
            reply.Text = hText;
            reply.Attachments = new List<Attachment> { heroCard.ToAttachment() };
            return reply;
        }

        // intents for development purposes
        [LuisIntent(Intent_Test_HeroCard)]
        public async Task TestHeroCard(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            PostUnderConstruction(context);

            Activity reply = (Activity)context.MakeMessage();
            reply.Text = "standard message";
           
            string imageurl = $"{strBaseURL}Images/guider-installation-fiberuttag.png";
            string resizedimage = $"https://images1-focus-opensocial.googleusercontent.com/gadgets/proxy?url={imageurl}&container=focus&resize_w={herocardwidth}&resize_h={herocardheight}";
            reply.CreateReply("Here's a **hero**");
            context.UserData.TryGetValue<string>("CurrentBaseURL", out strBaseURL);
            var heroCard = new HeroCard()
            {
                Title = "I'm a hero card",
                Subtitle = "Robin hearts Tachikoma",
                Images = new List<CardImage> {
                    new CardImage(resizedimage) //
                },
                Buttons = new List<CardAction> {
                new CardAction()
                    {
                        Value = "https://robinosborne.co.uk/?s=bot",
                        Type = "openUrl",
                        Title = "Rob's bots"
                    }
                }
            };

            reply.Attachments = new List<Attachment> {
                heroCard.ToAttachment()
            };
            await context.PostAsync(reply);
        }

        public void PostUnderConstruction(IDialogContext context)
        {
            const string imageurl = "https://img.clipartfest.com/3319fd3bbc893a3b1066474a151fe79a_under-construction-clip-art-5-under-construction-clipart_386-225.jpeg";
            string resizedimage = $"https://images1-focus-opensocial.googleusercontent.com/gadgets/proxy?url={imageurl}&container=focus&resize_w={herocardwidth}&resize_h={herocardheight}";


            Activity uc = (Activity)context.MakeMessage();
            uc.Text = "I'm still learning this, so don't be alarmed if it looks weird. It doesn't work yet anyway";
            uc.Attachments = new List<Attachment>
            {
                new Attachment()
                {
                    ContentUrl = resizedimage,
                    ContentType = "image/jpg"
                }
            };
            context.PostAsync(uc);
        }

    //generic intents to support a feeling of a broader conversation

    [LuisIntent(Intent_Forget)]

        public async Task Forget(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            //Reset all user parameters
            await context.PostAsync(response.confirmforget());
            context.PrivateConversationData.SetValue("Greeted", false);
            context.PrivateConversationData.SetValue("PhoneNumber", "");
            Thread.Sleep(300);
            await context.PostAsync(response.confirmforgotten());
            Thread.Sleep(300);
            await context.PostAsync(response.howtorestart());
            context.Done(true);
            //context.Reset();
        }

        [LuisIntent(Intent_Feedback)]

        public async Task ProvideFeedback(IDialogContext context, LuisResult result)
        {
            Thread.Sleep(400);
            var FeedbackForm = new FormDialog<NormalFeedbackCollection>(new NormalFeedbackCollection(), NormalFeedbackCollection.MakeForm, FormOptions.PromptInStart);
            context.Call(FeedbackForm, FeedbackComplete);
        }
        private async Task FeedbackComplete(IDialogContext context, IAwaitable<NormalFeedbackCollection> result)
        {
            string lastmessage = null;
            context.PrivateConversationData.TryGetValue("LastMessage", out lastmessage);
            string mailmessage = lastmessage;
            EmailDomain.SendExchangeMail(mailmessage);
            await context.PostAsync(response.thanksandbye());
        }

        [LuisIntent(Intent_Router_Installation_Help)]
        public async Task InstallRouterHelp(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            PromptDialog.Confirm(context, HelpSetupRouter, response.routerhelp()); //, promptStyle: PromptStyle.None
        }
        private async Task HelpSetupRouter(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                Activity reply = (Activity)context.MakeMessage();
                context.UserData.TryGetValue<string>("CurrentBaseURL", out strBaseURL);
                string imageurl = $"{strBaseURL}Images/799.jpg";
                reply.CreateReply("Technicolor 799");
                reply.Text = response.confirmroutermodel("Technicolor 799");
                reply.Attachments = new List<Attachment>
                {
                    new Attachment()
                    {
                        ContentUrl = imageurl,
                        ContentType = "image/jpg"
                    }
                };
                await context.PostAsync(reply); //TBC Replace with actual knowledge about the customer
                Thread.Sleep(500);
                PromptDialog.Confirm(context, CheckDelivery, response.verifyrouter()); //, promptStyle: PromptStyle.None
            }
            else
            {
                //TBC: what is your actual router? 
                await context.PostAsync(response.thanksanyway()); //remove
            }
        }

        private async Task CheckDelivery(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                //show the delivery
                context.UserData.TryGetValue<string>("CurrentBaseURL", out strBaseURL);
                string PictureURL = $"{strBaseURL}Images/packagecontent.png";
                var packagecontents = context.MakeMessage();
                packagecontents.Text = "Check that you have all the parts of the packaged we sent. This is what's supposed to be in the package";
                packagecontents.Attachments = new List<Attachment> {
                    new Attachment()
                    {
                        ContentUrl = PictureURL,
                        ContentType = "image/png",
                    }
                };
                await context.PostAsync(packagecontents);

                Thread.Sleep(500);
                //confirm that everything is there and continue
                PromptDialog.Confirm(context, AfterDeliveryConfirmed, response.verifygeneric()); //, promptStyle: PromptStyle.None

            }
            else
            {
                var buttonimage = new CardImage($"{strBaseURL}Images/modell-pa-modem-ny-402x306.png");
                var heroCard = new HeroCard()
                {
                    Title = "This is where you find the router model",
                    Subtitle = "Tap here if you want the full web page help",
                    Images = new List<CardImage> { buttonimage },
                    Buttons = new List<CardAction> {
                        new CardAction()
                            {
                                Value = "http://www.bredbandsbolaget.se/kundservice/bredband/via-fiber/guider.html",
                                Type = "openUrl",
                                Title = "Bredbansbolaget"
                            }
                        }
                };
                var heroreply = context.MakeMessage();
                heroreply.Text = "Please check!";
                heroreply.Attachments = new List<Attachment> {
                    heroCard.ToAttachment()
                };
                await context.PostAsync(heroreply);

                var dialog = new PromptDialog.PromptString(response.askforroutermodel(), response.retry(), 1);
                context.Call(dialog, InstallRouter);
                //TBC: what is your actual router? 
            }
        }

        private async Task AfterDeliveryConfirmed(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                Thread.Sleep(200);
                await context.PostAsync(response.letshelp());
                Thread.Sleep(200);
                context.UserData.TryGetValue<string>("CurrentBaseURL", out strBaseURL);

                Activity routerConversation = (Activity)context.MakeMessage();
                routerConversation.Recipient = routerConversation.Recipient;
                routerConversation.Type = "message";
                routerConversation.Text = response._howdoyouconnectrouter();
                routerConversation.Attachments = new List<Attachment>();
                routerConversation.AttachmentLayout = "carousel";

                string fibersocketimage = $"{strBaseURL}Images/guider-installation-fiberuttag.png";
                string dslsocketimage = $"{strBaseURL}Images/guider-installation-telejacket.png";
                string tvsocketimage = $"{strBaseURL}Images/guider-installation-antennuttag.png";

                List<CardImage> fibersocketCards = new List<CardImage>();
                List<CardImage> dslsocketCards = new List<CardImage>();
                List<CardImage> tvsocketCards = new List<CardImage>();

                fibersocketCards.Add(new CardImage(fibersocketimage)); //resized
                dslsocketCards.Add(new CardImage(dslsocketimage)); //resized
                tvsocketCards.Add(new CardImage(tvsocketimage)); //resized

                CardAction fiberButton = new CardAction()
                {
                    Type = "imBack",
                    //Title = "Fiber",
                    //Image = fibersocketimage,
                    Value = response._fiber()
                };
                CardAction adslButton = new CardAction()
                {
                    Type = "imBack",
                    //Title = "DSL",
                    //Image = dslsocketimage,
                    Value = response._phonesocket()
                };
                CardAction tvButton = new CardAction()
                {
                    Type = "imBack",
                    //Title = "TV",
                    //Image = tvsocketimage,
                    Value = response._tvsocket()
                };

                List<CardAction> fiberButtons = CreateButton(response._fiber());
                List<CardAction> dslButtons = CreateButton(response._phonesocket()); //NB! needs to be internationally adapted
                List<CardAction> tvButtons = CreateButton(response._tvsocket());

                HeroCard fiberCard = new HeroCard()
                {
                    Title = response._fiber(),
                    Images = fibersocketCards,
                    Buttons = fiberButtons,
                    Tap = fiberButton
                };
                HeroCard dslCard = new HeroCard()
                {
                    Title = response._phonesocket(),
                    Images = dslsocketCards,
                    Buttons = dslButtons,
                    Tap = adslButton
                };
                HeroCard tvCard = new HeroCard()
                {
                    Title = response._tvsocket(),
                    Images = tvsocketCards,
                    Buttons = tvButtons,
                    Tap = tvButton
                };

                Attachment fiberAttachment = fiberCard.ToAttachment();
                Attachment dslAttachment = dslCard.ToAttachment();
                Attachment tvAttachment = tvCard.ToAttachment();
                routerConversation.Attachments.Add(fiberAttachment);
                routerConversation.Attachments.Add(dslAttachment);
                routerConversation.Attachments.Add(tvAttachment);
                await context.PostAsync(routerConversation);
            }
            else
            {
                //tbd: what to do if the delivery is not complete
            }
        }

        private static List<CardAction> CreateButton(string selectedcableoption)
        {
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction CardButton = new CardAction()
            {
                Type = "imBack",
                Title = selectedcableoption,
                Value = selectedcableoption
            };
            cardButtons.Add(CardButton);
            return cardButtons;
        }

        private async Task InstallRouter(IDialogContext context, IAwaitable<string> result)
        {
            string userinput = await result;
            await context.PostAsync(response.yourrouteris(userinput));
            Thread.Sleep(300);
            await context.PostAsync("I'll learn about this one and other models soon");
            context.Done(true);
            //Implement installing a router as selected.
        }

        [LuisIntent(Intent_SignIn)]
        public async Task MyoAuthSignIn(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            SigninOption[] optionArray = new SigninOption[3]
            {
                new SigninOption("Facebook"),
                new SigninOption("Google"),
                new SigninOption("Telenor")
            };
            SigninOptions optionList = new SigninOptions(optionArray);

            string[] signinoptions = new string[optionArray.Length];
            for (int i = 0; i <= optionArray.Length - 1; i++)
            {
                signinoptions[i] += $"{optionArray[i].selectedOption}";
            }

            var dialog = new PromptDialog.PromptChoice<string>(signinoptions, response.askforoptions(), "Sorry, that wansn't a valid option", 3);
            Thread.Sleep(400);
            context.Call(dialog, SignIn);
        }
        private async Task SignIn(IDialogContext context, IAwaitable<string> result)
        {
            
            CardAction fbButton = new CardAction()
            {
                Type = "signin",
                Title = "Facebook",
                Image = $"url: {strBaseURL}Images/signin_facebook.png",
                Value = "https://robinosborne.co.uk/?s=bot"
            };
            CardAction googleButton = new CardAction()
            {
                Type = "signin",
                Title = "Google",
                Image = $"{strBaseURL}Images/signin_google.png",
                Value = "https://robinosborne.co.uk/?s=bot"
            };
            CardAction cidButton = new CardAction()
            {
                Type = "signin",
                Title = "Telenor",
                Image = $"{strBaseURL}Images/signin_telenor.png",
                Value = "https://connect.staging.telenordigital.com/oauth"
            };
            
            List<CardAction> signinButtons = new List<CardAction>();
            string selected = result.ToString();
            switch (selected)
            {
                case "Facebook":
                    signinButtons.Add(fbButton);
                    break;
                case "Google":
                    signinButtons.Add(googleButton);
                    break;
                default:
                    signinButtons.Add(cidButton);
                    break;
            }
            SigninCard siCard = new SigninCard("Authorization required", signinButtons);
            Attachment siAttachment = siCard.ToAttachment();
            var reply = context.MakeMessage();
            reply.Text = "Please log in to your Telenor resources";
            reply.Attachments.Add(siAttachment);

            await context.PostAsync(reply);
        }

        [LuisIntent(Intent_VoiceMailOn)]
        public async Task TurnOnVoiceMail(IDialogContext context, LuisResult result)
        {
            //TBC
            Thread.Sleep(300);
            string PhoneNumber = null;
            context.PrivateConversationData.TryGetValue("PhoneNumber", out PhoneNumber);
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                var PhoneNoForm = new FormDialog<PhoneNoForm>(new PhoneNoForm(), Forms.PhoneNoForm.MakeForm, FormOptions.PromptInStart);
                context.Call(PhoneNoForm, SavePhoneVMOn);
            }
            else
            {
                await context.PostAsync(response.voicemailon(PhoneNumber));
                PromptDialog.Confirm(context, AskForFeedback, response.feedbacktip()); //, promptStyle: PromptStyle.None
            }
        }
        public async Task SavePhoneVMOn(IDialogContext context, IAwaitable<PhoneNoForm> result)
        {
            var PhoneNumber = await result;
            string pno = PhoneNumber.PNumber;
            context.PrivateConversationData.SetValue("PhoneNumber", pno);
            await context.PostAsync(response.voicemailon(pno));
            PromptDialog.Confirm(context, AskForFeedback, response.feedbacktip(), "Not quite sure what you meant, could you try again?", 3, PromptStyle.Auto); //, promptStyle: PromptStyle.None
            context.Done(true);
        }

        [LuisIntent(Intent_VoiceMailOff)]
        public async Task TurnOffVoiceMail(IDialogContext context, LuisResult result)
        {
            //TBC
            Thread.Sleep(300);
            string PhoneNumber = null;
            context.PrivateConversationData.TryGetValue("PhoneNumber", out PhoneNumber);
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                var PhoneNoForm = new FormDialog<PhoneNoForm>(new PhoneNoForm(), Forms.PhoneNoForm.MakeForm, FormOptions.PromptInStart);
                context.Call(PhoneNoForm, SavePhoneVMOff);
            }
            else
            {
                await context.PostAsync(response.voicemailoff(PhoneNumber));
            }
        }
        public async Task SavePhoneVMOff(IDialogContext context, IAwaitable<PhoneNoForm> result)
        {
            var PhoneNumber = await result;
            string pno = PhoneNumber.PNumber;
            context.PrivateConversationData.SetValue("PhoneNumber", pno);
            await context.PostAsync(response.voicemailoff(pno));
            context.Done(true);
        }

        [LuisIntent(Intent_Skills)]
        public async Task AskForSkills(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            //TBC
            await context.PostAsync("Currently you can test to change your address. I don't do anything with the information, my purpose in life is to test the dialog flow and see how we make it work well for you.");
            Thread.Sleep(700);
            await context.PostAsync("Well, you actually also can ask about an invoice, but that dialog is not very elaborate yet. I'm not very happy with how it works, but feel free to test it");
            Thread.Sleep(700);
            await context.PostAsync("You can also give me feedback. Why not tell me what you would like me to learn next?");
            //System.Diagnostics.Debug.WriteLine(UserDomain.GetApiVersion());
            context.Done(true);
        }

        [LuisIntent(Intent_ThankYou)]
        public async Task ThankYou(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            //TBC
            await context.PostAsync(response.yourewelcome());
            Thread.Sleep(700);
            await context.PostAsync(response.illbehere());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intent_Tip)]
        public async Task AskForTip(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            //TBC
            int i = result.Entities.Count;
            await context.PostAsync("Sorry, my master has not taught me how to answer that yet");
            context.Done(true);
        }

        [LuisIntent(Intent_Retry)]
        public async Task Retry(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            await context.PostAsync("OK, just go ahead");
            context.Done(true);
        }

        [LuisIntent(Intent_RelayToPerson)]
        public async Task RelayToPerson(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            await context.PostAsync("For now, I need to ask you to call +46 20 22 22 22 - my human partner, customer service . In the future I wil be able to connect you directly or aske them to call you up.");
            context.Done(true);
        }

        [LuisIntent(Intent_Greet_Swedish)]
        public async Task Greet_Swedish(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            await context.PostAsync(response.noswedish());
            await Greet(context, message, result);
        }

        [LuisIntent(Intent_OK)]
        [LuisIntent(Intent_Greet)]
        public async Task Greet(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            bool greeted = false;
            context.PrivateConversationData.TryGetValue<bool>("Greeted", out greeted);
            if (greeted)
            {
                Thread.Sleep(200);
                await context.PostAsync($":-) {response.askPart1()} {response.askPart2()}");
                Thread.Sleep(600);
                await context.PostAsync(response.putintouch());
            }
            else
            {
                Thread.Sleep(200);
                await context.PostAsync($"{response.introPart1()}");
                Thread.Sleep(300);
                await context.PostAsync($"{response.introPart2()} {response.introPart3()}");
                context.PrivateConversationData.SetValue<bool>("Greeted", true);
            }
            context.Wait(MessageReceived); //Done(true)
        }

        [LuisIntent(Intent_None)]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            //var cts = new CancellationTokenSource();
            //await context.Forward(new GreetingsDialog(), GreetingDialogDone, await message, cts.Token);
            await context.PostAsync(response.dontknowhow());
            var lastmessage = await message;
            string lm = lastmessage.Text;
            context.PrivateConversationData.SetValue<string>("LastMessage", lm);
            PromptDialog.Confirm(context, AfterAskinForFeedback_SendMail, response.asktolearn(), response.onlyyesornoplease(), promptStyle: PromptStyle.None); //
            //context.Done(true);
        }
        private async Task AfterAskinForFeedback_SendMail(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                await context.PostAsync(response.thanksforfeedback());
                Thread.Sleep(700);
                string lastmessage = null;
                context.PrivateConversationData.TryGetValue("LastMessage", out lastmessage);
                string mailmessage = lastmessage;
                EmailDomain.SendExchangeMail(mailmessage);
                await context.PostAsync(response.confirmsendingemail());
            }
            else
            {
                Thread.Sleep(300);
                await context.PostAsync(response.noproblem());
            }
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intent_Farewell)]
        public async Task Bye(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Bye. Hope to see you soon again. Have a good day!");
            context.Done(true);
        }

        [LuisIntent(Intent_Get_Invoice)]
        public async Task GetInvoice(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            await context.PostAsync("So you were wondering about your invoice. When I learn how to verify that you are actually you I will show you the invoice. My maker has that as a high priority. I don't want to share your secrets to the world. Your privacy is important to me");
            var InvoiceForm = new FormDialog<Invoice>(new Invoice(), Invoice.MakeForm, FormOptions.PromptInStart);
            context.Call(InvoiceForm, InvoiceComplete);
            //kolla om följande behövs
            context.Done(true);
        }
        private async Task InvoiceComplete(IDialogContext context, IAwaitable<Invoice> result)
        {
            //to be completed
            // bara en av de två raderna nedan behövs. Båda säger nämligen "tack". Därför än den första bortkommenterad
            //await context.PostAsync("Thanks again. I'll learn what to do with the information soon.");
            PromptDialog.Confirm(context, AskForFeedback, response.feedbacktip()); //, promptStyle: PromptStyle.None
            context.Done(true);

            //Test att extrahera användardata baserat på telefonnummer. Funkar på LAN - förutom att svaret inte innehåller användarinfo
            //string pno = null;
            //context.PrivateConversationData.TryGetValue<string>("PhoneNumber", out pno);
            //pno = formatPhoneNumber(pno);
            //AskBassForCustomerDetails.GetCustDetails(pno);
            //context.Wait(MessageReceived);
        }
        private string formatPhoneNumber(string rawNumber)
        {
            string tempPNo = rawNumber;
            if (tempPNo.StartsWith("+"))
            {
                tempPNo = tempPNo.Remove(0,1);
            }
            else
            {
                if (tempPNo.StartsWith("0"))
                {
                    tempPNo = "46" + tempPNo.Remove(0, 1);
                }
            }
            return tempPNo;

        }

        [LuisIntent(Intent_Change_Address)]
        public async Task GetAddress(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Let's try to change your address then.");
            if (context.Activity.ChannelId == "facebook")
            {
                var NewAddressForm = new FormDialog<FBNewAddress>(new FBNewAddress(), FBNewAddress.MakeForm, FormOptions.PromptInStart);
                context.Call(NewAddressForm, FBAddressComplete);
            }
            else
            {
                var NewAddressForm = new FormDialog<NewAddress>(new NewAddress(), NewAddress.MakeForm, FormOptions.PromptInStart);
                context.Call(NewAddressForm, AddressComplete);
            }
        }
        private async Task AddressComplete(IDialogContext context, IAwaitable<NewAddress> result)
        {
            //to be completed
            var address = await result;
            Thread.Sleep(500);

            string AddressConfirmation = "OK, this what I got...\n\n";
            AddressConfirmation += $"Street: { address.StreetAddress }\n\n";
            AddressConfirmation += $"Zip code: { address.ZipCode }\n\n";
            AddressConfirmation += $"City: { address.City }";

            await context.PostAsync(AddressConfirmation);
            if ((address.Additional != "no") & (address.Additional != "nope") & (address.Additional != "No")) //förfina med LUIS
            {
                await context.PostAsync("You also told me: *" + address.Additional + "*");
            }
            Thread.Sleep(400);
            PromptDialog.Confirm(context, AfterConfirming_ChangeAddress, "Is this right?",response.onlyyesornoplease()); //, promptStyle: PromptStyle.None
        }
        private async Task FBAddressComplete(IDialogContext context, IAwaitable<FBNewAddress> result)
        {
            //to be completed
            var address = await result;
            Thread.Sleep(500);

            string AddressConfirmation = "OK, this what I got...\n\n";
            AddressConfirmation += $"Street: { address.StreetAddress }\n\n";
            AddressConfirmation += $"Zip code: { address.ZipCode }\n\n";
            AddressConfirmation += $"City: { address.City }";

            await context.PostAsync(AddressConfirmation);
            if ((address.Additional != "no") & (address.Additional != "nope") & (address.Additional != "No")) //förfina med LUIS
            {
                await context.PostAsync("You also told me: *" + address.Additional + "*");
            }
            Thread.Sleep(400);
            PromptDialog.Confirm(context, AfterConfirming_ChangeAddress, "Is this right?", response.onlyyesornoplease()); //, promptStyle: PromptStyle.None
        }
        private async Task AfterConfirming_ChangeAddress(IDialogContext context, IAwaitable<bool> confirmation)
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
                context.Wait(MessageReceived);
            }
        }
        private void SelectUpgradeOption(IDialogContext context)
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
                PromptDialog.Confirm(context, AskForFeedback, response.feedbacktip()); //, promptStyle: PromptStyle.None

            }
            else
            {
                await context.PostAsync(response.nochangesmade());
            }
        }
        private async Task AskForFeedback(IDialogContext context, IAwaitable<bool> confirmation)
        {
            if (await confirmation)
            {
                await context.PostAsync(response.thankyou());
                Thread.Sleep(700);
                var NewFeedbackForm = new FormDialog<SimpleFeedbackCollection>(new SimpleFeedbackCollection(), SimpleFeedbackCollection.MakeForm, FormOptions.PromptInStart);
                context.Call(NewFeedbackForm, FeedbackComplete);
            }
            else
            {
                await context.PostAsync(response.thanksanyway());
            }

        }
        private async Task FeedbackComplete(IDialogContext context, IAwaitable<SimpleFeedbackCollection> result)
        {
            string lastmessage = null;
            context.PrivateConversationData.TryGetValue("LastMessage", out lastmessage);
            string mailmessage = lastmessage;
            EmailDomain.SendExchangeMail(mailmessage);
            await context.PostAsync(response.thanksandbye());
            context.Done(true);
        }

        [LuisIntent(Intent_Cancel_Subscription)]
        public async Task CancelSubscription(IDialogContext context, LuisResult result)
        {
            string returnMessage = "...Cancel Subscription...";
            await context.PostAsync(returnMessage);
        }

        [LuisIntent(Intent_Check_Result)]
        public async Task CheckResult(IDialogContext context, LuisResult result)
        {
            string returnMessage = "...Check Result...";
            await context.PostAsync(returnMessage);
        }

        [LuisIntent(Intent_Book_Conference_Rooms)]
        public async Task BookConferenceRooms(IDialogContext context, LuisResult result)
        {
            string returnMessage = "...Book Conference Rooms...";
            var entities = new List<EntityRecommendation>(result.Entities); //fel?
            returnMessage += result.Entities.ToString();
            await context.PostAsync(returnMessage);
        }

        [LuisIntent(Intent_Conf_Room_Equipment)]
        public async Task ConfRoomEquipment(IDialogContext context, LuisResult result)
        {
            string returnMessage = "...Book Conference Rooms Equipment...";
            var entities = new List<EntityRecommendation>(result.Entities); //fel?
            returnMessage += result.Entities.ToString();
            await context.PostAsync(returnMessage);
        }

        [LuisIntent(Intent_Get_Participants)]
        public async Task GetParticipants(IDialogContext context, LuisResult result)
        {
            string returnMessage = "...Get Conference Participants...";
            var entities = new List<EntityRecommendation>(result.Entities); //fel?
            returnMessage += result.Entities.ToString();
            await context.PostAsync(returnMessage);
        }

        [LuisIntent(Intent_Increase_Mobile_Data)]
        public async Task TopUp(IDialogContext context, LuisResult result)
        {
            string PhoneNumber = null;
            context.PrivateConversationData.TryGetValue("PhoneNumber", out PhoneNumber);
            var PhoneNoForm = new FormDialog<PhoneNoForm>(new PhoneNoForm(), Forms.PhoneNoForm.MakeForm, FormOptions.PromptInStart);
            context.Call(PhoneNoForm, GotPhone);
            //gör klart
        }
        public async Task GotPhone(IDialogContext context, IAwaitable<PhoneNoForm> result)
        {
            var PhoneNumber = await result;
            string pno = PhoneNumber.PNumber;
            SelectUpgradeOption(context);
            //context.PrivateConversationData.SetValue("PhoneNumber", pno);
            //context.Done(true);
        }

        [LuisIntent(Intent_New_Subscription)]
        public async Task NewSubscription(IDialogContext context, LuisResult result)
        {
            string returnMessage = "...New Subscription... Hmmm... I hope I learn that soon.";
            await context.PostAsync(returnMessage);
        }


    }
}