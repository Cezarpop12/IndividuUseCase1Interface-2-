using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IReviewContainer
    {
        public void VoegReviewToeOutfit(int gebrID, int outfitID, ReviewDTO review);
        public List<ReviewDTO> GetAllReviewsVanGebr(int gebrID);
        public List<ReviewDTO> GetAllReviewsVanOutfit(int outfitID);

        public void DeleteReview(ReviewDTO review);
        public void UpdateReview(ReviewDTO review);
        public ReviewDTO GetReview(int id);
    }
}
