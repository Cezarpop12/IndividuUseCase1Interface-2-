using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class Outfit : Kleding
    {
        public enum OutfitCategory
        {
            Trendy,
            Chic,
            Oldschool,
            Casual
        }

        public List<Review> Reviews { get; set; } = new List<Review>();
        public OutfitCategory DeCategory { get; }

        public Outfit(string titel, int prijs, string FileAdress, OutfitCategory category) : base(titel, prijs, FileAdress)
        {
            DeCategory = category;
        }

        public Outfit(OutfitDTO dto) : base(dto.Titel, dto.Prijs, dto.FileAdress)
        {
            DeCategory = (Outfit.OutfitCategory)dto.DeCategory;
        }

        internal OutfitDTO GetDTO()
        {
             OutfitDTO dto = new OutfitDTO(Titel, Prijs, FileAdress, (OutfitDTO.OutfitCategory)DeCategory);
             return dto;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {DeCategory}";
        }
    }
}
