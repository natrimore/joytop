using JoyTop.Application.Abstractions;
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
        private readonly ICommandService _commandService;
        
        public Bot(ICommandService commandService, BotConfiguration botConfiguration)
        {
            _commandService = commandService
                ?? throw new ArgumentNullException(nameof(commandService));

            if (botConfiguration == null || string.IsNullOrEmpty(botConfiguration.BotToken))
                throw new ArgumentNullException("Token was null");

            _telegramBotClient = new TelegramBotClient(botConfiguration.BotToken);
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
            foreach (var command in _commandService.Get())
            {
                if (command.Contains(update))
                    await command.ExecuteAsync(update.Message, botClient);
            }
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
