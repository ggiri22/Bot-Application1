using System;
using Microsoft.Bot.Connector;

namespace BotApplication1
{
    public class response
    {
        //strings with variations
        private static string chooserandom(string[] message)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, message.Length);
            return message[randomNumber];
        }
        #region a-b strings
        public static string abort()
        {
            string[] responsemessage = {
                "Do you want to abort?",
                "Abort this?",
                "Do you want to skip this step?"
            };
            return chooserandom(responsemessage);
        }
        public static string askaboutwireless()
        {
            string[] responsemessage = {
                "Do you need help setting up the wireless network?",
                "Would you like me to help setting up the wireless network?",
                "Would you want help setting up the wireless network?",
                "Would you like me to help setting up the wireless network?"};
            return chooserandom(responsemessage);
        }
        public static string askPart1()
        {
            string[] responsemessage = {
                "Just ask me something.",
                "You can just ask for whatever you want me to help you with.",
                "What can I do for you today?",
                "I’m Telenor's Internet Patronus. Call meTip. At your service."
            };
            return chooserandom(responsemessage);
        }
        public static string askPart2()
        {
            string[] responsemessage = {
                "I'll help if I know how",
                "If I know how, I'll help",
                "If I know how, I'll help - of course ;-)",
                "As long as I know how, I'll help"
            };
            return chooserandom(responsemessage);
        }
        public static string askforfeedback()
        {
            string[] responsemessage = {
                "Oh... Would you help me and share if you felt that this was a good experience?",
                "A small request... Would you mind telling me how this chat worked for you?",
                "A small favor? Would yu mind giving me some feedback on how this chat worked for you?",
                "Could you help me a litte? Could you feed back on how this dialog could improve?"};
            return chooserandom(responsemessage);
        }
        public static string askforgeneralfeedback()
        {
            string[] responsemessage = {
                "So what do you want to tell me?",
                "What did you want to tell me?",
                "What do I need to know?",
                "What is it you feel I should know?",
                "What would you like to tell me?"};
            return chooserandom(responsemessage);
        }
        public static string askfornextsteps()
        {
            string[] responsemessage = {
                "What other tasks you would like me to be able to handle for you?",
                "What other tasks you would like help with?",
                "What other tasks you would like me to handle?",
                "What other tasks you would like me to handle for you?",
                "What other tasks you would like me to be able to handle?"};
            return chooserandom(responsemessage);
        }
        public static string askforroutermodel()
        {
            string[] responsemessage = {
                "Take a look at the picture. What model do you have?",
                "What is your router model? You can find it as indicated by the picture",
                "Can you tell me your router model? You can find the info as shown on the picture"};
            return chooserandom(responsemessage);
        }
        public static string askforoptions()
        {
            string[] responsemessage = {
                "Which option would you like?",
                "What option do you prefer?",
                "What option would be your choice?",
                "What's your preference?",
                "What's your preferred option?"};
            return chooserandom(responsemessage);
        }
        public static string asktolearn()
        {
            string[] responsemessage = {
                "However, I can send your question to my maker, if you me want to. Would you be OK with that?",
                "However, I can send your question to the programmers, if you want to. Is that OK with you?",
                "But I can send your message to the people that build me. Is that OK with you?",
                "I could send your message to our programmers, though. Can I?"};
            return chooserandom(responsemessage);
        }
        public static string bearwithme()
        {
            string[] responsemessage =
            {
                "But bear with me. I learn new things every day.",
                "Bear with me. I add new skills almost daily.",
                "Have patience with me, I try to learn new stuff every day.",
                "I try to learn new skills every day. So bear with me."
            };
            return chooserandom(responsemessage);
        }
        public static string bye()
        {
            string[] responsemessage =
            {
                "Bye. Hope to see you soon again. Have a good day!",
                "It's been a pleasure!",
                "Bye. Nice to have met you!",
                "Bye-bye. See you soon again!",
                "Glad that you're here! And hope to see you soon again"
            };
            return chooserandom(responsemessage);
        }
        #endregion
        #region c-e strings
        public static string changeaddress()
        {
            string[] responsemessage =
            {
                "Let's try to change your address then.",
                "Let me try to do something about your address then.",
                "OK, a few questions to help me along",
                "Let's get started then"
            };
            return chooserandom(responsemessage);
        }
        public static string currentlymyskillsare()
        {
            string[] responsemessage =
            {
                "Currently I can",
                "My current skills are to",
                "Currently I know how to",
                "So far, I can help you to"
            };
            return chooserandom(responsemessage);
        }
        public static string confirmeverythingOK()
        {
            string[] responsemessage = {
                "Everything should be working now",
                "OK, youre done. Surf's up ;-)",
                "Everything shoule be A-OK now. Enjoy!",
                "Have fun surfing! You're done"};
            return chooserandom(responsemessage);
        }
        public static string confirmforget()
        {
            string[] responsemessage = {
                "OK, on it. Sad to see you go",
                "OK, I'll erase the information I saved on you. You have been a good friend",
                "I'll remove my knowledge about you now. Sad to see you leave",
                "I hope I didn't offend you or anything. I'm erasing you from my memory now :'-("};
            return chooserandom(responsemessage);
        }
        public static string confirmforgotten()
        {
            string[] responsemessage = {
                "Who were you again? ;-)",
                "My memory feels so empty now...",
                "There's now a small cavity where your data used to be",
                "My server thanks you for the free space"};
            return chooserandom(responsemessage);
        }
        public static string confirmroutermodel(string model)
        {
            string[] responsemessage = {
                $"First things first. What is your broadband modem model? The one we sent was a *{model}*",
                $"One thing before we continue... I assume that you use he *{model}* we sent",
                $"Just checking... The *{model}* we sent you... I assume that's what you use ",
                $"We sent you a *{model}*"};
            return chooserandom(responsemessage);
        }
        public static string confirmsendingemail()
        {
            string[] responsemessage = {
                "I sent a mail to my maker now sharing what you asked for",
                "I sent your message on to our programmers",
                "Your message is now in the hands of my maker",
                "Your message is now saved to our priority list"};
            return chooserandom(responsemessage);
        }
        public static string connectedLAN()
        {
            string[] responsemessage = {
                $"Are you done connecting your device or network?",
                $"Did you connect the home network cable or device?",
                $"Now connect the local network at home (or your device). Done yet?",
                $"Is your home network connected? Or your device?"};
            return chooserandom(responsemessage);
        }
        public static string connectednetwork()
        {
            string[] responsemessage = {
                $"Are you done connecting the network?",
                $"Did you connect the network cable?",
                $"Now connect the cable. Done yet?",
                $"Is the network cable connected?"};
            return chooserandom(responsemessage);
        }
        public static string connectedpower()
        {
            string[] responsemessage = {
                $"Are you done connecting the power cord?",
                $"Did you connect the power supply?",
                $"Now connect the power cable. Done yet?",
                $"Is the power cable connected?"};
            return chooserandom(responsemessage);
        }
        public static string connectto(string cord)
        {
            string[] responsemessage = {
                $"Connect the {cord} cable to the router as I am drawing it on the picture",
                $"Connect the {cord} cable to the router the way I drew it on the picture",
                $"Connect the {cord} cable to the router the way I tried to show you on the picture"
            };
            return chooserandom(responsemessage);
        }
        public static string dontknowhow()
        {
            string[] responsemessage = {
                "Sorry, my master has not taught me how to answer that yet. I'm learning though",
                "Sorry, I'm not sure I can help there. But I'm learning new things almost every day",
                "Sorry, don't know how to interpret that, but I do learn new things daily",
                "Ooops, that is beyond my scope of knowledge. But I'm learning things daily",
                "Oh, no. I didn't understand. I'll try to learn though"};
            return chooserandom(responsemessage);
        }
        public static string error()
        {
            string[] responsemessage = {
                "Oh my, something went sour. Let me chek into it",
                "Oh no, something went wrong. I'll tell my makers",
                "Oh. I failed. Something's broken. I'll let my makers know",
                "Ooops. That didn't work. I'll check what went wrong"};
            return chooserandom(responsemessage);
        }

        #endregion
        #region f-i strings
        public static string feedbackprompt()
        {
            string[] responsemessage = {
                "Sorry, I'm not sure I can help there. But I'm learning new things almost every day",
                "Sorry, don't know how to interpret that, but I do learn new things daily",
                "Ooops, that is beyond my scope of knowledge. But I'm learning things daily",
                "Oh, no. I didn't understand. I'll try to learn though"};
            return chooserandom(responsemessage);
        }
        public static string feedbacktip() //string language, string personality
        {
            string[] responsemessage = {
                "Can you help me? I need a tip on what other tasks you would like me to be able to handle for you?",
                "Can you help me a little? I only have one more question :-)",
                "Can you help me with just one more question?",
                "Could you help me a little more? Just one more question ;-)",
                "Could you help me just a little more? Just a quick question",
                "Could you help me a little more? Just one small request",
                "Could you help me a little more? Around what to work on next?"};
            return chooserandom(responsemessage);
        }
        internal static string goahead()
        {
            string[] responsemessage = {
                "OK, just go ahead",
                "Great. Go ahead",
                "Okidokie. Please continue",
                "Okay. Just go on"};
            return chooserandom(responsemessage);
        }

        public static string hi()
        {
            string[] responsemessage = { "Hi", "Hello", "Hey", "Hi there", "Hello there", "Howdy", "Hullo", "Greetings", "Haloo" };
            return chooserandom(responsemessage);
        }
        public static string howtorestart()
        {
            string[] responsemessage = {
                "Actually, if you want to start from scratch, simply say 'Hi'",
                "If you want to start a new relationship, just say 'Hi'",
                "If you ever need me, just come by and say 'Hi'",
                "I'll be here if you ever need me again. A simple 'Hi' will do" };
            return chooserandom(responsemessage);
        }
        public static string imyourpatronus()
        {
            string[] responsemessage = {
                "I am Your Patronus. Designed to answer questions, primarily about your Telenor's services.",
                "I'm here for you. Your own Patronus. I'll help whenever I can, but keep in mind that I mostly know stuff related to Telenor.",
                "I'm your Patronus. I'll try to help you with your questions, but I primarily know Telenor related things.",
                "Your Patronus at your service. I primarily know Telenor related things, but I'll try to help with whatever you need."};
            return chooserandom(responsemessage);
        }
        public static string ifthiswaslive()
        {
            string[] responsemessage = {
                "If this was a live system, I would have ordered the upgrade for you.",
                "If I was connected to our live systems, I would have ordered the upgrade for you.",
                "One day, when I am connected to our live system, I will be able to order the upgrade for you.",
                "I'm not live with our core systems, so we're done for now.. But soon, I'll be able to help your for real."};
            return chooserandom(responsemessage);
        }
        public static string illbehere()
        {
            string[] responsemessage = {
                "I'll be here when you need me",
                "I'm not going anywhere. Keep in touch!",
                "Hope to see you soon again",
                "I look forward to seeing you soon again"};
            return chooserandom(responsemessage);
        }
        public static string introduction()
        {
            string abilities = string.Empty;
            abilities += $"* change your address\n";
            abilities += $"* find an invoice you have questions about\n\n";
            abilities += $"* help you install a broadband router\n\n";

            string replymessage = string.Empty;
            replymessage += $"{response.hi()},\n\n";
            replymessage += $"{response.imyourpatronus()}\n";
            replymessage += $"{response.currentlymyskillsare()}:\n";
            replymessage += abilities;
            replymessage += $"{response.bearwithme()}";
            return replymessage;
        }

        internal static string packagecontent()
        {
            string[] responsemessage =
            {
                "Check that you have all the parts of the package we sent. This is what's supposed to be in there",
                "Check that you got all the parts we sent. This is what's supposed to be in the package",
                "Please check that you have all the parts of the package we sent. This is what's supposed to be in there",
                "Please check that you have all the parts of the package we sent. This is what's supposed to be in the package",
                "Please check that you got all the parts in the package. This is what's supposed to be in there",
                "Please check that you got all the parts. This is what's supposed to be in the package",
                "Please check that we sent all the parts of the package. This is what's supposed to be in there",
                "Please check that we sent all the parts. This is what's supposed to be in the package"
            };
            return chooserandom(responsemessage);
        }

        public static string introPart1()
        {
            string[] responsemessage =
            {
                "Happy to see you.",
                "Glad to see you.",
                "Nice to meet you.",
                "Hey!",
                ";-)"
            };
            return chooserandom(responsemessage);
        }
        public static string introPart2()
        {
            string[] responsemessage =
            {
                "Ask what you want, and I'll do my best.",
                "What can I help you with today?",
                "Can I be of assistance?",
                "What can I do for you today?",
                "What would you like me do for you today?",
                "Anything particular I can do for you today?"
            };
            return chooserandom(responsemessage);
        }
        public static string introPart3()
        {
            string[] responsemessage =
            {
                "I'm here for you, learning new things as fast as I can.",
                "I learn new things almost every day, trying to help.",
                "My purpose in life - if I can say that - is to help you. And I always try to improve.",
                "I'm here to help you, and I learn from the feedback I get as well.",
                "I'm here to help, and I'm learning new things almost daily."
            };
            return chooserandom(responsemessage);
        }
        public static string isthisright()
        {
            string[] responsemessage =
            {
                "Is this right?",
                "Is this correct?",
                "Did I get this right?",
                "Correct?",
                "Was this what you told me?"
            };
            return chooserandom(responsemessage);
        }

        #endregion
        #region l-p strings
        public static string letshelp()
        {
            string[] responsemessage = {
                "Let's see if I can help then",
                "OK, I'll try to help",
                "I'll try to help then",
                "OK. I'll do what I can ;-)"};
            return chooserandom(responsemessage);
        }
        public static string moveon()
        {
            string[] responsemessage = {
                "Great. Let's move on",
                "Gotcha, now the next step",
                "OK, let's continue",
                "OK. Next step please :-)"};
            return chooserandom(responsemessage);
        }
        public static string nochangesmade()
        {
            string[] responsemessage = {
                "Ok! I didn't change anything. Let's try from the start.",
                "Gotcha, didn't change anything",
                "OK, I left everything as it was",
                "OK. I left things untouched"};
            return chooserandom(responsemessage);
        }
        public static string noproblem()
        {
            string[] responsemessage = { "Ok! No problem :-)", ":-) No problem!", "Gotcha!", "Okiedokie! Thanks again.", "OK! Thanks anyway :-)" };
            return chooserandom(responsemessage);
        }
        public static string noswedish()
        {
            string[] responsemessage = {
                "Låt mig gå över till engelska. Jag är inte så bra på svenska ännu.",
                "Jag är ledsen, men jag måste byta till engelska. Svenska ska jag lära mig snart",
                "Oj då. Svenska är tufft för mig - ett litet tag till. Jag byter till engelska nu.",
                "Hoppas det är OK med engelska. Jag är inte tillräckligt bra på svenska ännu.",
                "Min svenska är lite begränsad än så länge, så låt mig fortsätta på engelska."};
            return chooserandom(responsemessage);
        }
        public static string onlyyesornoplease()
        {
            string[] responsemessage = {
                "Apologies for being a bit formal, but I only understand *yes* or *no* in this context. After all I am only a computer",
                "I'm all ears, but my ears are limited to *yes* or *no* in this context",
                "*Yes* or *No* please. I'm only a computer, and need your clear guidance here ;-)",
                "I'm sorry, *yes* or * no* are the only options that work for me here"};
            return chooserandom(responsemessage);
        }
        public static string providefeedback()
        {
            string[] responsemessage = {
                "So what did you want to tell me?",
                "I'm all ears",
                "Excited. Your feedback is what makes me better. Please go ahead",
                "I love feedback, but it's always a bit scary. What did you want to tell me?"};
            return chooserandom(responsemessage);
        }
        public static string putintouch()
        {
            string[] responsemessage = {
                "If not, I'll put you in touch with someone that can, so just ask what you need!",
                "If I can't help you, I'll connect you to someone that can, so ask whatever you need me to help you with",
                "I'll connect you to someone that can, if I can't, so no worries. Just ask me what you want me to help you with",
                "If not, I'll help you talk to someone that can. But do give me a chance first! ;-) Ask me about what's bothering you"};
            return chooserandom(responsemessage);
        }
        #endregion
        #region r-u strings
        public static string retry()
        {
            string[] responsemessage = {
            "Please try again!",
            "Didn't get that. Try again please!",
            "OOOps, I didn't understand. Can you try again please?",
            "Try again, please!" };
            return chooserandom(responsemessage);
        }
        public static string routerhelp()
        {
            string[] responsemessage = {
                "OK, so you wanted help installing your broadband router, right?",
                "Just checking: Did you want help installing your broadband router?",
                "Did I get this right? You wanted help installing your broadband router, didn't you?",
                "I'll try to help installing your broadband router. Was that what you wanted?"};
            return chooserandom(responsemessage);
        }
        public static string thanksandbye()
        {
            string[] responsemessage = {
                "Thank you - again! You can always see what I am up to and learning next on my [facebook page](https://www.facebook.com/telenorpatronus/).",
                "Thanks again! On my [facebook page](https://www.facebook.com/telenorpatronus/) you can always see what I am up to.",
                "Thank you - again! You can always see what I'm up to and learning next on my facebook page.",
                "Thanks again! On my [facebook page](https://www.facebook.com/telenorpatronus/) you can always see what I'm up to.",
                "Thank you - again! I'm always learning new stuff. On my [facebook page](https://www.facebook.com/telenorpatronus/) the's a list of my priorities.",
                "Thanks again! On my [facebook page](https://www.facebook.com/telenorpatronus/) you can always see what I'm up to."};
            return chooserandom(responsemessage);
        }
        public static string thanksanyway()
        {
            string[] responsemessage = {
                "OK, thanks anyway! I enjoyed talking to you.",
                "Oh, ok, thanks anyway. It was nice chatting with you",
                "OK, I'll survive ;-) Nice talking to you",
                "Okie, I hear you. We'll meet again soon, hopefully ;-)"};
            return chooserandom(responsemessage);
        }
        public static string thanksforfeedback()
        {
            string[] responsemessage = {
                "Thanks. It really helps to get your feedback",
                "Thank you. All feedback is valuable",
                "Thanks. Feedback is what makes me better",
                "Thanks, I love feedback"};
            return chooserandom(responsemessage);
        }

        public static string thankyou()
        {
            string[] responsemessage = {
                "Thanks! Most appreciated.",
                "Thanks so much!",
                "Thank you so much :-)",
                "Thanks! I really appreciate that."};
            return chooserandom(responsemessage);
        }
        public static string tryagain()
        {
            string[] responsemessage = {
                "Not quite sure what you meant, could you try again?",
                "Not sure what you meant there, would you try again with different wording?",
                "Not quite sure what you meant, can you help me? Try again, please",
                "Not quite I got that, could you help me? Try again, please"};
            return chooserandom(responsemessage);
        }
        
        #endregion
        #region v-z strings
        public static string verifygeneric()
        {
            string[] responsemessage = {
                "Is that right?",
                "Is that correct?",
                "Do we have the same view?",
                "OK?"};
            return chooserandom(responsemessage);
        }
        public static string verifyrouter()
        {
            string[] responsemessage = {
                "Is that right?",
                "Is that the one you're using?",
                "Are you using it?",
                "Is that the one we're working with now?"};
            return chooserandom(responsemessage);
        }
        public static string voicemailoff(string pno)
        {
            string[] responsemessage = {
                $"OK, I turned off voicemail for {pno}. Happy to help!",
                $"OK, turned off the {pno} voicemail. Glad to help!",
                $"OK, turned off the {pno} voicemail. Happy to help!",
                $"OK, I turned off voicemail for {pno}. Glad to be of service!"};
            return chooserandom(responsemessage);
        }
        public static string voicemailon(string pno)
        {
            string[] responsemessage = {
                $"OK, calls to {pno} are now redirected to the voice mailbox. Happy to help!",
                $"OK, Voice mail is now activated for {pno}. Happy to help!",
                $"OK, calls to {pno} are now redirected to the voice mailbox. Glad to help!",
                $"OK, calls to {pno} are now sent to the voice mailbox. Glad to be of service!"};
            return chooserandom(responsemessage);
        }
        public static string youredoneconnectingbroadband()
        {
            string[] responsemessage = {
                "For now, you can use any of the yellow connections. Plug in your local network or a computer",
                "Now, just plug in to any of the yellow connections. Local network or a computer doesn't matter",
                "Now, plug in to one of the yellow connections - local network or a computer doesn't matter",
                "Plug in to any of the yellow connections now . You can connect your local network or a computer. Both should work now"};
            return chooserandom(responsemessage);
        }
        public static string youredonewithbroadband()
        {
            string[] responsemessage = {
                "Great! We're done. Enjoy your Internet connection",
                "Wonderful! Work completed. Enjoy Internet ;-)",
                "Done! :-) Have fun with your Internet",
                "Okiedokie. Enjoy your Internet!" }; 
            return chooserandom(responsemessage);
        }
        public static string yourewelcome()
        {
            string[] responsemessage = {
                ":-) You're welcome",
                "You're welcome!",
                "You're welcome :-)",
                "You're welcome. You're most kind"};
            return chooserandom(responsemessage);
        }
        public static string yourrouteris(string userinput)
        {
            string[] responsemessage = {
                $"OK, so your router is a *{userinput}*",
                $"OK, so you have a *{userinput}*",
                $"OK. I'll try setting up your *{userinput}*"};
            return chooserandom(responsemessage);
        }
        #endregion

        // fixed text strings
        // complexities added in preparation for parametrization for languages and personalities

        internal static string _bookconferenceroom()
        {
            string responsemessage = "...Book Conference Rooms... I hope to lean that soon";
            return responsemessage;
        }
        internal static string _bookconfroomequipment()
        {
            string responsemessage = "...Book Conference Rooms Equipment... Sorry, can't do that yet";
            return responsemessage;
        }
        internal static string _callsupport()
        {
            string responsemessage = "For now, I need to ask you to call +46 20 22 22 22 - my human partner, customer service . In the future I wil be able to connect you directly or aske them to call you up.";
            return responsemessage;
        }

        internal static string _cancelsubscription()
        {
            string responsemessage = "...Cancel Subscription... I will learn that later";
            return responsemessage;
        }
        internal static string _checkresult()
        {
            string responsemessage = "...Check Result... I am still learning how to do that";
            return responsemessage;
        }
        public static string _city(string city)
        {
            string responsemessage = $"City: { city }";
            return responsemessage;
        }
        public static string _confirm()
        {
            string responsemessage = "OK, this what I got...\n\n";
            return responsemessage;
        }
        public static string _connecttolanheader()
        {
            string responsemessage = "Connect local network";
            return responsemessage;
        }
        public static string _connecttonetworkheader()
        {
            string responsemessage = "Connect the network";
            return responsemessage;
        }
        public static string _connecttopowerheader()
        {
            string responsemessage = "Connect power";
            return responsemessage;
        }
        public static string _fiber()
        {
            string responsemessage = "Fiber";
            return responsemessage;
        }
        internal static string _getmeetingparticipants()
        {
            string responsemessage = "...Get Conference Participants... Sorry, can't do that yet";
            return responsemessage;
        }
        public static string _howdoyouconnectrouter()
        {
            string responsemessage = "How do you connect the router?";
            return responsemessage;
        }
        internal static string _icanchangeaddress()
        {
            string responsemessage = "Currently you can test to change your address. I don't do anything with the information, my purpose in life is to test the dialog flow and see how we make it work well for you.";
            return responsemessage;
        }

        internal static string _icanhelpwithbroadband()
        {
            string responsemessage = "You can ask me for help with your broadband. I'm actually working on getting better at it right now. Check back every now and then and tell me what you think!";
            return responsemessage;
        }
        internal static string _icanhelpwithinvoice()
        {
            string responsemessage = "Well, you actually also can ask about an invoice, but that dialog is not very elaborate yet. I'm not very happy with how it works, but feel free to test it";
            return responsemessage;
        }
        public static string _invoice()
        {
            string responsemessage = "So you were wondering about your invoice. When I learn how to verify that you are actually you I will show you the invoice. My maker has that as a high priority. I don't want to share your secrets to the world. Your privacy is important to me";
            return responsemessage;
        }
        public static string _itsdone()
        {
            string responsemessage = "It's done";
            return responsemessage;
        }
        public static string _lan()
        {
            string responsemessage = "local network or device";
            return responsemessage;
        }
        public static string _network()
        {
            string responsemessage = "network";
            return responsemessage;
        }
        internal static string _newsubscription()
        {
            string responsemessage = "...New Subscription... Hmmm... I hope I learn that soon.";
            return responsemessage;
        }
        public static string _phonesocket()
        {
            string responsemessage = "Phone socket";
            return responsemessage;
        }
        internal static string _pleasecheck()
        {
            string responsemessage = "Please check!";
            return responsemessage;
        }

        public static string _power()
        {
            string responsemessage = "power";
            return responsemessage;
        }
        public static string _streetaddress(string streetaddress)
        {
            string responsemessage = $"Street: { streetaddress }\n\n";
            return responsemessage;
        }
        public static string _tvsocket()
        {
            string responsemessage = "TV socket";
            return responsemessage;
        }
        internal static string _underconstruction()
        {
            string responsemessage = "I'm still learning this, so don't be alarmed if it looks weird. It doesn't work yet anyway";
            return responsemessage;
        }
        public static string _yes()
        {
            string responsemessage = "Yes";
            return responsemessage;
        }
        public static string _youalsotoldme()
        {
            string responsemessage = "You also told me";
            return responsemessage;
        }
        internal static string _youcangivemefeedback()
        {
            string responsemessage = "You can also give me feedback. Why not tell me what you would like me to learn next?";
            return responsemessage;
        }
        public static string _zipcode(string zip)
        {
            string responsemessage = $"Zip code: { zip }\n\n";
            return responsemessage;
        }
    }
}