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
        //Wat is dit?

        public ReviewContainer(IReviewContainer container)
        {
            this.Container = container;
            //Waarvoor maak je een ctor? en hoe gebruik je hem?
        }
        public Gebruiker MaxWoordenCheck(string beschrijving)
        {
            //bool als datatype of gebruiker? of Review?
            GebruikerDTO dto1 = Container.MaxWoordenCheck(beschrijving);
            return new Gebruiker(dto1);
        }
    }
}
