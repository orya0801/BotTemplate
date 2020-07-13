using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotTemplate.Models.Commands
{
    public class Text
    {
        public string Name => "text";

        public bool Contains(Message message)
        {
            return false;
        }

        public async Task<string> Execute(Message message, TelegramBotClient botClient, string lastBotMessage)
        {
            if (lastBotMessage == "Во сколько планируете прийти?")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Сколько вас будет?)");
                return "Сколько вас будет?)";
            }
            await botClient.SendTextMessageAsync(message.Chat.Id, "Oops, Я Вас Не Понимать - Выберите одну из доступных команд");
            return "Oops, Я Вас Не Понимать - Выберите одну из доступных команд";
        }
    }
}
