using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    /// <summary>
    /// Outfit heeft unieke categorien
    /// Outfit heeft ook een ID en bij een outfit kunnen meerdere reviews horen
    /// </summary>
    public class Outfit : Kleding
    {
        public enum OutfitCategory
        {
            Trendy,
            Chic,
            Oldschool,
            Casual
        }

        public int ID { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public OutfitCategory DeCategory { get; set; }

        public Outfit(int id, string titel, int prijs, OutfitCategory category, string fileAdress) : base(titel, prijs, fileAdress)
        {
            DeCategory = category;
            this.ID = id;
        }

        public Outfit(OutfitDTO dto) : base(dto.Titel, dto.Prijs, dto.FileAdress)
        {
            DeCategory = (Outfit.OutfitCategory)dto.DeCategory;
            ID = dto.ID;
        }

        internal OutfitDTO GetDTO()
        {
             OutfitDTO dto = new OutfitDTO(ID, Titel, Prijs, (OutfitDTO.OutfitCategory)DeCategory, FileAdress);
             return dto;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {DeCategory}";
        }
    }
}
