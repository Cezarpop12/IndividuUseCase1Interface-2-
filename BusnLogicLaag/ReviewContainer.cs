using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class ReviewContainer
    {
        private readonly IReviewContainer Container;

        public ReviewContainer(IReviewContainer container)
        {
            this.Container = container;
        }

        public void VoegReviewToeOutfit(Review review, Gebruiker gebruiker, string titel)
        {
            ReviewDTO reviewdto = review.GetDTO();
            GebruikerDTO gebrdto = gebruiker.GetDTO();
            Container.VoegReviewToeOutfit(reviewdto, gebrdto, titel);
        }

        public void VoegReviewToeOnderdeel(Review review, Gebruiker gebruiker, string titel)
        {
            ReviewDTO reviewdto = review.GetDTO();
            GebruikerDTO gebrdto = gebruiker.GetDTO();
            Container.VoegReviewToeOnderdeel(reviewdto, gebrdto, titel);
        }

        public List<Review> GetAllReviewsVanGebr(Gebruiker gebruiker)
        {
            GebruikerDTO dto = gebruiker.GetDTO();
            List<ReviewDTO> reviewdtos = Container.GetAllReviewsVanGebr(dto);
            List<Review> reviews = new List<Review>();
            foreach (ReviewDTO reviewdto in reviewdtos)
            {
                reviews.Add(new Review(reviewdto));
            }
            return reviews;
        }
        public void DeleteReview(Review review)
        {
            ReviewDTO dto = review.GetDTO();
            Container.DeleteReview(dto);
        }
        public void UpdateReview(Review review)
        {
            ReviewDTO reviewdto = review.GetDTO();
            Container.UpdateReview(reviewdto);
        }
    }        
}
