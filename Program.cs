using GuessTheNumber.Implementation;
using GuessTheNumber.Interfaces;
using GuessTheNumber.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuessTheNumber;

/// <summary>
/// Main program class.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        var hostBuilder = Host.CreateApplicationBuilder();
        hostBuilder.Services.AddSingleton<IScorable, Score>()
                            .AddSingleton<IGuessable, ThinkRandom>()
                            .AddSingleton<IGuessService, GuessService>();
        hostBuilder.Configuration.AddJsonFile("settings.json", optional: true, reloadOnChange: true);
        var serviceProvider = hostBuilder.Services.BuildServiceProvider();

        IGuessService guessService = serviceProvider.GetRequiredService<IGuessService>();
        guessService.TryGuess();
    }
}
