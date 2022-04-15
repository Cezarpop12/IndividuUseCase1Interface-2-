using InterfaceLib;

namespace BusnLogicLaag
{
    public class GebruikerContainer
    {

        /// <summary>
        ///EEN CONTAINER IS DE TUSSENSTAP TUSSEN DE INTERFACE EN FORM.
        ///In de form kan je geen dto meegeven als je een methode wil gebruiken uit de interface. 
        ///Dus eerst omzetten naar domein
        /// </summary>

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

        /// <summary>
        /// Inloggen (ZoekGebrOpGebrnaamEnWW)
        /// </summary>
        
        public Gebruiker ZoekGebrOpGebrnaamEnWW(string gebrNaam, string wachtwoord)
        {
            GebruikerDTO gebruikerdto = Container.ZoekGebrOpGebrnaamEnWW(gebrNaam, wachtwoord);
            Gebruiker gebruiker = new Gebruiker(gebruikerdto);
            //nieuwe constructor om van een dto een domeinObj te maken
            return gebruiker;
        }

        public Gebruiker GetGebruiker(string alias)
        {
            GebruikerDTO gebruikerdto = Container.GetGebruiker(alias);
            Gebruiker gebruiker = new Gebruiker(gebruikerdto);
            return gebruiker;
        }
      }
    }
