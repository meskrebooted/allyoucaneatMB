namespace allyoucaneat
{
    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public bool Disponibile { get; set; } = true;
    }
}
