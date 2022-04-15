namespace HomePagina
{
    partial class ReviewSchermOGG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblReviewOutfitNaam = new System.Windows.Forms.Label();
            this.tbxReviewSchrijven = new System.Windows.Forms.TextBox();
            this.lbxReviews = new System.Windows.Forms.ListBox();
            this.btnReviewPlaatsen = new System.Windows.Forms.Button();
            this.tbxNaamVanReviewer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReviewOutfitNaam
            // 
            this.lblReviewOutfitNaam.AutoSize = true;
            this.lblReviewOutfitNaam.Location = new System.Drawing.Point(123, 160);
            this.lblReviewOutfitNaam.Name = "lblReviewOutfitNaam";
            this.lblReviewOutfitNaam.Size = new System.Drawing.Size(71, 20);
            this.lblReviewOutfitNaam.TabIndex = 3;
            this.lblReviewOutfitNaam.Text = "Review.....";
            // 
            // tbxReviewSchrijven
            // 
            this.tbxReviewSchrijven.Location = new System.Drawing.Point(485, 328);
            this.tbxReviewSchrijven.Multiline = true;
            this.tbxReviewSchrijven.Name = "tbxReviewSchrijven";
            this.tbxReviewSchrijven.Size = new System.Drawing.Size(195, 96);
            this.tbxReviewSchrijven.TabIndex = 3;
            // 
            // lbxReviews
            // 
            this.lbxReviews.FormattingEnabled = true;
            this.lbxReviews.ItemHeight = 20;
            this.lbxReviews.Location = new System.Drawing.Point(123, 200);
            this.lbxReviews.Name = "lbxReviews";
            this.lbxReviews.Size = new System.Drawing.Size(321, 224);
            this.lbxReviews.TabIndex = 4;
            this.lbxReviews.SelectedIndexChanged += new System.EventHandler(this.lbxReviews_SelectedIndexChanged);
            // 
            // btnReviewPlaatsen
            // 
            this.btnReviewPlaatsen.Location = new System.Drawing.Point(696, 383);
            this.btnReviewPlaatsen.Name = "btnReviewPlaatsen";
            this.btnReviewPlaatsen.Size = new System.Drawing.Size(88, 41);
            this.btnReviewPlaatsen.TabIndex = 5;
            this.btnReviewPlaatsen.Text = "Plaatsen";
            this.btnReviewPlaatsen.UseVisualStyleBackColor = true;
            this.btnReviewPlaatsen.Click += new System.EventHandler(this.btnReviewPlaatsen_Click);
            // 
            // tbxNaamVanReviewer
            // 
            this.tbxNaamVanReviewer.Location = new System.Drawing.Point(696, 350);
            this.tbxNaamVanReviewer.Name = "tbxNaamVanReviewer";
            this.tbxNaamVanReviewer.Size = new System.Drawing.Size(87, 27);
            this.tbxNaamVanReviewer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(696, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Naam";
            // 
            // ReviewSchermOGG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 503);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxNaamVanReviewer);
            this.Controls.Add(this.btnReviewPlaatsen);
            this.Controls.Add(this.lbxReviews);
            this.Controls.Add(this.tbxReviewSchrijven);
            this.Controls.Add(this.lblReviewOutfitNaam);
            this.Name = "ReviewSchermOGG";
            this.Text = "ReviewSchermOGG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblReviewOutfitNaam;
        private TextBox tbxReviewSchrijven;
        private ListBox lbxReviews;
        private Button btnReviewPlaatsen;
        private TextBox tbxNaamVanReviewer;
        private Label label1;
    }
}