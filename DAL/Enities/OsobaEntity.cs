namespace DAL.Enities
{
    public class OsobaEntity
    {
        public int Id { get; set; }
        public required string Imie { get; set; }
        public required string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public bool CzyWyrozniona { get; set; }
    }
}
