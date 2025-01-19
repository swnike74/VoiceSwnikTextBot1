using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using VoiceSwnikTextBot1.Services;

namespace VoiceSwnikTextBot1.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly UserSetting _userSetting;
        public InlineKeyboardController(ITelegramBotClient telegramBotClient, UserSetting userSetting)
        {
            _telegramClient = telegramBotClient;
            _userSetting = userSetting;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;

            Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку");
            //await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку", cancellationToken: ct);

            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            //await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку {callbackQuery.Data}", cancellationToken: ct);
            _userSetting.UserChoice = callbackQuery.Data;
            switch (callbackQuery.Data)
            {
                case "символы":
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Введите символы", cancellationToken: ct);
                    break;
                case "сумма":
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Введите цифры через пробел", cancellationToken: ct);
                    break;
                default:
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Error", cancellationToken: ct);
                    break;

            }
            
        }
    }
}
