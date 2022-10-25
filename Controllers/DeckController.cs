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

        public static string ExtractMajor(int? _n, int? _deck, ulong? _channelID)
        {
            InstanceDetails instance = JsonSerializerController.ReadDataForServer(_channelID.ToString());

            if (instance == null || instance.availableMajorArcana == null)
            {
                return "Nessun Mazzo Creato. Lanciare comando /crea-mazzi";
            }

            return MajorArcanaController.RandomExtraction(_n, _deck, instance.availableMajorArcana, _channelID.ToString());
        }

        public static string ExtractMinor(int? _n, int? _deck, ulong? _channelID)
        {
            InstanceDetails instance = JsonSerializerController.ReadDataForServer(_channelID.ToString());

            if (instance == null || instance.availableMinorArcana == null)
            {
                return "Nessun Mazzo Creato. Lanciare comando /crea-mazzi";
            }

            return MinorArcanaController.RandomExtraction(_n, _deck, instance.availableMinorArcana, _channelID.ToString());
        }
    }
}
