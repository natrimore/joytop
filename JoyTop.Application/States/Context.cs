using JoyTop.Application.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.States
{
    public class Context
    {
        private IState _state;

        public Context(IState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public async Task DoRequestAsync(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
        {
            await _state.ExecuteAsync(message, botClient, this, cancellationToken);
        }

        public Task ShowInterfaceAsync(long chatId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void TransitionTo(IState state)
        {
            _state = state;
        }

        public IState GetCurrentState()
        {
            return _state;
        }
    }
}
