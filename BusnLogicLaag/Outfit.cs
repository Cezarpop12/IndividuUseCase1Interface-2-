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
        public enum Category
        {
            Chic,
            Casual,
            Trendy,
            OldSchool
        }
        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();
        public Category DeCategory { get; }

        public Outfit(string naam, int prijs, string FileAdress, Category category) : base(naam, prijs, FileAdress)
        {
            this.DeCategory = category;
        }
        public Outfit(OutfitDTO dto)
        {
            this.DeCategory = dto.DeCategory;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {this.DeCategory}";
        }
    }
}
