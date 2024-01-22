using JoyTop.Application.Abstractions;
using JoyTop.Application.States;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace JoyTop.Bot
{
    public class Bot : IBot
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IStateManager _stateManager;

        public Bot(BotConfiguration botConfiguration, IStateManager stateManager)
        {
            if (botConfiguration == null || string.IsNullOrEmpty(botConfiguration.BotToken))
                throw new ArgumentNullException("Token was null");

            _telegramBotClient = new TelegramBotClient(botConfiguration.BotToken);

            _stateManager = stateManager ?? throw new ArgumentNullException(nameof(stateManager));
        }
        public async Task Execute(CancellationToken cancellationToken = default)
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            _telegramBotClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);

            var me = await _telegramBotClient.GetMeAsync(cancellationToken);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var userId = update.Message.From.Id;
            var chatId = update.Message.Chat.Id;

            var currentUserState = await _stateManager.GetUserStateAsync(userId, cancellationToken);

            var context = new Context(currentUserState);

            await context.DoRequestAsync(update.Message, botClient, cancellationToken);

            await _stateManager.SetUserStateAsync(userId, context.GetCurrentState(), cancellationToken);

            await context.ShowInterfaceAsync(chatId, cancellationToken);
        }

        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);

            return Task.CompletedTask;
        }
    }
}
