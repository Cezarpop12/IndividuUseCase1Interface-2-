using BusnLogicLaag;
using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class OnderdeelVM
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
        [Required]
        public int Prijs { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public OnderdeelCategory Category { get; set; }
        [Required]
        public IFormFile Afbeelding { get; set; }

        public OnderdeelVM(Onderdeel onderdeel)
        {
            ID = onderdeel.ID;
            Prijs = onderdeel.Prijs;
            Titel = onderdeel.Titel;
            Category = (OnderdeelCategory)onderdeel.DeCategory;
        }

        public OnderdeelVM()
        {

        }
    }
}
