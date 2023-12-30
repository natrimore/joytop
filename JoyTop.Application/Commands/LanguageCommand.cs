using JoyTop.Application.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace JoyTop.Application.Commands
{
    public class LanguageCommand : BaseCommand
    {
        private const string CONTENT = "Please send a contact";
        public override string Name => "uz;ru;en";

        public override async Task ExecuteAsync(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
        {
            ReplyKeyboardMarkup keyboards = new(new[]
            {
                new KeyboardButton("Contact") 
                { 
                    RequestContact = true 
                },
            })
            {
                ResizeKeyboard = true
            };

            await botClient.DeleteMessageAsync(message.Chat, message.MessageId, cancellationToken);

            await botClient.SendTextMessageAsync(message.Chat.Id, CONTENT, 
                replyMarkup: keyboards, cancellationToken: cancellationToken);
        }

        public override bool Contains(Update update)
        {
            if (update?.Message?.Text is not { } text)
                return false;

            return Name.Split(';').Any(x => x.Contains(text, StringComparison.OrdinalIgnoreCase));
        }
    }
}
