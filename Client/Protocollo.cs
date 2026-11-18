using System.Collections.Generic;
using Newtonsoft.Json;

namespace Client
{
    // Nomi dei comandi scambiati nel campo CommandName.
    public static class Comandi
    {
        public const string Hello = "hello";                 // client -> server: nessun parametro | server -> client: [numero tavolo assegnato]
        public const string GetMenu = "getMenu";             // client -> server: nessun parametro
        public const string Menu = "menu";                   // server -> client: [JSON lista piatti]
        public const string NewOrder = "newOrder";           // client -> server: [JSON ordine]
        public const string OrderReceived = "orderReceived"; // server -> client: [idOrdine]
        public const string OrderStatus = "orderStatus";     // server -> client: [idOrdine, stato]
        public const string Quit = "quit";                   // client -> server: nessun parametro
        public const string Error = "error";                 // server -> client: [messaggio]
    }

    // Unico tipo di messaggio, usato in entrambe le direzioni.
    // Sul socket viaggia come una riga di JSON terminata da '\n'.
    public class Message
    {
        public string CommandName { get; set; }
        public List<string> ParametersList { get; set; } = new List<string>();

        public static Message Crea(string comando, params string[] parametri)
        {
            Message m = new Message();
            m.CommandName = comando;
            m.ParametersList.AddRange(parametri);
            return m;
        }

        // Parametro in posizione "indice", oppure null se manca.
        public string Parametro(int indice)
        {
            if (ParametersList != null && indice >= 0 && indice < ParametersList.Count)
                return ParametersList[indice];
            return null;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Message FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Message>(json);
        }
    }
}
