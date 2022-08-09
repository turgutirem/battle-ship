
namespace AmiralBATTİİ
{
    partial class OfferingGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfferingGame));
            this.label1 = new System.Windows.Forms.Label();
            this.CBEneNicks = new System.Windows.Forms.ComboBox();
            this.BNo = new System.Windows.Forms.Button();
            this.BYes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(257, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Choose one!";
            // 
            // CBEneNicks
            // 
            this.CBEneNicks.FormattingEnabled = true;
            this.CBEneNicks.Location = new System.Drawing.Point(262, 140);
            this.CBEneNicks.Margin = new System.Windows.Forms.Padding(4);
            this.CBEneNicks.Name = "CBEneNicks";
            this.CBEneNicks.Size = new System.Drawing.Size(333, 24);
            this.CBEneNicks.TabIndex = 15;
            // 
            // BNo
            // 
            this.BNo.BackColor = System.Drawing.Color.OrangeRed;
            this.BNo.Location = new System.Drawing.Point(442, 280);
            this.BNo.Margin = new System.Windows.Forms.Padding(4);
            this.BNo.Name = "BNo";
            this.BNo.Size = new System.Drawing.Size(155, 28);
            this.BNo.TabIndex = 14;
            this.BNo.Text = "Decline";
            this.BNo.UseVisualStyleBackColor = false;
            this.BNo.Click += new System.EventHandler(this.BNo_Click);
            // 
            // BYes
            // 
            this.BYes.BackColor = System.Drawing.Color.LawnGreen;
            this.BYes.Location = new System.Drawing.Point(265, 280);
            this.BYes.Margin = new System.Windows.Forms.Padding(4);
            this.BYes.Name = "BYes";
            this.BYes.Size = new System.Drawing.Size(155, 28);
            this.BYes.TabIndex = 13;
            this.BYes.Text = "Start Game";
            this.BYes.UseVisualStyleBackColor = false;
            this.BYes.Click += new System.EventHandler(this.BYes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(257, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enemies want to play with you,";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 374);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // OfferingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 405);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBEneNicks);
            this.Controls.Add(this.BNo);
            this.Controls.Add(this.BYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OfferingGame";
            this.Text = "OfferingGame";
            this.Load += new System.EventHandler(this.OfferingGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBEneNicks;
        private System.Windows.Forms.Button BNo;
        private System.Windows.Forms.Button BYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}