using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.Abstractions
{
    public interface IState
    {
        Task ShowCommand(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken = default);
        Task Execute(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default);
    }
}
