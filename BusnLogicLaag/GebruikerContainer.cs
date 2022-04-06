using InterfaceLib;

namespace BusnLogicLaag
{
    public class GebruikerContainer
    {
        private readonly IGebruikerContainer Container;

        public GebruikerContainer(IGebruikerContainer container)
        {
            this.Container = container;
            //Waarvoor maak je een ctor? en hoe gebruik je hem?
        }

        public void VoegOutfitToe(Outfit outfit)
        {
            //Ik gebruik hier voor Gebruiker een andere namespace.
            //Kan ik using + die namespace hieraan toevoegen?

            //Ook heb ik in mijn interface de methode staan als "void", kan ik nu gwn zeggen Gebruiker als datatype? of moet dat void

            //Of moet ik Outfit als datatype hebben? en dan hieronder return new Outfit(dto1)

            //Minute 29:10 teams

            Container.VoegOutfitToe(outfit);
            return new Gebruiker(dto1);
        }


        public Gebruiker VerwijderOutfit(OutfitDTO outfit)
        {
            GebruikerDTO dto2 = Container.VerwijderOutfit(outfit);
            return new Gebruiker(dto2);
        }

        public Gebruiker VoegOnderdeelToe(OnderdeelDTO onderdeel)
        {
            GebruikerDTO dto3 = Container.VoegOnderdeelToe(onderdeel);
            return new Gebruiker(dto3);
        }

        public Gebruiker VerwijderOnderdeel(OnderdeelDTO onderdeel)
        {
            GebruikerDTO dto4 = Container.VerwijderOnderdeel(onderdeel);
            return new Gebruiker(dto4);
        }

        public List<OutfitDTO> OutfitsPerCategory(OutfitDTO.Category category)
        {
            //Moet ik list dus zo laten als datatype of veranderen naar gebruiker?
            //Als ik het zo moet laten, wat komt er te staan ipv  return new Gebruiker(dto5);?

            GebruikerDTO dto5 = Container.OutfitsPerCategory(category);
            return new Gebruiker(dto5);
        }

        public List<OnderdeelDTO> OnderdeelPerCategory(OnderdeelDTO.Category category)
        {
            GebruikerDTO dto6 = Container.OnderdeelPerCategory(category);
            return new Gebruiker(dto6);
        }
    }
}