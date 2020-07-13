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

            //var keyboardButton_day = new InlineKeyboardButton
            //{
            //    Text = "День",
            //};

            //var keyboardButton_evening = new InlineKeyboardButton();
            //keyboardButton_evening.Text = "Вечер";
            //var keyboardButton_night = new InlineKeyboardButton();
            //keyboardButton_night.Text = "Ночь";

            //List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>
            //    {
            //        keyboardButton_day
            //        //keyboardButton_evening
            //        //keyboardButton_night
            //    };

            //InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);           

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: answer,
                disableWebPagePreview: false,
                //replyMarkup: keyboard,
                parseMode: ParseMode.Default);
        }
    }
}
