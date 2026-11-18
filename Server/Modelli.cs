using System;
using System.Collections.Generic;
using System.Linq;

namespace allyoucaneat
{
    // L'ordine dei valori non va cambiato: nel JSON l'enum viaggia come numero.
    public enum StatoOrdine
    {
        Inviato,
        InPreparazione,
        Pronto,
        Servito,
        Annullato
    }

    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Immagine { get; set; }   // nome file dentro la cartella img_menu
        public bool Disponibile { get; set; } = true;
    }

    public class RigaOrdine
    {
        public int PiattoId { get; set; }
        public string NomePiatto { get; set; }
        public int Quantita { get; set; }
    }

    public class Ordine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Tavolo { get; set; }
        public DateTime Ora { get; set; } = DateTime.Now;
        public StatoOrdine Stato { get; set; } = StatoOrdine.Inviato;
        public List<RigaOrdine> Righe { get; set; } = new List<RigaOrdine>();

        // Testo breve dell'ordine, es. "2x Nigiri salmone, 1x Edamame"
        public string Riepilogo()
        {
            return string.Join(", ", Righe.Select(r => r.Quantita + "x " + r.NomePiatto));
        }
    }
}
