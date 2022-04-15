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

        public void VoegOnderdeelToe(Gebruiker gebruiker, Onderdeel onderdeel)
        {
            GebruikerDTO gebrdto = gebruiker.GetDTO();
            OnderdeelDTO onderdeeldto = onderdeel.GetDTO();
            Container.VoegOnderdeelToe(gebrdto, onderdeeldto);
        }
        
        public List<Onderdeel> GetAllOnderdelenVanGebr(string alias)
        {
            List<OnderdeelDTO> onderdeeldtos = Container.GetAllOnderdelenVanGebr(alias);
            List<Onderdeel> onderdelen = new List<Onderdeel>();
            foreach (OnderdeelDTO onderdeeldto in onderdeeldtos)
            {
                onderdelen.Add(new Onderdeel(onderdeeldto));
            }
            return onderdelen;
        }

        public bool IsOnderdeel(string titel)
        {
            return Container.IsOnderdeel(titel);
        }

       /// <summary>
       /// Voor later.
       /// </summary>
       /// <returns></returns>
       
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

        /// <summary>
        /// Voor later.
        /// </summary>
        /// <returns></returns>

        public Onderdeel GetOnderdeel(string titel)
        {
            OnderdeelDTO onderdeeldto = Container.GetOnderdeel(titel);
            Onderdeel onderdeel = new Onderdeel(onderdeeldto);
            return onderdeel;
        }
    }
}
