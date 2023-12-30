using JoyTop.Application.Abstractions;
using JoyTop.Application.Services;
using JoyTop.Bot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets(typeof(Program).GetTypeInfo().Assembly, optional: false);

        var config = configuration.Build();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICommandService, CommandService>()
            .AddSingleton<IBot, Bot>()
            .AddSingleton<BotConfiguration>(sp =>
            {
                return new BotConfiguration
                {
                    BotToken = config.GetSection("Token").Value ?? string.Empty
                };
            })
            .BuildServiceProvider();

        var bot = serviceProvider.GetRequiredService<IBot>();

        await bot.Execute();

        Console.ReadKey();
    }
}