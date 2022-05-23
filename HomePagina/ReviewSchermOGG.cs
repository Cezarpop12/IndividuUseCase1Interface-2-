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
    public partial class ReviewSchermOGG : Form
    {
        ReviewContainer reviewContainer = new ReviewContainer(new ReviewMSSQLDAL());
        OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());
        OnderdeelContainer onderdeelContainer = new OnderdeelContainer(new OnderdeelMSSQLDAL());
        string titel = null;
        
        Gebruiker gebruiker;
        int index;

        /// <summary>
        /// Check of het een outfit of onderdeel is wat je hebt meegekregen.
        /// </summary>

        internal ReviewSchermOGG(Gebruiker gebruiker, int index)
        {
            InitializeComponent();
            this.gebruiker = gebruiker;
            this.index = index;
            if (outfitContainer.IsOutfit(gebruiker.Outfits[index].Titel))
            {
                lblReviewOutfitNaam.Text = $"Reviews :  ' {gebruiker.Outfits[index].Titel} '";
            }
            else if(onderdeelContainer.IsOnderdeel(gebruiker.Onderdelen[index-4].Titel))
            {
                lblReviewOutfitNaam.Text = $"Reviews :  ' {gebruiker.Onderdelen[index-4].Titel} '";
            }
        }

        /// <summary>
        ///  omdat je hieronder alle waardes pakt uit de lijst van reviews, komt bij elke niewe review alle reviews weer uit die lijst te voorschijn ,
        ///  dus clearen
        /// </summary>

        private void btnReviewPlaatsen_Click(object sender, EventArgs e)
        {
            int id = 0;
            lbxReviews.Items.Clear();
            if(outfitContainer.IsOutfit(gebruiker.Outfits[index].Titel))
            {
                reviewContainer.VoegReviewToeOutfit(new Review(id, titel, tbxReviewSchrijven.Text, gebruiker, DateTime.Now), gebruiker, gebruiker.Outfits[index].Titel);
                gebruiker.Outfits[index].Reviews = reviewContainer.GetAllReviewsVanGebr(gebruiker);
                lbxReviews.Items.AddRange(gebruiker.Outfits[index].Reviews.ToArray());
            }
            else if (onderdeelContainer.IsOnderdeel(gebruiker.Onderdelen[index-4].Titel))
            {
                reviewContainer.VoegReviewToeOnderdeel(new Review(id, titel, tbxReviewSchrijven.Text, gebruiker, DateTime.Now), gebruiker, gebruiker.Onderdelen[index-4].Titel);
                gebruiker.Onderdelen[index - 4].Reviews = reviewContainer.GetAllReviewsVanGebr(gebruiker);
                lbxReviews.Items.AddRange(gebruiker.Onderdelen[index - 4].Reviews.ToArray());
            }
        }
        
        

        private void lbxReviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxReviews.SelectedItem != null)
                MessageBox.Show(lbxReviews.SelectedItem.ToString());
        }
    }
}
