using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;


namespace BusnLogicLaag
{
    public class Onderdeel : Kleding
    {
        public enum OnderdeelCategory
        {
            Broek,
            Shirt,
            Bloes,
            Schoen,
            Jurk
        }

        public List<Review> Reviews { get; set; } = new List<Review>();
        public OnderdeelCategory DeCategory { get; }

        public Onderdeel(string titel, int prijs, string FileAdress, OnderdeelCategory category) : base(titel, prijs, FileAdress)
        {
            DeCategory = category;
        }
        
        public Onderdeel(OnderdeelDTO dto) : base(dto.Titel, dto.Prijs, dto.FileAdress)
        {
            DeCategory = (Onderdeel.OnderdeelCategory)dto.DeCategory;
        }        

        internal OnderdeelDTO GetDTO()
        {
            OnderdeelDTO dto = new OnderdeelDTO(Titel, Prijs, FileAdress, (OnderdeelDTO.OnderdeelCategory)DeCategory);
            return dto;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {DeCategory}";
        }
    }
}
