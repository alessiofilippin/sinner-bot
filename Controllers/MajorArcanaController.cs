using Discord;
using Discord.Rest;
using SinnerBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SinnerBot.Controllers
{
    public static class MajorArcanaController
    {
        private static Dictionary<int, Major> majorArcanaDeck = new Dictionary<int, Major>() {
            {1, new Major("I - Il Bagatto","Il Bagatto rappresenza un successo rocambolesco, ma apparente, oppure un successo che porta conseguenze inaspettate e spesso negative.","Torace: B3 T2 P2 M2 S1") },
            {2, new Major("II - La Papessa","L'azione intrapresa avrà un esito positivo grazie all'utilizzo di una qualche conoscenza specifica. Nel caso l'azione sia meramente fisica non avremo il successo sperato.","Gamba Sx: B2 T2 P2 M2 S0") },
            {3, new Major("III - L'Imperatrice","Possibilità di un aiuto inaspettato dovuto a qualcuno che si impietosisce o all'intervento di una persona potente. L'aiuto può arrivare anche da un Personaggio Giocante. Nel caso non ci sia possibilità lacuna di un aiuto esterno, l'esito sarà negativo.","Spalla Sx: B1 T1 P1 M1 S0") },
            {4, new Major("IV - L'Imperatore","Il Personaggio riesce con la propria forza e prepotenza a uscire fuori da qualunque situazione. La volontà dell'Imperatore lo aiuterà ad uscire dalle situazioni più tortuose.","Spalla Dx: B1 T1 P1 M1 S0") },
            {5, new Major("V - Il Papa","Il Personaggio rimane indeciso e irresoluto osservando lo svolgersi degli eventi totalmente inconsapevole delle conseguenze degli avvenimenti.","Gamba Dx: B2 T2 P2 M2 S0") },
            {6, new Major("VI - L'Innamorato","La situazione si risolve negativamente a causa della fiducia mal riposta in qualcosa o qualcuno, oppure a causa di una sbagliata interpretazione degli eventi.","Cuore: B2 T2 P5 M2 S3") },
            {7, new Major("VII - Il Carro","La carta porta ad un successo trionfale in qualunque caso che farà guadagnare al Personaggio l'ammirazione di tutti i presenti.","Ventre: B2 T2 P2 M3 S2") },
            {8, new Major("VIII - La Giustizia","Il fato ti ha condannato. Nessuna possibilità di successo per l'azione che hai intrapreso. Maggiori sono le ingiustizie commesse dal Personaggio, maggiore sarà la punizione inflitta dalla Giustizia.","Torace: B1 T1 P2 M2 S1") },
            {9, new Major("IX - L'Eremita","Questa carta porta ad un insuccesso che ha effetto durevole sul Personaggio, tanto che quest'ultimo sarà insicuro quando si troverà in una situazione simile.","Torace: B1 T2 P3 M2 S1") },
            {10, new Major("X - La Ruota Della Fortuna","L'evento si rivelerà fortuitamente positivo, anche se non per meriti specifici del Personaggio, bensì per fortuna sfacciata.","Inguine: B3 T1 P2 M3 S2") },
            {11, new Major("XI - La Forza","L'azione verrà portata a buon fine grazie ad un impeto di risolutezza e coraggio.","Braccio Dx: B1 T2 P2 M2 S1") },
            {12, new Major("XII - L'Appeso","Un insuccesso dovuto alle circostanze esterne contro il quale il Personaggio non può niente.","Ventre: B3 T1 P1 M3 S1") },
            {13, new Major("XIII - La Morte","Insuccesso grave e definitivo. Il Personaggio subirà il maggior danno possibile dagli eventi senza possibilità di rimedio.","Testa: B4 T2 P5 M4 S3") },
            {14, new Major("XIV - La Temperanza","L'evento avviente, ma non tocca minimamente il Personaggio. Qualunque cosa succeda non lo coinvolgerà minimamente.","Braccio Sx: B1 T2 P1 M2 S1") },
            {15, new Major("XV - Il Diavolo","Fallimento disastroso oltre ogni immaginazione, Tutto ciò che può andare male andrà male anche in maniera inspiegabile.","Collo: B3 T6 P3 M5 S3") },
            {16, new Major("XVI - La Torre","Fallimento critico e disastroso che coinvolgerà tutti coloro che sono vicini al Personaggio. Fallimento definitivo e inappellabile.","Testa: B0 T0 P0 M0 S0") },
            {17, new Major("XVII - Le Stelle","Successo perfetto. Era destinato che la situazione si risolvesse al meglio.","Ventre: B3 T2 P3 M3 S2") },
            {18, new Major("XVIII - La Luna","Insuccesso dovuto a insicurezza e paura. Talvolta un'azione apparentemente positiva si rivela col tempo frutto di fallimento.","Braccio Sx: B3 T4 P3 M3 S1") },
            {19, new Major("XIX - Il Sole","Successo pieno dovuto ad un'abilità personale e a capacità che risultano vincenti.","Braccio Dx: B3 T4 P3 M3 S1") },
            {20, new Major("XX - Il Giudizio","Fallimento dovuto ad una scarsa capacità di giudizio degli altri, della situazione in cui ci si trova e delle proprie capacità.","Gamba Dx: B4 T3 P3 M2 S2") },
            {21, new Major("XXI - Il Mondo","L'azione va a buon fine grazie alla conoscenza dell'ambiente e delle persone che circondano il personaggio. Talvolta è il dinamismo del Personaggio che risolve la situazione.","Gamba Sx: B4 T3 P3 M2 S2") },
            {22, new Major("0 - Il Matto","La situazione si risolverà con un avvenimento improvviso, causale e spesso irripetibile e incomprensibile. Raramente si può avere la comparsa di fenomeni inspiegabili.","A Scelta: B0/6 T0/6 P0/6 M0/6 S0/3") },
        };

        public static List<int>[] InitDecks(int? _nDecks)
        {
            try
            {
                List<int>[] availableArcana = new List<int>[(int)_nDecks];
                for (int i = 0; i < _nDecks; i++)
                { 
                    availableArcana[i] = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
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
            string report = "\n\n Arcani Maggiori \n\n";
            for (int i = 0; i < _availableArcana.Length; i++)
            {
                report = report + "Mazzo: " + (i + 1) + " Numero Arcani: " + _availableArcana[i].Count + "\n\n";
            }

            return report;
        }

        public static string RandomExtraction(int? _n, int? _deck, List<int>[] _availableArcana, string? _serverID)
        {
            try
            {
                if (_deck > _availableArcana.Length)
                    return "Numero Mazzo errato.";

                if (_n > 5)
                    return "5 estrazioni massime.";

                // Get user-input and normalized them
                int deck = 0;
                if (_deck != null && _deck > 0)
                    deck = (int)_deck - 1;

                int n = 1;
                if (_n != null && _n > 0)
                    n = (int)_n;

                // Perform n exractions from specific deck number
                string outputMsg = "";
                for (int i = 0; i < n; i++)
                {
                    Random rnd = new Random();
                    int rndIndex = rnd.Next(0, _availableArcana[deck].Count - 1);
                    Major arcanas = majorArcanaDeck.ElementAt(_availableArcana[deck][rndIndex] - 1).Value;


                    // Il Matto was extracted - Shuffle
                    if (_availableArcana[deck][rndIndex] == 22)
                    {
                        _availableArcana[deck] = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
                        outputMsg = outputMsg + "\n\n" + Emoji.Parse(":point_down:") + " -- Mazzo Mischiato --";
                    }
                    else
                    {
                        // the extracted card gets removed from the deck. This because after the extraction - cards are put at the end of the pile and a Shuffle always happens before the end of the pile.
                        _availableArcana[deck].RemoveAt(rndIndex);
                    }

                    // Append message to output
                    outputMsg += "\n\n" + Emoji.Parse(":bangbang:") + " Mazzo: " + (deck + 1) + " Estrazione: " + (i + 1) + "\n\n" + arcanas.Name + "\n\n" + arcanas.Description + "\n\n" + arcanas.Effects;

                }

                JsonSerializerController.WriteDataForServer(new InstanceDetails(_serverID,_availableArcana,null));
                return outputMsg;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
