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
        public RatingVM rating { get; set; }
        public ReviewVM review { get; set; }

        public List<ReviewVM> reviews { get; set; }

        public OutfitVM(Outfit outfit)
        {
            ID = outfit.ID;
            Prijs = outfit.Prijs;
            Titel = outfit.Titel;
            Category = (OutfitCategory)outfit.DeCategory;
        }

        public OutfitVM()
        {
         
        }
    }
}
