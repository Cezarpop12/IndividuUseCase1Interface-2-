using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IOutfitContainer
    {
        public void VoegReviewToe(ReviewDTO review);
        public void VerwijderReview(ReviewDTO review);
    }
}
