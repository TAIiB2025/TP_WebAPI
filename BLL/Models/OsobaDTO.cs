namespace BLL.Models
{
    public class OsobaDTO
    {
        public int Id { get; init; }
        public required string Imie { get; init; }
        public required string Nazwisko { get; init; }
        public int Wiek { get; init; }
        public bool CzyWyrozniona { get; init; }
    }
}
