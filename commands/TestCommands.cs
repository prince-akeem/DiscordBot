using DiscordBot.other;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task MyFirstCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hello there {ctx.User.Username}, welcome to my first testing server!");
        }

        [Command("add")]
        public async Task Add(CommandContext ctx, int number1, int number2)
        {
            int result = number1 + number2;

            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("subtrack")]
        public async Task Subtrack(CommandContext ctx, int number1, int number2)
        {
            int result;
            if (number1 > number2)
            {
                result = number1 - number2;
            }
            else
            {
                result = number2 - number1;
            }

            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("embed")]
        public async Task EmbedMessage(CommandContext ctx)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = "This is my first Discord Embed",
                Description = $"This command was executed by {ctx.User.Username}",
                Color = DiscordColor.Red
            };

            await ctx.Channel.SendMessageAsync(embed: message);
        }

        [Command("cardgame")]
        public async Task CardGame(CommandContext ctx)
        {
            var userCard = new CardSystem();
            var userCardEmbed = new DiscordEmbedBuilder()
            {
                Title = $"You card is {userCard.SelectedCard}",
                Color = DiscordColor.Lilac
            };
            await ctx.Channel.SendMessageAsync(embed: userCardEmbed);

            var botCard = new CardSystem();
            var botCardEmbed = new DiscordEmbedBuilder()
            {
                Title = $"The bot drew a {botCard.SelectedCard}",
                Color = DiscordColor.Orange
            };
            await ctx.Channel.SendMessageAsync(embed: botCardEmbed);

            if(userCard.SelectedNumber > botCard.SelectedNumber)
            {
                // User win
                var winMessage = new DiscordEmbedBuilder()
                {
                    Title = "Congratulations, You win!!!",
                    Color = DiscordColor.Green
                };
                await ctx.Channel.SendMessageAsync(embed: winMessage);
            }
            else if (userCard.SelectedNumber == botCard.SelectedNumber)
            {
                // Draw
                var winMessage = new DiscordEmbedBuilder()
                {
                    Title = "It was a Draw!!!",
                    Color = DiscordColor.Gray
                };
                await ctx.Channel.SendMessageAsync(embed: winMessage);
            }
            else if (userCard.SelectedNumber < botCard.SelectedNumber)
            {
                // Bot win
                var winMessage = new DiscordEmbedBuilder()
                {
                    Title = "You Lost!!!",
                    Color = DiscordColor.Red
                };
                await ctx.Channel.SendMessageAsync(embed: winMessage);
            }
            else
            {
                // Bot win
                var winMessage = new DiscordEmbedBuilder()
                {
                    Title = "Unknown Error!!!",
                    Color = DiscordColor.Red
                };
                await ctx.Channel.SendMessageAsync(embed: winMessage);
            }
        }
    }
}
