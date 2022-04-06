using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class OutfitDTO
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

        public OutfitDTO(string naam, int prijs, string FileAdress, Category category)
        {
            this.DeCategory = category;
        }
    }
}
