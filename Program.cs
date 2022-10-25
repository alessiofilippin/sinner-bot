using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using SinnerBot.Controllers;
using System.IO;
using System.Numerics;

public class Program
{
    private DiscordSocketClient _client;

    public static Task Main(string[] args) => new Program().MainAsync();

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;

        //  You can assign your bot token to a string, and pass that in to connect.
        //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
        var token = "MTAzMzM5NDAxODQ1OTA3NDY1MA.G8fSNv.-Dfp3y-yOz8q1pPoG02Ha8MwCFfPU6atHMzAM0";

        // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
        // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
        // var token = File.ReadAllText("token.txt");
        // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.Ready += Client_Ready;
        _client.SlashCommandExecuted += SlashCommandHandler;

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    public async Task Client_Ready()
    {
        await Log(new LogMessage(LogSeverity.Debug, "Custom", "Start Init for Slash Commands", null));
        string path = AppDomain.CurrentDomain.BaseDirectory + @"/" + "instancesData.json";
        await Log(new LogMessage(LogSeverity.Debug, "Custom", path, null));
        // Let's do our global command
        var majorArcanaCommand = new SlashCommandBuilder();
        majorArcanaCommand.WithName("maggiore");
        majorArcanaCommand.WithDescription("Estai un Arcano Maggiore. Tarocco.");
        majorArcanaCommand.AddOption("numero", ApplicationCommandOptionType.Integer, "Numero di arcani da estrarre.", isRequired: false);
        majorArcanaCommand.AddOption("mazzo", ApplicationCommandOptionType.Integer, "Numero del mazzo da cui estrarre l'arcano.", isRequired: false);

        var minorArcanaCommand = new SlashCommandBuilder();
        minorArcanaCommand.WithName("minore");
        minorArcanaCommand.WithDescription("Estai un Arcano Minore. Carta da Gioco.");
        minorArcanaCommand.AddOption("numero", ApplicationCommandOptionType.Integer, "Numero di arcani da estrarre.", isRequired: false);
        minorArcanaCommand.AddOption("mazzo", ApplicationCommandOptionType.Integer, "Numero del mazzo da cui estrarre l'arcano.", isRequired: false);

        var initDecksCommand = new SlashCommandBuilder();
        initDecksCommand.WithName("crea-mazzi");
        initDecksCommand.WithDescription("Crea una coppia di mazzi per Giocatore. Minore e Maggiore.");
        initDecksCommand.AddOption("numero", ApplicationCommandOptionType.Integer, "Numero di mazzi da inizializzare. Solitamente uno per giocatore.", isRequired: false);

        var decksReportCommand = new SlashCommandBuilder();
        decksReportCommand.WithName("stato-mazzi");
        decksReportCommand.WithDescription("Scrivi stato mazzi.");

        try
        {
            // With global commands we don't need the guild.
            await _client.CreateGlobalApplicationCommandAsync(majorArcanaCommand.Build());
            await _client.CreateGlobalApplicationCommandAsync(minorArcanaCommand.Build());
            await _client.CreateGlobalApplicationCommandAsync(initDecksCommand.Build());
            await _client.CreateGlobalApplicationCommandAsync(decksReportCommand.Build());
        }
        catch (ApplicationCommandException exception)
        {
            // If our command was invalid, we should catch an ApplicationCommandException. This exception contains the path of the error as well as the error message. You can serialize the Error field in the exception to get a visual of where your error is.
            var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
            
            // You can send this error somewhere or just print it to the console, for this example we're just going to print it.
            Console.WriteLine(json);
        }
    }

    private async Task SlashCommandHandler(SocketSlashCommand command)
    {
        switch(command.Data.Name)
        {
            case "maggiore":
                await HandleMaggioreCommand(command);
                break;
            case "minore":
                await HandleMinoreCommand(command);
                break;
            case "crea-mazzi":
                await HandleInitDecksCommand(command);
                break;
            case "stato-mazzi":
                await HandledecksReportCommand(command);
                break;
        }
    }

    private async Task HandledecksReportCommand(SocketSlashCommand command)
    {
        await command.RespondAsync(DeckController.DeckReport(command.ChannelId));
    }

    private async Task HandleInitDecksCommand(SocketSlashCommand command)
    {
        Int64 n = 1;

        if (command.Data.Options.Count > 0)
        {
            n = (Int64)command.Data.Options.ToArray()[0].Value;
        }

        await command.RespondAsync(DeckController.InitDecks((int?)n,command.ChannelId));
    }

    private async Task HandleMaggioreCommand(SocketSlashCommand command)
    {
        Int64 n = 1;
        Int64 deck = 0;
        
        if (command.Data.Options.Count > 0)
        {
            n = (Int64)command.Data.Options.ToArray()[0].Value;
        }

        if (command.Data.Options.Count > 1)
        {
            deck = (Int64)command.Data.Options.ToArray()[1].Value;
        }

        await command.RespondAsync(DeckController.ExtractMajor((int?)n, (int?)deck, command.ChannelId));
    }

    private async Task HandleMinoreCommand(SocketSlashCommand command)
    {
        Int64 n = 1;
        Int64 deck = 0;

        if (command.Data.Options.Count > 0)
        {
            n = (Int64)command.Data.Options.ToArray()[0].Value;
        }

        if (command.Data.Options.Count > 1)
        {
            deck = (Int64)command.Data.Options.ToArray()[1].Value;
        }

        await command.RespondAsync(DeckController.ExtractMinor((int?)n, (int?)deck, command.ChannelId));
    }
}