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

        public List<Review> GetAllReviewsVanGebr(string alias)
        {
            List<ReviewDTO> reviewdtos = Container.GetAllReviewsVanGebr(alias);
            List<Review> reviews = new List<Review>();
            foreach (ReviewDTO reviewdto in reviewdtos)
            {
                reviews.Add(new Review(reviewdto));
            }
            return reviews;
        }
        
        public List<Review> GetAllReviews()
        {
            List<ReviewDTO> reviewdtos = Container.GetAllReviews();
            List<Review> reviews = new List<Review>();
            foreach (ReviewDTO reviewdto in reviewdtos)
            {
                reviews.Add(new Review(reviewdto));
            }
            return reviews;
        }


       //Voor later.
        
        //public void VerwijderReview(Review review)
        //{
        //    ReviewDTO dto = review.GetDTO();
        //    Container.VerwijderReview(dto);
        //}
    }
}
