using BusnLogicLaag;
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

        public ReviewVM(Review review)
        {
            this.ID = review.ID;
            this.Titel = review.Titel;
            this.DatumTijd = review.DatumTijd;
            this.StukTekst = review.StukTekst;
        }

        public ReviewVM()
        {

        }
    }
}
