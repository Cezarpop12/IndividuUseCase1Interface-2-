using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class OutfitContainer
    {
        private readonly IOutfitContainer Container;
        //Wat is dit?

        public OutfitContainer(IOutfitContainer container)
        {
            this.Container = container;
            //Waarvoor maak je een ctor? en hoe gebruik je hem?
        }
        public Gebruiker VoegReviewToe(ReviewDTO review)
        {
            GebruikerDTO dto1 = Container.VoegReviewToe(review);
            return new Gebruiker(dto1);
        }

        public Gebruiker VerwijderReview(ReviewDTO review)
        {
            GebruikerDTO dto2 = Container.VerwijderReview(review);
            return new Gebruiker(dto2);
        }
    }
}
