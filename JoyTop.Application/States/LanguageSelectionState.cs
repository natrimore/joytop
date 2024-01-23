using JoyTop.Application.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JoyTop.Application.States
{
    public class LanguageSelectionState : IState
    {
        private string userLanguage = "Default"; // Default language
        public async Task ExecuteAsync(Message message, ITelegramBotClient botClient, Context context, CancellationToken cancellationToken = default)
        {
            if (message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Welcome! Please choose your language:", cancellationToken: cancellationToken);
                await ShowLanguageOptions(message.Chat.Id, botClient, cancellationToken);
            }
            else if (message.Text == "1" || message.Text == "2" || message.Text == "3")
            {
                // User selected a language
                int selectedLanguage = int.Parse(message.Text);
                SetUserLanguage(selectedLanguage);

                // Save the language and proceed to the next state
                SaveUserLanguage();
            }
            else
            {
                // Invalid input, show language options again
                await botClient.SendTextMessageAsync(message.Chat.Id, "Invalid input. Please choose your language:", cancellationToken: cancellationToken);
                await ShowLanguageOptions(message.Chat.Id, botClient, cancellationToken);
            }
        }
        private void SetUserLanguage(int selectedLanguage)
        {
            // Set the user's language based on the selected option
            var userLanguage = selectedLanguage switch
            {
                1 => "uz",
                2 => "en",
                3 => "ru",
                _ => throw new ArgumentNullException(nameof(selectedLanguage))
            };
        }
        private async Task ShowLanguageOptions(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            // Display language options
            await botClient.SendTextMessageAsync(chatId,
                "1: English\n2: Spanish\n3: French\n",
                cancellationToken: cancellationToken);
        }
        private void SaveUserLanguage()
        {
            UserState.Instance.Language = userLanguage;
        }
        public Task ShowCommandAsync(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public class UserState
        {
            public static UserState Instance { get; } = new UserState();

            public string Language { get; set; } = "Default";
        }
    }
}
