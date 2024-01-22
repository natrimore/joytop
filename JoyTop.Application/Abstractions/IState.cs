using JoyTop.Application.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.Abstractions
{
    public interface IState
    {
        Task ShowCommandAsync(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken = default);
        Task ExecuteAsync(Message message, ITelegramBotClient botClient, Context context, CancellationToken cancellationToken = default);
    }
}
