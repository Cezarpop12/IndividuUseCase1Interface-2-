using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class OnderdeelMSSQLDAL : IOnderdeelContainer
    {
        public List<ReviewDTO> Reviews { get; } = new List<ReviewDTO>();

        public void VoegReviewToe(ReviewDTO review)
        {
            if (review.MaxWoordenCheck(review.StukTekst))
                //Waarom pakt hij deze niet?
                this.Reviews.Add(review);
        }

        public void VerwijderReview(ReviewDTO review)
        {
            this.Reviews.Remove(review);
        }
    }
}
