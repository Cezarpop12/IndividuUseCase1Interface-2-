using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetGebrTest
{
    [TestClass]
    public class GetGebr
    {
        private GebruikerContainer gebrCon = new GebruikerContainer(new GebruikerMSSQLDAL());
        
        [TestMethod]
        public void GetGebr_GebrVindenAgent007()
        {
            // Arrange
            
            //gebrCon.CreateGebr(new Gebruiker("Cezar", "Sanders", "Agent007"));
            //Gebruiker gebr;

            // Act
            
            //gebrCon.GetGebruiker("Agent007");
            //gebrCon.GetGebruiker("Agent007");
            //wat zoek je 

            // Assert
            
            //Assert.AreEqual("Cezar", gebr.Gerbuikersnaam);
            //Assert.AreEqual("Sanders", gebr.Wachtwoord);
            //Assert.AreEqual("Agent007", gebr.Alias);     
            //wat geef je mee , en wat zou het moeten zijn
        }
    }
}