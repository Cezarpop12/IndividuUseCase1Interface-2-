using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;


namespace BusnLogicLaag
{
    /// <summary>
    /// Onderdeel heeft unieke categorien, ook heeft deze een ID
    /// Bij een onderdeel horen ook bepaalde reviews
    /// </summary>
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

        public int ID { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public OnderdeelCategory DeCategory { get; }

        public Onderdeel(int id, string titel, int prijs, OnderdeelCategory category, string fileAdress) : base(titel, prijs, fileAdress)
        {
            DeCategory = category;
            this.ID = id;
        }
        
        public Onderdeel(OnderdeelDTO dto) : base(dto.Titel, dto.Prijs, dto.FileAdress)
        {
            DeCategory = (Onderdeel.OnderdeelCategory)dto.DeCategory;
            this.ID = dto.ID;
        }        

        internal OnderdeelDTO GetDTO()
        {
            OnderdeelDTO dto = new OnderdeelDTO(ID, Titel, Prijs, (OnderdeelDTO.OnderdeelCategory)DeCategory, FileAdress);
            return dto;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {DeCategory}";
        }
    }
}
