using JoyTop.Application.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JoyTop.Application.Commands
{
    public class StartCommand : BaseCommand
    {
        private const string CONTENT = "Please select a default language";
        public override string Name => "/start";

        public override async Task ExecuteAsync(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
        {
            var chatId = message.Chat.Id;

            ReplyKeyboardMarkup keyboards = new(new[]
            {
                new KeyboardButton("uz"),
                new KeyboardButton("ru"),
                new KeyboardButton("en")
            })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(chatId, CONTENT, replyMarkup: keyboards);
        }
    }
}
