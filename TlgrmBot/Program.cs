using System;
using Telegram.Bot;


namespace TlgrmBot
{
    class Program
    {
        private static ITelegramBotClient botClient;
        private static string token = "1346705117:AAGWl2cAQ5rSWOGiF2JvIXfltsbTsMDS4Ws";
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(token) { Timeout = TimeSpan.FromSeconds(10)};

            botClient.OnMessage += BotOnMessageReceived;
            botClient.OnMessageEdited += BotOnMessageReceived;

            botClient.StartReceiving();
            Console.ReadLine();
            botClient.StopReceiving();
            /*var me = botClient.GetMeAsync().Result;
            var updates = botClient.GetUpdatesAsync();
            //var webhook = botClient.SetWebhookAsync();
            Console.WriteLine($"Bot Id: {me.Id} \n name:{me.FirstName}");

            //botClient.OnMessage += BotClient_OnMessage;
            botClient.OnMessage += BotClient_OnMessage;
            botClient.OnMessageEdited += BotClient_OnMessageEdited;
            botClient.SendTextMessageAsync(me.Id, "test");
            
            botClient.*/
        }

        private async static void BotOnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //throw new NotImplementedException();
            var message = e.Message;
            await botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
        }

        /*private static void BotClient_OnMessageEdited(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //throw new NotImplementedException();
            var text = e.Message.Text;
            var message = e.Message;
            //if (message?.Type == MessageType.TextMessage)
            //{
                await botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
            //}

            Console.WriteLine(text);
        }*/
    }
}
