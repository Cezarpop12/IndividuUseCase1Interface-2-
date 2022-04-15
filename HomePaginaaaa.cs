using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IndividuUseCase1Interface
{
    internal partial class HomePagina : Form
    {

        Database database = new Database();
        public Gebruiker gebruiker { get; }

        public HomePagina()
        {
            InitializeComponent(); 
            this.gebruiker = database.Inloggen("Cezar", "Sanders");
        }

        private void btnToevoegenHome(object sender, EventArgs e)
        {
            ToevoegScherm toevoegScherm = new ToevoegScherm();
            toevoegScherm.ShowDialog(this); 
        }

        private PictureBox GetRightPictureBox(int index)
        {
            //Je wilt hier een picturebox ophalen, vandaar datatype PictureBox
            PictureBox pics = new PictureBox();
            //waarom maak je hier een nieuw object aan
            string naam = "pictureBox" + index.ToString();
            //welke index??
            foreach(PictureBox pic in Controls.OfType<PictureBox>())
            {
                //zoek pictureboxen in de form (denk ik in de form). Dus loop door de form heen om te kijken wat allemaal pictureboxen zijn
                if (pic.Name == naam)
                {
                    //als de naam van de pictureboxen gelijk is aan de naam die je meegeeft , dus "pictureBox" + een bepaalde index. Hierdoor pakt hij alle outfitPictureboxen pictureboxen
                    pics = pic;
                    // (dan is het object wat je hierboven hebt aangemaakt gelijk aan wat?????), (Maak je dan 5 objecten aan? omdat hij 5 sterren vind?)
                }
            }
            return pics;
        }

        private void HomePagina_Load(object sender, EventArgs e)
        {
            VoegOutfitPbToe();
            VoegPlaatjeAanPbOnderdeel();
        }

        public void VoegOutfitPbToe()
        {
            if (this.gebruiker.Outfits.Count> 0)
            {
                //Als de oufit lijst groter is dan 0, wat hier dus het geval is doe dan... (is die if statement niet dubbel?)
                int index = 0;
                foreach (var img in gebruiker.Outfits)
                {
                    //zoek index? in outfit lijst
                    //dus hij telt en begint bij 0, dan is de conditie hieronder waar en doet hij iets met de eerste outfit
                    if(index < 4)
                    {
                        //vervolgens werk je met sterren, wtf?
                        GetRightPictureBox(index).Image = Image.FromFile(gebruiker.Outfits[index].FileAdress);
                        GetRightPictureBox(index).ImageLocation = gebruiker.Outfits[index].FileAdress;
                        index++;
                    }
                }
            }
        }

        public void VoegPlaatjeAanPbOnderdeel()
        {
            if (this.gebruiker.Onderdelen.Count > 0)
            {
                int index = 4;
                foreach (var img in gebruiker.Onderdelen)
                {
                    if(index < 8)
                    {
                        GetRightPictureBox(index).Image = Image.FromFile(gebruiker.Onderdelen[index - 4].FileAdress);
                        GetRightPictureBox(index).ImageLocation = gebruiker.Onderdelen[index-4].FileAdress;
                        index++;
                    }
                }
            }
        }

        public void GetWhiteStars(PictureBox ster)
        {
            ster.Image = Properties.Resources.white_star;
        }

        public void GetYellowStars(PictureBox ster)
        {
            ster.Image = Properties.Resources.yellow_star;
        }

        /// <summary>
        /// Bij de foreach loop kan die beginnen bij de 0. Vandaar dat je bij de while look een conditie zet >0 zodat die blijft doorloopen ipv 1x en dan klaar. zo kan die toch de aantal pakken bijv 4 die je dan meegeeft door op de sterren te clicken. Hij checkt elke picture in de GB
        /// </summary>
        /// <param name="aantal"></param>
        /// <param name="p"></param>
        private void AantalPics(int aantal,PictureBox p)
        {
            while (aantal > 0)
            {
                foreach (var pic in GetRightGb(p).Controls)
                {
                    PictureBox pb = pic as PictureBox;
                    if(pb.Tag != null && pb != null)
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
            AantalPics(aantal,pic);
        }

        private GroupBox GetRightGb(PictureBox pic)
        {
            GroupBox GB = new GroupBox();
            foreach(Control gb in Controls.OfType<GroupBox>())
            {
                if(gb.Contains(pic))
                {
                    GB = (GroupBox)gb;
                }
            }
            return GB;
        }

        private void ClearStars(PictureBox pic)
        {
            foreach(PictureBox ster in GetRightGb(pic).Controls.OfType<PictureBox>())
            {
                ster.Image = Properties.Resources.white_star;
            }
        }

        private Outfit GetRightOutfit(PictureBox pic)
        {
            foreach(var outfit in this.gebruiker.Outfits)
            {
                if (outfit.FileAdress == pic.ImageLocation)
                    return outfit;
            }
            return null;
        }

        private Onderdeel GetRightOnderdeel(PictureBox pic)
        {
            foreach (var onderdeel in this.gebruiker.Onderdelen)
            {
                if (onderdeel.FileAdress == pic.ImageLocation)
                    return onderdeel;
            }
            return null;
        }

        /// <summary>
        /// Ga naar de reviewscherm als de gebruiker op yes klikt en outfit geen null is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if(GetRightOutfit(pic) != null)
            if(MessageBox.Show(GetRightOutfit(pic).ToString()+"\n\nWil je deze outfit reviewen?","Outfit Beschrijving",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ReviewScherm rev = new ReviewScherm(gebruiker,Convert.ToInt32(pic.Name.Substring(pic.Name.Length - 1)));
                rev.ShowDialog();
            }
        }

        private void PicO_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (GetRightOnderdeel(pic) != null)
            MessageBox.Show(GetRightOnderdeel(pic).ToString(),"Outfit Beschrijving");
        }

        private void ReviewOutfit1_Click(object sender, EventArgs e)
        {
            ReviewScherm reviewScherm = new ReviewScherm(gebruiker,1);
            reviewScherm.ShowDialog();
        }

        private void cbOutfits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Outfit.Category  type;
            type = (Outfit.Category)Enum.Parse(typeof(Outfit.Category), cbOutfits.Text);
            MessageBox.Show(type.ToString());
        }
    }
}
