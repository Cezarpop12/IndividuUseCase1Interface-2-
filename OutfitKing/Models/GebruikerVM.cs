using System.ComponentModel.DataAnnotations;

namespace OutfitKing.Models
{
    public class GebruikerVM
    { 
        public int ID { get; set; }
        [Required(ErrorMessage = "Voer een alias in.")]
        public string Alias { get; set; }
        [Required(ErrorMessage = "Voer een wachtwoord in.")]
        public string Wachtwoord { get; set; }
        [Required(ErrorMessage = "Voer een gebruikersnaam in.")]
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
