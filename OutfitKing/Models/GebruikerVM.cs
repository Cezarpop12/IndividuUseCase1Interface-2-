using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class GebruikerVM
    { 
        public int ID { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public string Wachtwoord { get; set; }
        [Required]
        public string Gerbuikersnaam { get; set; }
        public bool Retry { get; set; }
      
        public GebruikerVM(int id, string wachtwoord, string gerbuikersnaam)
        {
            this.Wachtwoord = wachtwoord;
            this.Gerbuikersnaam = gerbuikersnaam;
            this.ID = id;
        }
        
        public GebruikerVM()
        {
         
        }
    }
}
