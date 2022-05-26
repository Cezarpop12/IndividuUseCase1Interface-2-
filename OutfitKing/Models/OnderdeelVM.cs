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
    }
}
