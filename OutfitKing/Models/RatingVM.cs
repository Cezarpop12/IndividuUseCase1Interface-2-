using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class RatingVM
    {
        [Required]
        public int Waarde { get; set; }
        public int ID { get; set; }

    }
}
