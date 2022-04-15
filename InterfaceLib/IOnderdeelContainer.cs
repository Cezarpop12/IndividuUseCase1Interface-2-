using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IOnderdeelContainer
    {
        public void VoegOnderdeelToe(GebruikerDTO gebruiker, OnderdeelDTO onderdeel);
        //public void VerwijderOnderdeel(OnderdeelDTO onderdeel);
        public List<OnderdeelDTO> GetAllOnderdelenVanGebr(string alias);
        public List<OnderdeelDTO> GetAllOnderdelen();
        public OnderdeelDTO GetOnderdeel(string titel);
        public bool IsOnderdeel(string titel);
    }
}
