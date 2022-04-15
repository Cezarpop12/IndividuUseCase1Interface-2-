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

    public partial class ReviewScherm : Form
    {
        //{
        //    Gebruiker gebruiker;
        //    int index;
        //    Database database = new Database();

        //    internal ReviewScherm(Gebruiker gebruiker, int index)
        //    {
        //        InitializeComponent();
        //        this.gebruiker = gebruiker;
        //        this.index = index;
        //        lblReviewOutfitNaam.Text = $"Reviews :  ' {gebruiker.Outfits[index].Naam} '"; 
        //    }
        //    private void btnReviewPlaatsen_Click(object sender, EventArgs e)
        //    {
        //        lbxReviews.Items.Clear(); //  omdat je hieronder alle waardes pakt uit de lijst van reviews, komt bij elke niewe review alle reviews weer uit die lijst te voorschijn , dus clearen
        //        database.VoegReviewToeVanOutfit(new Review(tbxReviewSchrijven.Text, gebruiker), gebruiker, gebruiker.Outfits[index].Naam);
        //        gebruiker.Outfits[index].VoegReviewToe(new Review(tbxReviewSchrijven.Text, gebruiker));
        //        lbxReviews.Items.AddRange(gebruiker.Outfits[index].Reviews.ToArray());
        //    }

        //    private void ReviewScherm_Load(object sender, EventArgs e)
        //    {
        //        lbxReviews.Items.AddRange(gebruiker.Outfits[index].Reviews.ToArray()); 
        //    }

        //    private void lbxReviews_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        if(lbxReviews.SelectedItem != null)
        //        MessageBox.Show(lbxReviews.SelectedItem.ToString());
        //    }
    }
}

