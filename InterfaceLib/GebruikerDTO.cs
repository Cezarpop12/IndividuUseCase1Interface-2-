namespace InterfaceLib
{
    public class GebruikerDTO
    {
        public int ID { get; set; }
        public string Gerbuikersnaam { get; set;  }
        public string Alias { get; set; }

        public GebruikerDTO(int id, string gerbuikersnaam, string alias)
        {
            this.Gerbuikersnaam = gerbuikersnaam;
            this.Alias = alias;
            this.ID = id;
        }
    }
}