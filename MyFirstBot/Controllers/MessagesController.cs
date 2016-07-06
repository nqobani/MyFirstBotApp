using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace MyFirstBot
{
    //[BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 
        String[] goodMoods = {"happy","over the moon","accepted","Calm","fine","gud", "good", "satisfied", "okay", "relaxed", "relieved" };
        String[] badMoods = {"sad","angry","bored","cold","dark","drunk","sleepy","lone", "disappointed", "hungry","mad" };
        String[] solutions = { "Visiting someone you that you enjoy spending time with might help, or anything-(only the good things) else that can keep you busy",
            "You need to be calm boss, Being angry is not a good feeling for people/human beings because it might lead to bad staff...",
            "That cames and go, just be you...",
            "Get yourself warmer clothes or any else that can get you to the right mood...",
            "Sorry Idon't mean to be a bad friend its just that I don't know any thing about that...",
            "Just go home, sleeping migh thelpt a lot...",
            "Get some energy drink they usually help a lot...",
            "If you have a friend or anyone that you enjoy talking to, just give that person a call. Or just have fun wit me...",
            "Just be strong, that feeling will pass in a moment...",
            "Get yourself a drink, but not that one that will make you even worse..." };


        String[] questtions = { "public taxi", "private taxi"};

        int taxi = -1;
        String[] locations = { };
        double []publicTransportCosts = { 14.00,16.00,10.00,16.00};
        double[] privateTransportCosts = { 114.00, 116.00, 110.00, 116.00 };

        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                if((message.Text.ToLower().Contains("hi")|| (message.Text.ToLower().Contains("hello")))&&((message.Text.ToLower().Contains("and you") || message.Text.ToLower().Contains("are you"))))
                {
                    Random rand = new Random();
                    int num = rand.Next(0, 10);
                    return message.CreateReplyMessage($"Hi, I'm feeling "+ goodMoods[num]+", and you?");
                }
                else if((message.Text.ToLower().Contains("hi") || (message.Text.ToLower().Contains("hello"))))
                {
                    //Random rand = new Random();
                    //int num = rand.Next(0, 10);
                    return message.CreateReplyMessage($"Hi, How are you?");
                }
                else if (((message.Text.ToLower().Contains("happy") || message.Text.ToLower().Contains("over the moon") || message.Text.ToLower().Contains("accepted") || message.Text.ToLower().Contains("calm") || message.Text.ToLower().Contains("fine") || message.Text.ToLower().Contains("gud") || message.Text.ToLower().Contains("good") || message.Text.ToLower().Contains("satisfied") || message.Text.ToLower().Contains("okey") || message.Text.ToLower().Contains("relaxed") || message.Text.ToLower().Contains("relieved")) && (message.Text.ToLower().Contains("and you") || message.Text.ToLower().Contains("are you"))) &&(message.Text.ToLower().Contains("not")))
                {
                    String selectSolutoin = "";
                    for (int i = 0; i < 11; i++)
                    {
                        if (message.Text.ToLower().Contains(goodMoods[i]))
                        {
                            selectSolutoin = solutions[i];
                        }
                    }
                    Random rand = new Random();
                    int num = rand.Next(0, 10);
                    selectSolutoin+=" You just changed my mood now  I'm feeling " + badMoods[num] + ". To you";
                    return message.CreateReplyMessage($"" + selectSolutoin + ", What can i do for you?");
                }
                else if (((message.Text.ToLower().Contains("happy") || message.Text.ToLower().Contains("over the moon") || message.Text.ToLower().Contains("accepted") || message.Text.ToLower().Contains("calm") || message.Text.ToLower().Contains("fine") || message.Text.ToLower().Contains("gud") || message.Text.ToLower().Contains("good") || message.Text.ToLower().Contains("satisfied") || message.Text.ToLower().Contains("okey") || message.Text.ToLower().Contains("relaxed") || message.Text.ToLower().Contains("relieved"))) && (message.Text.ToLower().Contains("not")))
                {
                    String selectSolutoin = "";
                    for (int i = 0; i < 11; i++)
                    {
                        if (message.Text.ToLower().Contains(goodMoods[i]))
                        {
                            selectSolutoin = solutions[i];
                        }
                    }
                    return message.CreateReplyMessage($"" + selectSolutoin + ", What can i do for you?");
                }
                else if (message.Text.ToLower().Contains("sad") || message.Text.ToLower().Contains("angry") || message.Text.ToLower().Contains("bored") || message.Text.ToLower().Contains("cold") || message.Text.ToLower().Contains("dark") || message.Text.ToLower().Contains("drunk") || message.Text.ToLower().Contains("sleepy") || message.Text.ToLower().Contains("lone") || message.Text.ToLower().Contains("disappointed") || message.Text.ToLower().Contains("hungry") || message.Text.ToLower().Contains("mad"))
                {
                    String selectSolutoin = "";
                    for(int i=0;i<11;i++)
                    {
                        if(message.Text.ToLower().Contains(badMoods[i]))
                        {
                            selectSolutoin = solutions[i];
                        }
                    }
                    return message.CreateReplyMessage($""+ selectSolutoin + ", What can i do for you?");
                }
                else if((message.Text.ToLower().Contains("happy")|| message.Text.ToLower().Contains("over the moon")|| message.Text.ToLower().Contains("accepted")|| message.Text.ToLower().Contains("calm")|| message.Text.ToLower().Contains("fine")|| message.Text.ToLower().Contains("gud") || message.Text.ToLower().Contains("good") || message.Text.ToLower().Contains("satisfied") || message.Text.ToLower().Contains("okey")|| message.Text.ToLower().Contains("relaxed") || message.Text.ToLower().Contains("relieved"))&& (message.Text.ToLower().Contains("and you")|| message.Text.ToLower().Contains("are you")))
                {
                    Random rand = new Random();
                    int num = rand.Next(0, 10);
                    return message.CreateReplyMessage($"I'm feeling " + goodMoods[num] + ", what can I do for you?");
                }
                else if ((message.Text.ToLower().Contains("happy") || message.Text.ToLower().Contains("over the moon") || message.Text.ToLower().Contains("accepted") || message.Text.ToLower().Contains("calm") || message.Text.ToLower().Contains("fine") || message.Text.ToLower().Contains("gud") || message.Text.ToLower().Contains("good") || message.Text.ToLower().Contains("satisfied") || message.Text.ToLower().Contains("okey") || message.Text.ToLower().Contains("relaxed") || message.Text.ToLower().Contains("relieved")))
                {
                    return message.CreateReplyMessage($"I wish to be you, what can I do for you?");
                }
                else if (message.Text.ToLower().Contains("taxi") && message.Text.ToLower().Contains("public"))
                {
                    taxi = 0;
                    return message.CreateReplyMessage($"From where?\n 1)Durban to UMHLANGA R14.00\n 2)Durban to UMLAZI R16.00\n 3) UMHLANGA to Durban R10.00\n 4)UMLAZI to Durban R16.00");
                }
                else if (message.Text.ToLower().Contains("taxi") && message.Text.ToLower().Contains("private"))
                {
                    taxi = 1;
                    return message.CreateReplyMessage($"From where?\n 1)Durban to UMHLANGA R114.00\n 2)Durban to UMLAZI R116.00\n 3) UMHLANGA to Durban R110.00\n 4)UMLAZI to Durban R116.00");
                }
                else if (message.Text.ToLower().Contains("public"))
                {
                    taxi = 0;
                    return message.CreateReplyMessage($"From where?\n 1)Durban to UMHLANGA R14.00\n 2)Durban to UMLAZI R16.00\n 3) UMHLANGA to Durban R10.00\n 4)UMLAZI to Durban R16.00");
                }
                else if (message.Text.ToLower().Contains("private"))
                {
                    taxi = 1;
                    return message.CreateReplyMessage($"From where?\n 1)Durban to UMHLANGA R114.00\n 2)Durban to UMLAZI R116.00\n 3) UMHLANGA to Durban R110.00\n 4)UMLAZI to Durban R116.00");
                }
                else if(message.Text.ToLower().Contains("taxi")|| message.Text.ToLower().Contains("transport"))
                {
                    return message.CreateReplyMessage($"You need a Public or Private taxi?");
                }
                else
                {
                    return message.CreateReplyMessage($"My Developers are still working on that ability.");
                }
                
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}