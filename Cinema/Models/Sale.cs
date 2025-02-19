namespace Cinema.Models
{
    public class Sale
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public int Posti { get; set; } = 120;
    }
}
