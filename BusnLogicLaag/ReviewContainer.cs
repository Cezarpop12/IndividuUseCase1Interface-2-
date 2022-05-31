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

        public void VoegReviewToeOutfit(int gebrID, int outfitID, Review review)
        {
            ReviewDTO reviewdto = review.GetDTO();
            Container.VoegReviewToeOutfit(gebrID, outfitID, reviewdto);
        }


        public List<Review> GetAllReviewsVanGebr(int gebrID)
        {
            List<ReviewDTO> reviewdtos = Container.GetAllReviewsVanGebr(gebrID);
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

        public Review GetReview(int id)
        {
            ReviewDTO reviewdto = Container.GetReview(id);
            Review review = new Review(reviewdto);
            return review;
        }
    }        
}
