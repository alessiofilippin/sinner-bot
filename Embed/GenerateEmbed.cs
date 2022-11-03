using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SinnerBot.Models;

namespace SinnerBot.Embed
{
    public static class GenerateEmbed
    {
        public static Discord.Embed ArcanaEmbed(string _title, string _description, string _effects, string _footer, string? _imageUrl)
        {
            var embed = new EmbedBuilder();

            embed.WithColor(Color.Gold)
                .WithTitle(_title)
                .WithFooter(_footer)
                .WithCurrentTimestamp();

            if (_effects != "")
                embed.AddField("Effetto", _effects);

            if (_description != "")
                embed.WithDescription(_description);

            if (_imageUrl != "")
                embed.WithImageUrl(_imageUrl);

            return embed.Build();
        }

        public static Discord.Embed MiscellaneousEmbed(string _title, string _description)
        {
            var embed = new EmbedBuilder();

            embed.WithColor(Color.Green)
                .WithTitle(_title)
                .WithDescription(_description)
                .WithCurrentTimestamp();

            return embed.Build();
        }

        public static Discord.Embed ErrorEmbed(string _errorDescription)
        {
            var embed = new EmbedBuilder();

            embed.WithColor(Color.Red)
                .WithTitle("Errore")
                .WithDescription(_errorDescription)
                .WithCurrentTimestamp();

            return embed.Build();
        }

        public static Discord.Embed InfoEmbed(string _title, string _description)
        {
            var embed = new EmbedBuilder();

            embed.WithColor(Color.DarkBlue)
                .WithTitle(_title)
                .WithDescription(_description)
                .WithImageUrl("https://static.wixstatic.com/media/5738c7_58db52d69ba642b5b607e3daa9951da2~mv2.jpg/v1/fill/w_740,h_330,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/5738c7_58db52d69ba642b5b607e3daa9951da2~mv2.jpg")
                .WithUrl("https://github.com/alessiofilippin/sinner-bot")
                .WithFooter("Bot Created by AleGames93#2361")
                .WithCurrentTimestamp();

            return embed.Build();
        }
    }
}
