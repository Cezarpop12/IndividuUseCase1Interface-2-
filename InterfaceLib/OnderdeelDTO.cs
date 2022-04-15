using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class OnderdeelDTO : KledingDTO
    {
        public enum OnderdeelCategory
        {
            Broek,
            Shirt,
            Bloes,
            Schoen,
            Jurk
        }

        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();
        public OnderdeelCategory DeCategory { get; }

        public OnderdeelDTO(string titel, int prijs, string FileAdress, OnderdeelCategory category) : base(titel, prijs, FileAdress)
        {
            this.DeCategory = category;
        }
    }
}
