using JoyTop.Application.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.States
{
    public class LanguageSelectionState : IState
    {
        public Task ExecuteAsync(Message message, ITelegramBotClient botClient, Context context, CancellationToken cancellationToken = default)
        {
            if (message.Text == "/start")
            {
                //TODO: Ask choosing language
            }
            else if (message.Text == "uz" || message.Text == "ru")
            {
                 //TODO: Invalid operation
            }
            else
            {
                
            }

            context.TransitionTo(new LanguageSelectionState());

            return Task.CompletedTask;
        }

        public Task ShowCommandAsync(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
