using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IndividuUseCase1Interface
{
    internal partial class ToevoegScherm : Form
    {
        //    Outfit.Category type;
        //    Onderdeel.Category typeO;
        //    string FileName = "";
        //    string FileNameO = "";
        //    Database database = new Database();

        //    public ToevoegScherm()
        //    {
        //        InitializeComponent();
        //    }

        //    /// <summary>
        //    /// Openverkenner -- filter verkennerop images, dus hij opent gelijk fotos -- als de gebruiker een plaatje kiest, moet hij daadwerkelijk op openen drukken, dus IF(dialog result = ok , doe dan dat -- haal fileadress op en voeg de plaatje op de picturebox
        //    /// Daarna ze je pic.image dus de afbeelding krijgt een bepaalde fileadres . 
        //    /// 
        //    /// </summary>
        //    /// <param name="pic"></param>
        //    private void OpenVerkenner(PictureBox pic)
        //    {
        //        OpenFileDialog open = new OpenFileDialog();
        //        open.Filter = "image files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp";
        //        if (open.ShowDialog() == DialogResult.OK)
        //        {
        //            pic.Image = Image.FromFile(Path.GetFullPath(open.FileName));
        //            if (pic.Name == "pbOutfit")
        //                FileName = Path.GetFullPath(open.FileName);
        //            else
        //                FileNameO = Path.GetFullPath(open.FileName);
        //        }
        //    }

        //    private void KiesOutift_Click(object sender, EventArgs e)
        //    {
        //        OpenVerkenner(pbOutfit);
        //    }

        //    private void KiesOnderdeel_Click(object sender, EventArgs e)
        //    {
        //        OpenVerkenner(pbOnderdeel);
        //    }

        //    private void button1_Click(object sender, EventArgs e)
        //    {
        //        this.Hide();
        //    }

        //    private void OutfitCategorien()
        //    {
        //        //if (cbOutfits.Text == Outfit.Category.Casual.ToString())
        //        //    type = Outfit.Category.Casual;
        //        //if (cbOutfits.Text == Outfit.Category.Chic.ToString())
        //        //    type = Outfit.Category.Chic;
        //        //if (cbOutfits.Text == Outfit.Category.OldSchool.ToString())
        //        //    type = Outfit.Category.OldSchool;
        //        //if (cbOutfits.Text == Outfit.Category.Trendy.ToString())
        //        //    type = Outfit.Category.Trendy;
        //        type = (Outfit.Category)Enum.Parse(typeof(Outfit.Category), cbOutfits.Text);
        //    }

        //    private void OnderdeelCategorien()
        //    {
        //        //if (cbOnderdeel.Text == Onderdeel.Category.Jurk.ToString())
        //        //    typeO = Onderdeel.Category.Jurk;
        //        //if (cbOnderdeel.Text == Onderdeel.Category.Broek.ToString())
        //        //    typeO = Onderdeel.Category.Broek;
        //        //if (cbOnderdeel.Text == Onderdeel.Category.Schoen.ToString())
        //        //    typeO = Onderdeel.Category.Schoen;
        //        //if (cbOnderdeel.Text == Onderdeel.Category.Bloes.ToString())
        //        //    typeO = Onderdeel.Category.Bloes;
        //        //if (cbOnderdeel.Text == Onderdeel.Category.Shirt.ToString())
        //        //    typeO = Onderdeel.Category.Shirt;
        //        typeO = (Onderdeel.Category)Enum.Parse(typeof(Onderdeel.Category), cbOnderdeel.Text);

        //    }

        //    private void VoegOutfitToe_Click(object sender, EventArgs e)
        //    {
        //        OutfitCategorien();
        //        bool parseResult = int.TryParse(tbPrijs.Text, out int prijs);
        //        if (tbNaam.Text != "" && parseResult && cbOutfits.SelectedItem != null && FileName != "")
        //        {
        //            database.VoegOutfitToe(((HomePagina)this.Owner).gebruiker, new Outfit(tbNaam.Text, prijs, FileName, type));
        //            ((HomePagina)this.Owner).gebruiker.VoegOutfitToe(new Outfit(tbNaam.Text, prijs, FileName, type));
        //            ((HomePagina)this.Owner).VoegOutfitPbToe();
        //            MessageBox.Show("Outfit toegevoegd");
        //        }
        //    }

        //    private void VoegOnderdeelToe_Click(object sender, EventArgs e)
        //    {
        //        OnderdeelCategorien();
        //        bool parseResult = int.TryParse(tbPrijsO.Text, out int prijs);
        //        if (tbNaamO.Text != "" && parseResult&& cbOnderdeel.SelectedItem != null && FileNameO != "")
        //        {
        //            ((HomePagina)this.Owner).gebruiker.VoegOnderdeelToe(new Onderdeel(tbNaamO.Text, prijs, FileNameO, typeO));
        //            ((HomePagina)this.Owner).VoegPlaatjeAanPbOnderdeel();
        //            MessageBox.Show("Onderdeel toegevoegd");
        //        }
        //    }

        //    private void ToevoegScherm_Load(object sender, EventArgs e)
        //    {

        //    }
        //}
    }
}
