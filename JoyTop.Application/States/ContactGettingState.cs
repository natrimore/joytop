using JoyTop.Application.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JoyTop.Application.States
{
    public class ContactGettingState : IState
    {
        public async Task ExecuteAsync(Message message, ITelegramBotClient botClient, Context context, CancellationToken cancellationToken = default)
        {
            await RequestContact(message, botClient, cancellationToken);
        }

        public Task ShowCommandAsync(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private async Task RequestContact(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            var requestContactKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Share Contact") { RequestContact = true }
            });

            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                "To continue, please share your contact information by clicking the button below.",
                replyMarkup: requestContactKeyboard,
                cancellationToken: cancellationToken
            );
        }
    }
}
