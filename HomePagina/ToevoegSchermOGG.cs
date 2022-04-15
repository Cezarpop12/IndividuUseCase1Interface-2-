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
            OutfitCategorien();
            bool parseResult = int.TryParse(tbPrijs.Text, out int prijs);
            if (tbNaam.Text != "" && parseResult && cbOutfits.SelectedItem != null && FileName != "")
              {
                outfitContainer.VoegOutfitToe(((HomePaginaOGG)this.Owner).gebruiker, new Outfit(tbNaam.Text, prijs, FileName, type));
                ((HomePaginaOGG)this.Owner).gebruiker.Outfits = outfitContainer.GetAllOutfitsVanGebr("Agent009");
                ((HomePaginaOGG)this.Owner).VoegOutfitPbToe();
                MessageBox.Show("Outfit toegevoegd");
              }
            }

        private void VoegOnderdeelToe_Click(object sender, EventArgs e)
            {
                OnderdeelCategorien();
                bool parseResult = int.TryParse(tbPrijsO.Text, out int prijs);
                if (tbNaamO.Text != "" && parseResult && cbOnderdeel.SelectedItem != null && FileNameO != "")
                {
                    onderdeelContainer.VoegOnderdeelToe(((HomePaginaOGG)this.Owner).gebruiker, new Onderdeel(tbNaamO.Text, prijs, FileNameO, typeO));
                ((HomePaginaOGG)this.Owner).gebruiker.Onderdelen = onderdeelContainer.GetAllOnderdelenVanGebr("Agent009");
                ((HomePaginaOGG)this.Owner).VoegPlaatjeAanPbOnderdeel();
                    MessageBox.Show("Onderdeel toegevoegd");
                }
            }
    }
}
