namespace InterfaceLib
{
    public class GebruikerDTO
    {
        public string Gerbuikersnaam { get; set;  }
        public string Alias { get; set; }
        public List<OutfitDTO> Outfits { get; set; } = new List<OutfitDTO>();
        public List<OnderdeelDTO> Onderdelen { get; set; } = new List<OnderdeelDTO>();

        public GebruikerDTO(string gerbuikersnaam, string alias)
        {
            this.Gerbuikersnaam = gerbuikersnaam;
            this.Alias = alias;
        }
    }
}