using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using BotTemplate.Models;
using _File = System.IO.File;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using BotTemplate.Models.Commands;
using Newtonsoft.Json.Bson;
using Telegram.Bot.Requests;
using System.IO;

namespace BotTemplate.Controllers
{
    [Route("api/message/update")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        //Dictionary<long, string> _lastBotMessage;
        Dictionary<long, string> _lastCommand;
        public object Chat { get; internal set; }

        public MessageController()
        {
            //_lastBotMessage = new Dictionary<long, string>();
            _lastCommand = new Dictionary<long, string>();
            //_lastBotMessage.Add(468043914, "");
            _lastCommand.Add(468043914, "");
        }


        [HttpGet]
        public IActionResult OnGet()
        {
            return Ok("Hello, it's my bot!");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    //if (!_lastBotMessage.ContainsKey(message.Chat.Id))
                    //{
                    //    _lastBotMessage.Add(message.Chat.Id, message.Text);
                    //    _lastCommand.Add(message.Chat.Id, message.Text);
                    //}
                    //else
                    //{
                    _lastCommand[message.Chat.Id] = message.Text;
                    //}
                    await command.Execute(message, botClient, _lastCommand[message.Chat.Id]);

                    return Ok();
                }
            }

            var currCommand = commands.FirstOrDefault(x => x.Name == _lastCommand[message.Chat.Id]);
            await currCommand.Execute(message, botClient, _lastCommand[message.Chat.Id]);

            return Ok();
        }

        private Dictionary<long, string> ReadData(string path)
        {
            var dict = _File.ReadLines(path)
                .Select(line => line.Split('\t'))
                .Where(arr => arr.Length == 2)
                .ToDictionary(arr => long.Parse(arr[0]), arr => arr[1]);

            
            return dict;
        }

        private void WriteData(string path, Dictionary<long, string> dict)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var kvp in dict)
                {
                    writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
                }
                writer.Close();
            }
        }
    }
}
