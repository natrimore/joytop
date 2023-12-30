using JoyTop.Application.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.States
{
    public class LanguageSelectionState : IState
    {
        public Task Execute(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
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

            return Task.CompletedTask;
        }
    }
}
