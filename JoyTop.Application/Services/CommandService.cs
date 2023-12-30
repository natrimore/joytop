using JoyTop.Application.Abstractions;
using JoyTop.Application.Commands;

namespace JoyTop.Application.Services
{
    public class CommandService : ICommandService
    {
        private readonly IReadOnlyCollection<BaseCommand> commands;

        public CommandService()
        {
            commands = new List<BaseCommand>
            {
                new StartCommand(),
                new LanguageCommand(),
            };
        }
        public IReadOnlyCollection<BaseCommand> Get() => commands;
    }
}
