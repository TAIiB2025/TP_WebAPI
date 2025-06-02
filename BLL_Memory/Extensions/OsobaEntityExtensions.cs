using BLL.Models;
using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Memory.Extensions
{
    internal static class OsobaEntityExtensions
    {
        public static OsobaDTO ToDTO(this OsobaEntity osobaEntity)
        {
            return new OsobaDTO
            {
                Imie = osobaEntity.Imie,
                Nazwisko = osobaEntity.Nazwisko,
                CzyWyrozniona = osobaEntity.CzyWyrozniona,
                Id = osobaEntity.Id,
                Wiek = osobaEntity.Wiek
            };
        }
    }
}
