using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IOnderdeelContainer
    {
        public void VoegOnderdeelToe(int GebrID, OnderdeelDTO onderdeel);
        public List<OnderdeelDTO> GetAllOnderdelenVanGebr(int GebrID);
        public List<OnderdeelDTO> GetAllOnderdelen();
        public List<OnderdeelDTO> GetLast4Onderdelen();
    }
}
