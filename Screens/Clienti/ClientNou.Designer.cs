
namespace Proiect.Screens.Clienti
{
    partial class ClientNou
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
            this.NumeClientTextBox = new System.Windows.Forms.TextBox();
            this.TelefonTextBox = new System.Windows.Forms.TextBox();
            this.AdresaTextBox = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.ClientNouButton = new MetroFramework.Controls.MetroButton();
            this.CloseButton = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NumeClientTextBox
            // 
            this.NumeClientTextBox.Location = new System.Drawing.Point(171, 112);
            this.NumeClientTextBox.Name = "NumeClientTextBox";
            this.NumeClientTextBox.Size = new System.Drawing.Size(210, 20);
            this.NumeClientTextBox.TabIndex = 0;
            // 
            // TelefonTextBox
            // 
            this.TelefonTextBox.Location = new System.Drawing.Point(171, 156);
            this.TelefonTextBox.MaxLength = 10;
            this.TelefonTextBox.Name = "TelefonTextBox";
            this.TelefonTextBox.Size = new System.Drawing.Size(153, 20);
            this.TelefonTextBox.TabIndex = 1;
            // 
            // AdresaTextBox
            // 
            this.AdresaTextBox.Location = new System.Drawing.Point(171, 206);
            this.AdresaTextBox.Multiline = true;
            this.AdresaTextBox.Name = "AdresaTextBox";
            this.AdresaTextBox.Size = new System.Drawing.Size(210, 65);
            this.AdresaTextBox.TabIndex = 2;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(88, 113);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Nume";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(88, 157);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(50, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Telefon";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(88, 206);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(50, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Adresa";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(118, 325);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 33);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Salveaza";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClientNouButton
            // 
            this.ClientNouButton.Location = new System.Drawing.Point(273, 325);
            this.ClientNouButton.Name = "ClientNouButton";
            this.ClientNouButton.Size = new System.Drawing.Size(120, 33);
            this.ClientNouButton.TabIndex = 7;
            this.ClientNouButton.Text = "Client Nou";
            this.ClientNouButton.UseSelectable = true;
            this.ClientNouButton.Click += new System.EventHandler(this.ClientNouButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(193, 377);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(120, 33);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Inchide";
            this.CloseButton.UseSelectable = true;
            this.CloseButton.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Proiect.Properties.Resources._11;
            this.pictureBox1.Location = new System.Drawing.Point(476, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ClientNou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 457);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ClientNouButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.AdresaTextBox);
            this.Controls.Add(this.TelefonTextBox);
            this.Controls.Add(this.NumeClientTextBox);
            this.Name = "ClientNou";
            this.Text = "Client Nou";
            this.Load += new System.EventHandler(this.ClientNou_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumeClientTextBox;
        private System.Windows.Forms.TextBox TelefonTextBox;
        private System.Windows.Forms.TextBox AdresaTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroButton ClientNouButton;
        private MetroFramework.Controls.MetroButton CloseButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}