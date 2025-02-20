namespace Cinema.Models
{
    public class Sale
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public List<Movie> FilmInProgrammazione { get; set; } = new();


    }
}
