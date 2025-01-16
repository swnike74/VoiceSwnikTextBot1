using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace VoiceSwnikTextBot1.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            //await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение", cancellationToken: ct);

            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" 1)Посчет символов в тексте" , $"символы"),
                        InlineKeyboardButton.WithCallbackData($" 2) Вычисление суммы чисел" , $"сумма")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Наш бот: 1) посчитывает кол-во символов.</b> {Environment.NewLine}" +
                        $"2)Вычисляет сумму чисел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    //await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Отправьте аудио для превращения в текст.", cancellationToken: ct);
                    break;
            }
        }
    }
}
