using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class OnderdeelDTO
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
        public Category DeCategory { get; }

        public OnderdeelDTO(string naam, int prijs, string FileAdress, Category category) 
        {
            //Hoe zet ik hier de base bij?
            //Moet kleding ook een DTO hebben?
            this.DeCategory = category;
        }
    }
}
