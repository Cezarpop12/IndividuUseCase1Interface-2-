using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class ReviewVM
    {
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        public DateTime DatumTijd { get; }
        [Required]
        public string StukTekst { get; set; }

    }
}
