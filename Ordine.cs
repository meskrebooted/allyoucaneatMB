using System;
using System.Collections.Generic;
using System.Linq;

namespace allyoucaneat
{
    public class Ordine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Tavolo { get; set; }
        public DateTime Ora { get; set; } = DateTime.Now;
        public StatoOrdine Stato { get; set; } = StatoOrdine.Inviato;
        public List<RigaOrdine> Righe { get; set; } = new List<RigaOrdine>();

        // Testo comodo da mostrare in una cella della griglia: "2x Nigiri salmone, 1x Edamame"
        public string Riepilogo()
        {
            return string.Join(", ", Righe.Select(r => r.Quantita + "x " + r.NomePiatto));
        }
    }
}
