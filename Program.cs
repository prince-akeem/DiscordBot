using DiscordBot.commands;
using DiscordBot.Config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        private static DiscordClient DiscordClient { get; set; }
        private static CommandsNextExtension DiscordCommands { get; set; }
        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            DiscordClient = new DiscordClient(discordConfig);

            DiscordClient.Ready += DiscordClient_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] {jsonReader.prefix},
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
            };

            DiscordCommands = DiscordClient.UseCommandsNext(commandsConfig);

            DiscordCommands.RegisterCommands<TestCommands>();
            
            await DiscordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task DiscordClient_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
