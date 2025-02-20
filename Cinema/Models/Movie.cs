namespace Cinema.Models
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Titolo { get; set; }
        public int Posti { get; set; }
    }
}
