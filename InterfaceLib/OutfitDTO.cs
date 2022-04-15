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

        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();
        public OutfitCategory DeCategory { get; }

        public OutfitDTO(string titel, int prijs, string FileAdress, OutfitCategory category) : base(titel, prijs, FileAdress)
        {
            this.DeCategory = category;
        }
    }
}
