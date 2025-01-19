using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using VoiceSwnikTextBot1.Services;

namespace VoiceSwnikTextBot1.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IProcessor _processor;
        private readonly UserSetting _userSetting;

        public TextMessageController(ITelegramBotClient telegramBotClient, IProcessor processor, UserSetting userSetting)
        {
            _telegramClient = telegramBotClient;
            _processor = processor;
            _userSetting = userSetting;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");

            switch (message.Text)
            {
                case "/start":
                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" 1) Посчет символов в тексте" , $"символы"),
                        InlineKeyboardButton.WithCallbackData($" 2) Вычисление суммы чисел" ,   $"сумма")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Наш бот:</b> {Environment.NewLine}1)Посчитывает кол-во символов.{Environment.NewLine}" +
                        $"2)Вычисляет сумму чисел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
                default:
                    if (_userSetting.UserChoice == "сумма")
                    {
                        int sumd = _processor.SumOfDigits(message.Text);
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Сумма чисел {sumd}", cancellationToken: ct);
                    }
                     else if (_userSetting.UserChoice == "символы")
                    {
                        int nums = _processor.NumOfSymbols(message.Text);
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"В Вашем сообщении {nums} символов", cancellationToken: ct);
                    }
                    else 
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Неразборчив формат сообщения", cancellationToken: ct);
                        break;
            }
        }
    }
}
