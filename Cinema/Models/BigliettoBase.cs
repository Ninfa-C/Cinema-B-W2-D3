namespace Cinema.Models
{
    public class BigliettoBase
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public Sale? Sale { get; set; }
        public bool IsRidotto { get; set; }

    }
}
