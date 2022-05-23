using InterfaceLib;

namespace BusnLogicLaag
{
    public class GebruikerContainer
    {
        private readonly IGebruikerContainer Container;

        public GebruikerContainer(IGebruikerContainer container)
        {
            this.Container = container;
        }
        
        public void CreateGebr(Gebruiker gebruiker, string wachtwoord) 
        {
            GebruikerDTO dto = gebruiker.GetDTO();
            Container.CreateGebr(dto, wachtwoord);
        }

        public Gebruiker? ZoekGebrOpGebrnaamEnWW(string gebrnaam, string wachtwoord)
        {
            GebruikerDTO gebruikerdto = Container.ZoekGebrOpGebrnaamEnWW(gebrnaam, wachtwoord);
            if(gebruikerdto != null)
            {
                Gebruiker gebruiker = new Gebruiker(gebruikerdto);
                return gebruiker;
            }
            return null;
        }
        
        public Gebruiker? ZoekGebrOpGebrnaamOfAlias(string gebrnaam, string alias)
        {
            GebruikerDTO gebruikerdto = Container.ZoekGebrOpGebrnaamOfAlias(gebrnaam, alias);
            if (gebruikerdto != null)
            {
                Gebruiker gebruiker = new Gebruiker(gebruikerdto);
                return gebruiker;
            }
            return null;
        }

        public Gebruiker GetGebruiker(string alias)
        {
            GebruikerDTO dto = Container.GetGebruiker(alias);
            Gebruiker gebruiker = new Gebruiker(dto);
            return gebruiker;
        }
      }
    }
