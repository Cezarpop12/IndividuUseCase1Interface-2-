namespace InterfaceLib
{
    public class GebruikerDTO
    {
        public string Wachtwoord { get; }
        public string Gerbuikersnaam { get; }
        public string Alias { get; }
        public List<OutfitDTO> Outfits { get; } = new List<OutfitDTO>();
        public List<OnderdeelDTO> Onderdelen { get; } = new List<OnderdeelDTO>();

        public GebruikerDTO(string gerbuikersnaam, string wachtwoord, string alias)
        {
            this.Gerbuikersnaam = gerbuikersnaam;
            this.Wachtwoord = wachtwoord;
            this.Alias = alias;
        }
    }
}