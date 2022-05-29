using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class RatingContainer
    {
        private readonly IRatingContainer Container;

        public RatingContainer(IRatingContainer container)
        {
            this.Container = container;
        }

        public void AddRating(int id, int waarde)
        {
            GebruikerDTO dto = gebruiker.GetDTO();
            Container.CreateGebr(dto, wachtwoord);
        }
    }
}
