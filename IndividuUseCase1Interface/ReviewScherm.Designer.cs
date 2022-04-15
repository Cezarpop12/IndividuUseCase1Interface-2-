namespace IndividuUseCase1Interface
{
    partial class ReviewScherm
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
            this.lbxReviews = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxNaamVanReviewer = new System.Windows.Forms.TextBox();
            this.btnReviewPlaatsen = new System.Windows.Forms.Button();
            this.tbxReviewSchrijven = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblReviewOutfitNaam = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxReviews
            // 
            this.lbxReviews.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbxReviews.FormattingEnabled = true;
            this.lbxReviews.ItemHeight = 16;
            this.lbxReviews.Location = new System.Drawing.Point(76, 101);
            this.lbxReviews.Name = "lbxReviews";
            this.lbxReviews.Size = new System.Drawing.Size(357, 372);
            this.lbxReviews.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Laat een review achter!";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxNaamVanReviewer);
            this.groupBox1.Controls.Add(this.tbxReviewSchrijven);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnReviewPlaatsen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(469, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // tbxNaamVanReviewer
            // 
            this.tbxNaamVanReviewer.Location = new System.Drawing.Point(216, 81);
            this.tbxNaamVanReviewer.Multiline = true;
            this.tbxNaamVanReviewer.Name = "tbxNaamVanReviewer";
            this.tbxNaamVanReviewer.Size = new System.Drawing.Size(99, 28);
            this.tbxNaamVanReviewer.TabIndex = 5;
            // 
            // btnReviewPlaatsen
            // 
            this.btnReviewPlaatsen.BackColor = System.Drawing.Color.SpringGreen;
            this.btnReviewPlaatsen.Location = new System.Drawing.Point(216, 114);
            this.btnReviewPlaatsen.Name = "btnReviewPlaatsen";
            this.btnReviewPlaatsen.Size = new System.Drawing.Size(99, 39);
            this.btnReviewPlaatsen.TabIndex = 4;
            this.btnReviewPlaatsen.Text = "Plaatsen";
            this.btnReviewPlaatsen.UseVisualStyleBackColor = false;
            // 
            // tbxReviewSchrijven
            // 
            this.tbxReviewSchrijven.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbxReviewSchrijven.Location = new System.Drawing.Point(15, 72);
            this.tbxReviewSchrijven.Multiline = true;
            this.tbxReviewSchrijven.Name = "tbxReviewSchrijven";
            this.tbxReviewSchrijven.Size = new System.Drawing.Size(195, 81);
            this.tbxReviewSchrijven.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IndividuUseCase1Interface.Properties.Resources.Black;
            this.pictureBox1.Location = new System.Drawing.Point(15, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 10);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblReviewOutfitNaam
            // 
            this.lblReviewOutfitNaam.AutoSize = true;
            this.lblReviewOutfitNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewOutfitNaam.Location = new System.Drawing.Point(70, 50);
            this.lblReviewOutfitNaam.Name = "lblReviewOutfitNaam";
            this.lblReviewOutfitNaam.Size = new System.Drawing.Size(244, 32);
            this.lblReviewOutfitNaam.TabIndex = 3;
            this.lblReviewOutfitNaam.Text = "Reviews ........... ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jouw naam :";
            // 
            // ReviewScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 512);
            this.Controls.Add(this.lblReviewOutfitNaam);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbxReviews);
            this.Name = "ReviewScherm";
            this.Text = "ReviewScherm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxReviews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReviewPlaatsen;
        private System.Windows.Forms.TextBox tbxReviewSchrijven;
        private System.Windows.Forms.Label lblReviewOutfitNaam;
        private System.Windows.Forms.TextBox tbxNaamVanReviewer;
        private System.Windows.Forms.Label label2;
    }
}