using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class OnderdeelContainer
    {
        private readonly IOnderdeelContainer Container;

        public OnderdeelContainer(IOnderdeelContainer container)
        {
            this.Container = container;
        }

        public void VoegOnderdeelToe(int GebrID, Onderdeel onderdeel)
        {
            OnderdeelDTO onderdeeldto = onderdeel.GetDTO();
            Container.VoegOnderdeelToe(GebrID, onderdeeldto);
        }
        
        public List<Onderdeel> GetAllOnderdelenVanGebr(int GebrID)
        {
            List<OnderdeelDTO> onderdeeldtos = Container.GetAllOnderdelenVanGebr(GebrID);
            List<Onderdeel> onderdelen = new List<Onderdeel>();
            foreach (OnderdeelDTO onderdeeldto in onderdeeldtos)
            {
                onderdelen.Add(new Onderdeel(onderdeeldto));
            }
            return onderdelen;
        }

        public List<Onderdeel> GetAllOnderdelen()
        {
            List<OnderdeelDTO> onderdeeldtos = Container.GetAllOnderdelen();
            List<Onderdeel> onderdelen = new List<Onderdeel>();
            foreach (OnderdeelDTO onderdeeldto in onderdeeldtos)
            {
                onderdelen.Add(new Onderdeel(onderdeeldto));
            }
            return onderdelen;
        }

        public List<Onderdeel> GetLast4Onderdelen()
        {
            List<OnderdeelDTO> onderdeeldtos = Container.GetLast4Onderdelen();
            List<Onderdeel> onderdelen = new List<Onderdeel>();
            foreach (OnderdeelDTO onderdeeldto in onderdeeldtos)
            {
                onderdelen.Add(new Onderdeel(onderdeeldto));
            }
            return onderdelen;
        }
    }
}
