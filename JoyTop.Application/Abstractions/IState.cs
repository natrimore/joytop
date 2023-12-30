using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.Abstractions
{
    public interface IState
    {
        Task Execute(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default);
    }
}
