# SinnerBot

[![Docker Image CI](https://github.com/alessiofilippin/sinner-bot/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/alessiofilippin/sinner-bot/actions/workflows/dotnet.yml)

**You can add the Bot to your discord server from here [Link to Bot](https://discordbotlist.com/bots/sinnerbot)**

## Copyright

<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a><br />This work is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License</a>.

## Info

**Eng**: This is a Discord Bot Created to allow people to play with ease at Sine Requie: An italian Horror pen&paper RPG.

**Ita**: Questo e' un Bot Discord creato per permettere alla persone di giocare con facilita' a Sine Requie: un gioco di ruolo italiano horror.

## Sine Requie

**Eng**: Sine Requie is an Italian game. All the rights go to the creators of the game. Info here.

**Ita**: Sine Requie e' un gioco di ruolo italiano. Tutti i diritti vanno ai creatori del gioco. Informazioni di seguito.

[Sine Requie Wiki Page](https://it.wikipedia.org/wiki/Sine_Requie)

[Sine Requie Shop](https://www.serpentarium.net/shop)

<img alt="Sine Requie Logo" style="border-width:0" src="https://static.wixstatic.com/media/5738c7_58db52d69ba642b5b607e3daa9951da2~mv2.jpg/v1/fill/w_740,h_330,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/5738c7_58db52d69ba642b5b607e3daa9951da2~mv2.jpg" />

## Disclaimer

**Eng**: This Bot will make online experience easier and better. But details about the rules are not shared on purpose. If you would like to play the game, buy the rule book. This Bot has been made for the first and second editions of the game but it can be used for the third edition as well.

**This Repo contains the code for the Bot. Feel free to Fork the project and make your changes.**

**Ita**: Questo Bot renderà l'esperienza online più facile e migliore. Ma i dettagli sulle regole non sono condivisi di proposito. Se vuoi giocare, acquista il regolamento. Il Bot e' stato creato per la prima e seconda edizione del gioco ma puo' essere utilizzato anche per la terza.


**Questa Repo contiene il codice per il Bot. Sentiti libero di eseguire il Fork del progetto e apportare le tue modifiche.**

# Bot

## KeyFeatures

**Eng**
- Create till 10 couple of decks. One couple contains one Major Arcana and one Minor Arcana decks.
- Perform random extractions for Major Arcana and Minor Arcana. The Bot will also display key info about the arcana extracted, so you don't have always check the manual.
- Shuffle rules are in line with Sine Requie's first and second/edition rules.

**Ita**
- Crea fino a 10 coppie di mazzi. Una coppia contiene un mazzo degli Arcani Maggiori e uno degli Arcani Minori.
- Esegui estrazioni casuali per Arcani Maggiori e Arcani Minori. Il Bot mostrerà anche le informazioni chiave sugli arcani estratti, quindi non devi sempre controllare il manuale.
- Le regole di mischiaggio sono in linea con le regole di prima e seconda/edizione di Sine Requie.

## Commands

**Eng**: The Bot currently supports the following commands.


- **"/crea-mazzi"**:  Generates a specific number of decks (usually one per Player + one for the GM). This creates both decks for major and minor arcana.
- **"/stato-mazzi"**: Create a report on the status of the available decks.
- **"/maggiore"**:  Perform the extraction of a major arcana (tarot) from a specific deck for a maximum of 5 arcana.
- **"/minore"**:  Perform the extraction of a minor arcana (poker card) from a specific deck for a maximum of 5 arcana.


**Ita**: Il Bot attualmente supporta i seguenti comandi.


- **"/crea-mazzi"**:  Genera uno specifico numbero di mazzi (solitamente uno per giocatore + uno per il GM). Questo commando crea entrambi i mazzi per gli arcani maggiori e minori.
- **"/stato-mazzi"**: Genera un report sullo stato dei mazzi disponibili.
- **"/maggiore"**:  Esegue l'estrazione di un arcano maggiore (tarocco) dal deck specificato fino ad un massimo di 5 carte.
- **"/minore"**: Esegue l'estrazione di un arcano minore (carte da poker) dal deck specificato fino ad un massimo di 5 carte.

## Localization

**Eng**: The Bot is currently available only in Italian. More Languages might come in the future.

**Ita**: Il Bot è attualmente disponibile solo in italiano. Altre lingue potrebbero arrivare in futuro.

## Hosting

**Eng**: This is a self-hosted, self-financed project. As such the Bot is currently hosted on [serverstarter.host](https://serverstarter.host/clients/) a DiscordBot hosting service which claim to provide 99.9% SLA. However, I don't guarantee the full availability of the bot. I invite you to follow this guide and host the bot yourself if required. Using the code contained in this repo. [.NET GUIDE FOR DISCORD](https://discordnet.dev/guides/getting_started/first-bot.html).

**Ita**: Questo è un progetto auto-gestito e autofinanziato. In quanto tale, il Bot è attualmente ospitato su [serverstarter.host](https://serverstarter.host/clients/) un servizio di hosting DiscordBot che dichiara di fornire uno SLA del 99,9%. Tuttavia, non garantisco la piena disponibilità del bot. Ti invito a seguire questa guida e ad ospitare tu stesso il bot se necessario. Utilizzando il codice contenuto in questo repository. [GUIDA .NET PER DISCORD](https://discordnet.dev/guides/getting_started/first-bot.html).

## State

**Eng**: The state of each deck per server is saved into a JSON file which the bot will read and write depending on the command type. This was the cheapest solution for hosting and the JSON file will be destroyed after 2 hours of inactivity to preserve the memory on the host.

**Ita**: Lo stato di ogni deck per server viene salvato in un file JSON che il bot leggerà e scriverà a seconda del tipo di comando. Questa era la soluzione più economica per l'hosting e il file JSON verrà distrutto dopo 2 ore di inattività per preservare la memoria sull'host.

