namespace allyoucaneat
{
    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Immagine { get; set; }   // nome file dentro la cartella img_menu (es. "nigiri_salmone.jpg")
        public bool Disponibile { get; set; } = true;
    }
}
