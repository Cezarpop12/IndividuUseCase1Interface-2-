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

        public int ID { get; set; }
        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();
        public OnderdeelCategory DeCategory { get; }

        public OnderdeelDTO(int id, string titel, int prijs, OnderdeelCategory category, string fileAdress) : base(titel, prijs, fileAdress)
        {
            this.DeCategory = category;
            this.ID = id;
        }
    }
}
