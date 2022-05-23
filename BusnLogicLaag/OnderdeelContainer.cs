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


        public bool IsOnderdeel(string titel)
        {
            return Container.IsOnderdeel(titel);
        }

        public void DeleteOnderdeel(Onderdeel onderdeel)
        {
            OnderdeelDTO dto = onderdeel.GetDTO();
            Container.DeleteOnderdeel(dto);
        }

        public void UpdateOnderdeel(Onderdeel onderdeel)
        {
            OnderdeelDTO onderdeeldto = onderdeel.GetDTO();
            Container.UpdateOnderdeel(onderdeeldto);
        }

        public Onderdeel GetOnderdeel(string titel)
        {
            OnderdeelDTO onderdeeldto = Container.GetOnderdeel(titel);
            Onderdeel onderdeel = new Onderdeel(onderdeeldto);
            return onderdeel;
        }
    }
}
