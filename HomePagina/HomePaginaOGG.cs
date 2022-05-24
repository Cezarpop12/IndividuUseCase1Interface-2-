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
    internal partial class HomePaginaOGG : Form
    {
        /// <summary>
        /// Haal alle outfits die zijn toegevoegd aan de lijst in de form "Toevoegscherm"  weer opniew op.
        /// </summary>
        public GebruikerContainer gebrContainer = new GebruikerContainer(new GebruikerMSSQLDAL());
        public OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());
        public OnderdeelContainer oonderdeelContainer = new OnderdeelContainer(new OnderdeelMSSQLDAL());
        public Gebruiker gebruiker;

        public HomePaginaOGG()
        {
            InitializeComponent();
            //gebrContainer.CreateGebr(new Gebruiker("Cezar008", "Agent009"), "Welkom1234");
            gebruiker = gebrContainer.ZoekGebrOpGebrnaamEnWW("Cezar008", "Welkom1234");
            //gebruiker.Outfits = outfitContainer.GetAllOutfitsVanGebr(gebruiker.ID);
            //gebruiker.Onderdelen = oonderdeelContainer.GetAllOnderdelenVanGebr(gebruiker.ID);
        }

        /// <summary>
        /// Loop door de pictureboxen heen om de juiste picturebox te krijgen.
        /// De index wordt steeds met 1 verhoogd waardoor er steeds de juiste outfit bij de juiste picturebox (met de juiste naam) wordt gezet.
        /// </summary>

        private PictureBox GetRightPictureBox(int index)
        {
            PictureBox pics = new PictureBox();
            string naam = "pictureBox" + index.ToString();
            foreach (PictureBox pic in Controls.OfType<PictureBox>())
            {
                if (pic.Name == naam)
                {
                    pics = pic;
                }
            }
            return pics;
        }

        /// <summary>
        /// Zie hierboven.
        /// </summary>
        
        public void VoegOutfitPbToe()
        {
            //if (gebruiker.Outfits.Count > 0)
            {
                int index = 0;
                //foreach (var img in gebruiker.Outfits)
                {
                    if (index < 4)
                    {
                        //GetRightPictureBox(index).Image = Image.FromFile(gebruiker.Outfits[index].FileAdress);
                        //GetRightPictureBox(index).ImageLocation = gebruiker.Outfits[index].FileAdress;
                        index++;
                    }
                }
            }
        }

        public void VoegPlaatjeAanPbOnderdeel()
        {
            //if (gebruiker.Onderdelen.Count > 0)
            //{
            //    int index = 4;
            //    foreach (var img in gebruiker.Onderdelen)
            //    {
            //        if (index < 8)
            //        {
            //            GetRightPictureBox(index).Image = Image.FromFile(gebruiker.Onderdelen[index - 4].FileAdress);
            //            GetRightPictureBox(index).ImageLocation = gebruiker.Onderdelen[index - 4].FileAdress;
            //            index++;
            //        }
            //    }
            //}
        }

        public void GetWhiteStars(PictureBox ster)
        {
            ster.Image = Properties.Resources.white_star1;
        }

        public void GetYellowStars(PictureBox ster)
        {
            ster.Image = Properties.Resources.yellow_star1;
        }

        /// <summary>
        /// Bij de foreach loop kan die beginnen bij de 0. Vandaar dat je bij de while look een conditie zet >0 zodat die blijft doorloopen ipv 1x en dan klaar.
        /// zo kan die toch de aantal pakken bijv 4 die je dan meegeeft door op de sterren te clicken. Hij checkt elke picture in de GB
        /// </summary>
        
        private void AantalPics(int aantal, PictureBox p)
        {
            while (aantal > 0)
            {
                foreach (var pic in GetRightGb(p).Controls)
                {
                    PictureBox pb = pic as PictureBox;
                    if (pb.Tag != null && pb != null)
                    {
                        if (pb.Tag.ToString() == aantal.ToString())
                        {
                            GetYellowStars(pb);
                            aantal--;
                        }
                    }
                }
            }
        }

        private void Pics_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            ClearStars(pic);
            int aantal = Convert.ToInt32(pic.Tag);
            AantalPics(aantal, pic);
        }

        private GroupBox GetRightGb(PictureBox pic)
        {
            GroupBox GB = new GroupBox();
            foreach (Control gb in Controls.OfType<GroupBox>())
            {
                if (gb.Contains(pic))
                {
                    GB = (GroupBox)gb;
                }
            }
            return GB;
        }

        private void ClearStars(PictureBox pic)
        {
            foreach (PictureBox ster in GetRightGb(pic).Controls.OfType<PictureBox>())
            {
                ster.Image = Properties.Resources.white_star1;
            }
        }

        private Outfit GetRightOutfit(PictureBox pic)
        {
            //foreach (var outfit in gebruiker.Outfits)
            {
                //if (outfit.FileAdress == pic.ImageLocation)
                //    return outfit;
            }
            return null;
        }

        private Onderdeel GetRightOnderdeel(PictureBox pic)
        {
            //foreach (var onderdeel in gebruiker.Onderdelen)
            {
                //if (onderdeel.FileAdress == pic.ImageLocation)
                //    return onderdeel;
            }
            return null;
        }

        /// <summary>
        /// Ga naar de reviewscherm als de gebruiker op yes klikt en outfit niet null is.
        /// </summary>

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (GetRightOutfit(pic) != null)
                if (MessageBox.Show(GetRightOutfit(pic).ToString() + "\n\nWil je deze outfit reviewen?", "Outfit Beschrijving", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //ReviewSchermOGG rev = new ReviewSchermOGG(gebruiker, Convert.ToInt32(pic.Name.Substring(pic.Name.Length - 1)));
                    //rev.ShowDialog();
                }
        }

        private void PicO_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox; 
            if (GetRightOnderdeel(pic) != null)
                if (MessageBox.Show(GetRightOnderdeel(pic).ToString() + "\n\nWil je deze onderdeel reviewen?", "Onderdeel Beschrijving", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //ReviewSchermOGG rev = new ReviewSchermOGG(gebruiker, Convert.ToInt32(pic.Name.Substring(pic.Name.Length - 1)));
                    //rev.ShowDialog();
                }
        }

        private void HomePaginaOGG_Load(object sender, EventArgs e)
        {
            VoegOutfitPbToe();
            VoegPlaatjeAanPbOnderdeel();
        }

        private void btnToevoegenHome_Click(object sender, EventArgs e)
        {
            ToevoegSchermOGG toevoegScherm = new ToevoegSchermOGG();
            toevoegScherm.ShowDialog(this);
        }
    }
}
