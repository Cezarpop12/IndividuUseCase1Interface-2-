using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IReviewContainer
    {
        public void VoegReviewToeOutfit(ReviewDTO review, GebruikerDTO gebruiker, string titel);
        public void VoegReviewToeOnderdeel(ReviewDTO review, GebruikerDTO gebruiker, string titel);
        //public void VerwijderReview(ReviewDTO review);
        public List<ReviewDTO> GetAllReviewsVanGebr(int gebrID);
        public void DeleteReview(ReviewDTO review);
        public void UpdateReview(ReviewDTO review);
    }
}
