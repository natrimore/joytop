using JoyTop.Application.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JoyTop.Application.States
{
    public class ContactGettingState : IState
    {
        private string userLanguage = "Default"; // Default language

        public async Task Execute(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken = default)
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

                // Request user contact information
                await RequestContact(message, botClient, cancellationToken);
            }
            else
            {
                // Invalid input, show language options again
                await botClient.SendTextMessageAsync(message.Chat.Id, "Invalid input. Please choose your language:", cancellationToken: cancellationToken);
                await ShowLanguageOptions(message.Chat.Id, botClient, cancellationToken);
            }
        }

        private async Task ShowLanguageOptions(long chatId, ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            // Display language options
            await botClient.SendTextMessageAsync(chatId,
                "1: English\n2: Spanish\n3: French\n",
                cancellationToken: cancellationToken);
        }

        private void SetUserLanguage(int selectedLanguage)
        {
            // Set the user's language based on the selected option
            switch (selectedLanguage)
            {
                case 1:
                    userLanguage = "English";
                    break;
                case 2:
                    userLanguage = "Spanish";
                    break;
                case 3:
                    userLanguage = "French";
                    break;
                    // Add more cases for additional languages if needed
            }
        }

        private void SaveUserLanguage()
        {
            // Save the user's language to the database or any other storage mechanism
            // For now, just updating the UserState with the selected language
            UserState.Instance.Language = userLanguage;
        }

        private async Task RequestContact(Message message, ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            var requestContactKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Share Contact") { RequestContact = true }
            });

            await botClient.SendTextMessageAsync(message.Chat.Id,
                "To continue, please share your contact information by clicking the button below.",
                replyMarkup: requestContactKeyboard,
                cancellationToken: cancellationToken);
        }
    }

    public class UserState
    {
        // Assuming a singleton for maintaining user state
        public static UserState Instance { get; } = new UserState();

        // Additional state properties can be added here
        public string Language { get; set; } = "Default";
    }
}
