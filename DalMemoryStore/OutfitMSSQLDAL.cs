using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class OutfitMSSQLDAL : IOutfitContainer
    {
        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();

        public void VoegReviewToe(ReviewDTO review)
        {
            if (review.MaxWoordenCheck(review.StukTekst))
                this.Reviews.Add(review);
        }

        public void VerwijderReview(ReviewDTO review)
        {
            this.Reviews.Remove(review);
        }
    }
}
