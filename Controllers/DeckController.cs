using SinnerBot.Embed;
using SinnerBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinnerBot.Controllers
{
    public static class DeckController
    {
        public static string InitDecks(int? _nDecks, ulong? _channelID)
        {
            if (_nDecks > 10)
                return "Massimo 10 coppie di mazzi.";

            InstanceDetails instance = new InstanceDetails(_channelID.ToString(), MajorArcanaController.InitDecks(_nDecks), MinorArcanaController.InitDecks(_nDecks));
            bool state = JsonSerializerController.WriteDataForServer(instance);

            if (state)
                return "Deck Impostati";

            return "Errore Creazione Mazzi";
        }

        public static string DeckReport(ulong? _channelID)
        {
            InstanceDetails instance = JsonSerializerController.ReadDataForServer(_channelID.ToString());

            if (instance == null)
            {
                return "Nessun Mazzo Creato. Lanciare comando /crea-mazzi";
            }

            return MajorArcanaController.DeckReport(instance.availableMajorArcana) + MinorArcanaController.DeckReport(instance.availableMinorArcana);
        }

        public static Discord.Embed[] ExtractMajor(int? _n, int? _deck, ulong? _channelID)
        {
            Discord.Embed[] embedArrayErrors = new Discord.Embed[1];
            InstanceDetails instance = JsonSerializerController.ReadDataForServer(_channelID.ToString());

            if (instance == null || instance.availableMajorArcana == null)
            {
                embedArrayErrors[0] = GenerateEmbed.ErrorEmbed("Nessun Mazzo Creato");
                return embedArrayErrors;
            }

            
            if (_deck > instance.availableMajorArcana.Length)
            {
                embedArrayErrors[0] = GenerateEmbed.ErrorEmbed("Numero mazzi disponibile: " + instance.availableMajorArcana.Length);
                return embedArrayErrors;
            }


            if (_n > 5)
            {
                embedArrayErrors[0] = GenerateEmbed.ErrorEmbed("Massimo 5 estrazioni.");
                return embedArrayErrors;
            }

            // Get user-input and normalized them
            int deck = 0;
            if (_deck != null && _deck > 0)
                deck = (int)_deck - 1;

            int n = 1;
            if (_n != null && _n > 0)

                n = (int)_n;

            return MajorArcanaController.RandomExtraction(n, deck, instance.availableMajorArcana, _channelID.ToString());
        }

        public static Discord.Embed[] ExtractMinor(int? _n, int? _deck, ulong? _channelID)
        {
            Discord.Embed[] embedArrayErrors = new Discord.Embed[1];
            InstanceDetails instance = JsonSerializerController.ReadDataForServer(_channelID.ToString());

            if (instance == null || instance.availableMinorArcana == null)
            {
                embedArrayErrors[0] = GenerateEmbed.ErrorEmbed("Nessun Mazzo Creato");
                return embedArrayErrors;
            }


            if (_deck > instance.availableMinorArcana.Length)
            {
                embedArrayErrors[0] = GenerateEmbed.ErrorEmbed("Numero mazzi disponibile: " + instance.availableMajorArcana.Length);
                return embedArrayErrors;
            }


            if (_n > 5)
            {
                embedArrayErrors[0] = GenerateEmbed.ErrorEmbed("Massimo 5 estrazioni.");
                return embedArrayErrors;
            }

            // Get user-input and normalized them
            int deck = 0;
            if (_deck != null && _deck > 0)
                deck = (int)_deck - 1;

            int n = 1;
            if (_n != null && _n > 0)
                n = (int)_n;


            return MinorArcanaController.RandomExtraction(n, deck, instance.availableMinorArcana, _channelID.ToString());
        }
    }
}
