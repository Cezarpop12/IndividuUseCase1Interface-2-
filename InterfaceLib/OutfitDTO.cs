using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class OutfitDTO : KledingDTO
    {
        public enum OutfitCategory
        {
            Trendy,
            Chic,
            Oldschool,
            Casual
        }

        public int ID { get; set; }
        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();
        public OutfitCategory DeCategory { get; set; }

        public OutfitDTO(int id, string titel, int prijs, OutfitCategory category, string fileAdress) : base(titel, prijs, fileAdress)
        {
            DeCategory = category;
            this.ID = id;
        }
    }
}
