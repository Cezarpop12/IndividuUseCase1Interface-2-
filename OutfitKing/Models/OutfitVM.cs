using BusnLogicLaag;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class OutfitVM
    {
        public enum OutfitCategory
        {
            Trendy,
            Chic,
            Oldschool,
            Casual
        }

        public int ID { get; set; }
        [Required]
        public int Prijs { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public OutfitCategory Category { get; set; }
        [Required]
        public IFormFile Afbeelding { get; set; }

        public OutfitVM()
        {

        }

        public OutfitVM(Outfit outfit)
        {
            this.Prijs = outfit.Prijs;
            this.Titel = outfit.Titel;
            this.Category = (OutfitCategory)outfit.DeCategory;
            //this.Afbeelding = (IFromFile)outfit.FileAdress;
            this.ID = outfit.ID;
        }
    }
}
