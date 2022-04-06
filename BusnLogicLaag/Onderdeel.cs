using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;


namespace IndividuUseCase1Interface
{
    public class Onderdeel : Kleding
    {
        public enum Category
        {
            Broek,
            Shirt,
            Bloes,
            Schoen,
            Jurk
        }

        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();
        //hier ook dto???
        public Category DeCategory { get; }

        public Onderdeel(string naam, int prijs, string FileAdress, Category category) : base(naam, prijs, FileAdress)
        {
            this.DeCategory = category;
        }

        public Onderdeel(OnderdeelDTO dto)
        {
            this.DeCategory = dto.DeCategory;
            //weer een namespace probleem
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {this.DeCategory}";
        }
    }
}
