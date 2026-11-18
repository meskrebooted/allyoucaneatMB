# allyoucaneat

Ordinazioni "all you can eat": i **tablet** dei tavoli (Client) inviano gli ordini alla **cucina** (Server).

## Struttura

| File | Cosa contiene |
|------|---------------|
| `Protocollo.cs` | `Comandi` (nomi dei comandi) e `Message` (il messaggio JSON) |
| `Modelli.cs` | `Piatto`, `RigaOrdine`, `Ordine`, `StatoOrdine` |
| `Server/Server.cs` | accetta i tablet, assegna i tavoli, carica `menu.json` |
| `Server/ClientManager.cs` | un thread per tablet: legge i comandi e risponde |
| `Server/Scontrino.cs` | il "biglietto" grafico di un ordine |
| `Client/Client.cs` | connessione e thread di ascolto del tablet |
| `Form1.cs` | interfaccia grafica (client: menu e carrello, server: scontrini) |

`Protocollo.cs` e `Modelli.cs` sono uguali nei due progetti (cambia solo il namespace).

## Protocollo

Ogni messaggio e' una riga di JSON terminata da `\n`: `{"CommandName":"...","ParametersList":["..."]}`

| Comando | Direzione | Parametri |
|---------|-----------|-----------|
| `hello` | tablet -> cucina, poi risposta | nessuno / `[tavolo assegnato]` |
| `getMenu` | tablet -> cucina | nessuno |
| `menu` | cucina -> tablet | `[JSON lista piatti]` |
| `newOrder` | tablet -> cucina | `[JSON ordine]` |
| `orderReceived` | cucina -> tablet | `[idOrdine]` |
| `orderStatus` | cucina -> tablet | `[idOrdine, stato]` |
| `quit` | tablet -> cucina | nessuno |
| `error` | cucina -> tablet | `[messaggio]` |
