using BLL;
using BLL.Models;
using BLL_Memory.Extensions;
using DAL.Enities;
namespace BLL_Memory
{
    public class OsobyService : IOsobyService
    {
        private static int IdGen = 1;
        private static List<OsobaEntity> osoby = 
            [
                new OsobaEntity() { Id = IdGen++, Imie = "Adam", Nazwisko="Nowak", CzyWyrozniona = true, Wiek = 30 },
                new OsobaEntity() { Id = IdGen++, Imie = "Natalia", Nazwisko="Kowalska", CzyWyrozniona = false, Wiek = 55 },
                new OsobaEntity() { Id = IdGen++, Imie = "Jan", Nazwisko="Iksiński", CzyWyrozniona = true, Wiek = 12 },
                new OsobaEntity() { Id = IdGen++, Imie = "Maria", Nazwisko="Igrekowa", CzyWyrozniona = false, Wiek = 25 },
                new OsobaEntity() { Id = IdGen++, Imie = "Anna", Nazwisko="Zetowa", CzyWyrozniona = true, Wiek = 18 },
            ];

        public IEnumerable<OsobaDTO> Get()
        {
            //return osoby.Select(o => new OsobaDTO
            //{
            //    Imie = o.Imie,
            //    Nazwisko = o.Nazwisko,
            //    Wiek = o.Wiek,
            //    CzyWyrozniona = o.CzyWyrozniona,
            //    Id = o.Id
            //});

            return osoby.Select(o => o.ToDTO());
        }

        public OsobaDTO GetByID(int id)
        {
            OsobaEntity? osobaEntity = osoby.Find(os => os.Id == id);
            if(osobaEntity is null)
            {
                throw new ApplicationException($"Nie znaleziono osoby o id = {id}");
            }

            return osobaEntity.ToDTO();

            //return new OsobaDTO
            //{
            //    Imie = osobaEntity.Imie,
            //    Nazwisko = osobaEntity.Nazwisko,
            //    CzyWyrozniona = osobaEntity.CzyWyrozniona,
            //    Id = osobaEntity.Id,
            //    Wiek = osobaEntity.Wiek
            //};
        }

        public void Post(OsobaPostDTO osobaPostDTO)
        {
            OsobaEntity osobaEntity = new OsobaEntity
            {
                Imie =osobaPostDTO.Imie,
                Wiek = osobaPostDTO.Wiek,
                Nazwisko = osobaPostDTO.Nazwisko,
                Id = IdGen++,
                CzyWyrozniona = false
            };

            osoby.Add(osobaEntity);
        }
    }
}
