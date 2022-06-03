using BusnLogicLaag;
using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class RatingVM
    {
        [Range(0, 5, ErrorMessage = "Kies een waarde t/m 5")]
        public int Waarde { get; set; }
        public int OutfitID { get; set; }
        public int ID { get; set; }

        public RatingVM(Rating rating)
        {
            ID = rating.ID;
            Waarde = rating.Waarde;
            OutfitID = rating.OutfitID;
        }

        public RatingVM()
        {

        }
    }
}
