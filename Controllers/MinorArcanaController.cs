using Discord;
using Discord.Rest;
using SinnerBot.Embed;
using SinnerBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SinnerBot.Controllers
{
    public static class MinorArcanaController
    {
        private static Dictionary<int, Minor> minorArcanaDeck = new Dictionary<int, Minor>() {

            {1, new Minor("Asso - Cuori - Rosso","Successo Critico.") },
            {2, new Minor("Due - Cuori - Rosso","N/A") },
            {3, new Minor("Tre - Cuori - Rosso","N/A") },
            {4, new Minor("Quattro - Cuori - Rosso","N/A") },
            {5, new Minor("Cinque - Cuori - Rosso","N/A") },
            {6, new Minor("Sei - Cuori - Rosso","N/A") },
            {7, new Minor("Sette - Cuori - Rosso","N/A") },
            {8, new Minor("Otto - Cuori - Rosso","N/A") },
            {9, new Minor("Nove - Cuori - Rosso","N/A") },
            {10, new Minor("Dieci - Cuori - Rosso","N/A") },
            {11, new Minor("Fante - Cuori - Rosso","Insuccesso Critico. Se combattimento: perdita azione corrente e -3 prossimo attacco.") },
            {12, new Minor("Cavallo - Cuori - Rosso","Immobilita', Esitazione, indecisione. Perdita turno o azione.") },
            {13, new Minor("Regina - Cuori - Rosso","Insuccesso Ma..possibile effetto secondario positivo.") },
            {14, new Minor("Re - Cuori - Rosso","Successo Pero..possibile effetto secondario negativo.") },
            {15, new Minor("Asso - Picche - Nero","Successo Critico.") },
            {16, new Minor("Due - Picche - Nero","N/A") },
            {17, new Minor("Tre - Picche - Nero","N/A") },
            {18, new Minor("Quattro - Picche - Nero","N/A") },
            {19, new Minor("Cinque - Picche - Nero","N/A") },
            {20, new Minor("Sei - Picche - Nero","N/A") },
            {21, new Minor("Sette - Picche - Nero","N/A") },
            {22, new Minor("Otto - Picche - Nero","N/A") },
            {23, new Minor("Nove - Picche - Nero","N/A") },
            {24, new Minor("Dieci - Picche - Nero","N/A") },
            {25, new Minor("Fante - Picche - Nero","Insuccesso Critico. Se combattimento: il colpo colpisce un compagno o te stesso, calcolo danno normale.") },
            {26, new Minor("Cavallo - Picche - Nero","Immobilita', Esitazione, indecisione. Perdita turno o azione.") },
            {27, new Minor("Regina - Picche - Nero","Insuccesso Ma..possibile effetto secondario positivo. Se Combattimento: Inceppamento Lieve,Medio,Alto,Estremo. Blocco prima di sparo.") },
            {28, new Minor("Re - Picche - Nero","Successo Pero..possibile effetto secondario negativo. Se Combattimento: Inceppamento Medio,Alto,Estremo. Blocco dopo sparo.") },
            {29, new Minor("Asso - Quadri - Rosso","Successo Critico.") },
            {30, new Minor("Due - Quadri - Rosso","N/A") },
            {31, new Minor("Tre - Quadri - Rosso","N/A") },
            {32, new Minor("Quattro - Quadri - Rosso","N/A") },
            {33, new Minor("Cinque - Quadri - Rosso","N/A") },
            {34, new Minor("Sei - Quadri - Rosso","N/A") },
            {35, new Minor("Sette - Quadri - Rosso","N/A") },
            {36, new Minor("Otto - Quadri - Rosso","N/A") },
            {37, new Minor("Nove - Quadri - Rosso","N/A") },
            {38, new Minor("Dieci - Quadri - Rosso","N/A") },
            {39, new Minor("Fante - Quadri - Rosso","Insuccesso Critico. Se combattimento: Qualcosa e' andato storto, il colpo non e' stato esploso. Perdita prossima azione turno oppure tutte azioni turno successivo.") },
            {40, new Minor("Cavallo - Quadri - Rosso","Immobilita', Esitazione, indecisione. Perdita turno o azione.") },
            {41, new Minor("Regina - Quadri - Rosso","Insuccesso Ma..possibile effetto secondario positivo.") },
            {42, new Minor("Re - Quadri - Rosso","Successo Pero..possibile effetto secondario negativo.") },
            {43, new Minor("Asso - Fiori - Nero","Successo Critico.") },
            {44, new Minor("Due - Fiori - Nero","N/A") },
            {45, new Minor("Tre - Fiori - Nero","N/A") },
            {46, new Minor("Quattro - Fiori - Nero","N/A") },
            {47, new Minor("Cinque - Fiori - Nero","N/A") },
            {48, new Minor("Sei - Fiori - Nero","N/A") },
            {49, new Minor("Sette - Fiori - Nero","N/A") },
            {50, new Minor("Otto - Fiori - Nero","N/A") },
            {51, new Minor("Nove - Fiori - Nero","N/A") },
            {52, new Minor("Dieci - Fiori - Nero","N/A") },
            {53, new Minor("Fante - Fiori - Nero","Insuccesso Critico. Se combattimento: Rottura arma da fuoco oppure -1 classe danno per arma mischia.") },
            {54, new Minor("Cavallo - Fiori - Nero","Immobilita', Esitazione, indecisione. Perdita turno o azione.") },
            {55, new Minor("Regina - Fiori - Nero","Insuccesso Ma..possibile effetto secondario positivo. Se Combattimento: Inceppamento Alto,Estremo. Blocco prima di sparo.") },
            {56, new Minor("Re - Fiori - Nero","Successo Pero..possibile effetto secondario negativo. Se Combattimento: Inceppamento Estremo. Blocco dopo sparo.") },
        };

        public static List<int>[] InitDecks(int? _nDecks)
        {
            try
            {
                List<int>[] availableArcana = new List<int>[(int)_nDecks];
                for (int i = 0; i < _nDecks; i++)
                {
                    availableArcana[i] = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
                }


                return availableArcana;
            }
            catch
            {
                return null;
            }
        }

        public static string DeckReport(List<int>[] _availableArcana)
        {
            string report = "\n\n Arcani Minori \n\n";
            for (int i = 0; i < _availableArcana.Length; i++)
            {
                report = report + "Mazzo: " + (i + 1) + " Numero Arcani: " + _availableArcana[i].Count + "\n\n";
            }

            return report;
        }

        public static Discord.Embed[] RandomExtraction(int _n, int _deck, List<int>[] _availableArcana, string? _serverID)
        {
            try
            {
                // Perform n exractions from specific deck number
                Discord.Embed[] embedArray = new Discord.Embed[_n];
                for (int i = 0; i < _n; i++)
                {
                    Random rnd = new Random();
                    int rndIndex = rnd.Next(0, _availableArcana[_deck].Count - 1);
                    Minor arcanas = minorArcanaDeck.ElementAt(_availableArcana[_deck][rndIndex] - 1).Value;
                    string footer = "";

                    // Asso di picche was extracted - Shuffle
                    if (_availableArcana[_deck][rndIndex] == 15)
                    {
                        _availableArcana[_deck] = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
                        footer = footer + " -- Mazzo Mischiato -- ";
                    }
                    else
                    {
                        // the extracted card gets removed from the deck. This because after the extraction - cards are put at the end of the pile and a Shuffle always happens before the end of the pile.
                        _availableArcana[_deck].RemoveAt(rndIndex);
                    }

                    // Append message to output
                    footer = footer + "Mazzo: " + (_deck + 1) + " Estrazione: " + (i + 1);
                    embedArray[i] = GenerateEmbed.ArcanaEmbed(arcanas.name, "N/A", arcanas.effects, footer);

                }

                JsonSerializerController.WriteDataForServer(new InstanceDetails(_serverID, null, _availableArcana));
                return embedArray;

            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
