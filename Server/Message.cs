using System.Collections.Generic;
using Newtonsoft.Json;

namespace allyoucaneat
{
    // Unico tipo di messaggio, usato in entrambe le direzioni (come Command/Response dello scheletro).
    public class Message
    {
        public string CommandName { get; set; }
        public List<string> ParametersList { get; set; } = new List<string>();

        public static Message Crea(string commandName, params string[] parametri)
        {
            Message m = new Message();
            m.CommandName = commandName;
            if (parametri != null)
                m.ParametersList.AddRange(parametri);
            return m;
        }

        // Restituisce il parametro in posizione "indice", oppure null se manca.
        public string Parametro(int indice)
        {
            if (ParametersList == null || indice < 0 || indice >= ParametersList.Count)
                return null;
            return ParametersList[indice];
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
