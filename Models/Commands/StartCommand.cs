﻿using BotTemplate.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotTemplate.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient,
            string lastCommand)
        {
            string answer = "Hallo I'm ASP.NET Core Bot";

            var chatId = message.Chat.Id;

            await botClient.SendTextMessageAsync(chatId, answer, parseMode: ParseMode.Default);
        }
    }
}
