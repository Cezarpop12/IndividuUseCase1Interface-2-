namespace OutfitKing.Models
{
    public class GebruikerVM
    {
        public string Wachtwoord { get; set; }
        //public string ProfielBiografie { get; set; }
        public string Gerbuikersnaam { get; set; }
        public string Alias { get; set; }
        public List<Outfit> Outfits { get; set; } = new List<Outfit>();
        public List<Onderdeel> Onderdelen { get; set; } = new List<Onderdeel>();
    }
}
