namespace Cinema.Models.ViewModel
{
    public class AddTicket
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public bool IsRidotto { get; set; }
        public Guid? SaleID { get; set; }
        public Guid MovieID { get; set; }
        public List<Sale> StanzeList { get; set; } = new();
        public List<Movie> MovieList { get; set; } = new();
    }
}
