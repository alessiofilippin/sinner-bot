using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinnerBot.Embed
{
    public static class GenerateEmbed
    {
        public static Discord.Embed ArcanaEmbed(string _title, string _description, string _effects, string _footer)
        {
            var embed = new EmbedBuilder();

            embed.AddField("Effetto", _effects)
                .WithFooter(footer => footer.Text = "Estrazione Completata.")
                .WithColor(Color.Gold)
                .WithTitle(_title)
                .WithDescription(_description)
                .WithFooter(_footer)
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
                .WithCurrentTimestamp();

            return embed.Build();
        }
    }
}
