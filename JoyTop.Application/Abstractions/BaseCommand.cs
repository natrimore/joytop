using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.Abstractions
{
    public abstract class BaseCommand
    {
        public abstract string Name { get; }

        public abstract Task ExecuteAsync(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default);

        public virtual bool Contains(Update update)
        {
            if (update?.Message?.Text is not { } text)
                return false;

            return text.Contains(Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
