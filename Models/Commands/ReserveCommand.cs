using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTemplate.Models.Commands
{
    public class ReserveCommand : Command
    {
        public override string Name => @"/reserve";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient, string lastBotMessage)
        {
            var chatId = message.Chat.Id;
            string answer;

            answer = "Во сколько планируете прийти?";

            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("\U0001F3E0 Главная")
                    },
                    new[]
                    {
                        new KeyboardButton("\U0001F451 Ранк")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F45C Магазин")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F4D6 Помощь")
                    }
                }
            };

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: answer,
                disableWebPagePreview: false,
                replyMarkup: keyBoard,
                parseMode: ParseMode.Default);
        }
    }
}
