using BusnLogicLaag;
using DALMSSQLSERVER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomePagina
{
    public partial class ToevoegSchermOGG : Form
    {
            Outfit.OutfitCategory type;
            Onderdeel.OnderdeelCategory typeO;
            string FileName = "";
            string FileNameO = "";
            OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());
            OnderdeelContainer onderdeelContainer = new OnderdeelContainer(new OnderdeelMSSQLDAL());


        public ToevoegSchermOGG()
            {
                InitializeComponent();
            }

            /// <summary>
            /// Openverkenner -- filter verkennerop images, dus hij opent gelijk fotos -- als de gebruiker een plaatje kiest, moet hij daadwerkelijk op openen drukken, dus IF(dialog result = ok , doe dan dat -- haal fileadress op en voeg de plaatje op de picturebox
            /// Daarna ze je pic.image dus de afbeelding krijgt een bepaalde fileadres . 
            /// </summary>
   
            private void OpenVerkenner(PictureBox pic)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "image files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(Path.GetFullPath(open.FileName));
                    if (pic.Name == "pbOutfit")
                        FileName = Path.GetFullPath(open.FileName);
                    else
                        FileNameO = Path.GetFullPath(open.FileName);
                }
            }

            private void KiesOutift_Click(object sender, EventArgs e)
            {
                OpenVerkenner(pbOutfit);
            }

            private void KiesOnderdeel_Click(object sender, EventArgs e)
            {
                OpenVerkenner(pbOnderdeel);
            }

            private void button1_Click(object sender, EventArgs e)
            {
                this.Hide();
            }

           /// <summary>
           /// Als de combobox waarde gelijk is aan de category dan is type de category
           /// </summary>
        
            private void OutfitCategorien()
            {
                type = (Outfit.OutfitCategory)Enum.Parse(typeof(Outfit.OutfitCategory), cbOutfits.Text);
            }

            private void OnderdeelCategorien()
            {
                typeO = (Onderdeel.OnderdeelCategory)Enum.Parse(typeof(Onderdeel.OnderdeelCategory), cbOnderdeel.Text);
            }

            private void VoegOutfitToe_Click(object sender, EventArgs e)
            {
            int id = 0;
            OutfitCategorien();
            bool parseResult = int.TryParse(tbPrijs.Text, out int prijs);
            try
            {
                if (tbNaam.Text != "" && parseResult && cbOutfits.SelectedItem != null && FileName != "")
                {
                    outfitContainer.VoegOutfitToe(((HomePaginaOGG)this.Owner).gebruiker.ID, new Outfit(id, tbNaam.Text, prijs, type, FileName));
                    ((HomePaginaOGG)this.Owner).gebruiker.Outfits = outfitContainer.GetAllOutfitsVanGebr(((HomePaginaOGG)this.Owner).gebruiker.ID);
                    ((HomePaginaOGG)this.Owner).VoegOutfitPbToe();
                    MessageBox.Show("Outfit toegevoegd");
                }
            }
            catch 
            {
                throw new Exception("Vul alle velden in/Voeg foto toe");
            }
        }
            

        private void VoegOnderdeelToe_Click(object sender, EventArgs e)
            {
            int id = 0;
            OnderdeelCategorien();
            bool parseResult = int.TryParse(tbPrijsO.Text, out int prijs);
            try
            {              
                if (tbNaamO.Text != "" && parseResult && cbOnderdeel.SelectedItem != null && FileNameO != "")
                {
                    onderdeelContainer.VoegOnderdeelToe(((HomePaginaOGG)this.Owner).gebruiker.ID, new Onderdeel(id, tbNaamO.Text, prijs, typeO, FileNameO));
                ((HomePaginaOGG)this.Owner).gebruiker.Onderdelen = onderdeelContainer.GetAllOnderdelenVanGebr(((HomePaginaOGG)this.Owner).gebruiker.ID);
                ((HomePaginaOGG)this.Owner).VoegPlaatjeAanPbOnderdeel();
                    MessageBox.Show("Onderdeel toegevoegd");
                }
            }
            catch
            {
                throw new Exception("Vul alle velden in/Voeg foto toe");
            }
        }
    }
}
