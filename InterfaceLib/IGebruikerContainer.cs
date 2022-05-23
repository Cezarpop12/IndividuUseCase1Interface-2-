using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IGebruikerContainer
    {
        public void CreateGebr(GebruikerDTO gebruiker, string wachtwoord);
        public GebruikerDTO ZoekGebrOpGebrnaamEnWW(string gebrnaam, string wachtwoord);
        public GebruikerDTO ZoekGebrOpGebrnaamOfAlias(string gebrnaam, string alias);
        public GebruikerDTO GetGebruiker(string alias);
    }
}
