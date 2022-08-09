
namespace AmiralBATTİİ
{
    partial class ServerConnectionPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConnectionPanel));
            this.BConnect = new System.Windows.Forms.Button();
            this.TBServerIP = new System.Windows.Forms.TextBox();
            this.TBNick = new System.Windows.Forms.TextBox();
            this.LServerIP = new System.Windows.Forms.Label();
            this.LNick = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BConnect
            // 
            this.BConnect.BackColor = System.Drawing.Color.OrangeRed;
            this.BConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BConnect.ForeColor = System.Drawing.Color.White;
            this.BConnect.Location = new System.Drawing.Point(395, 197);
            this.BConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BConnect.Name = "BConnect";
            this.BConnect.Size = new System.Drawing.Size(159, 28);
            this.BConnect.TabIndex = 11;
            this.BConnect.Text = "Connect";
            this.BConnect.UseVisualStyleBackColor = false;
            this.BConnect.Click += new System.EventHandler(this.BConnect_Click);
            // 
            // TBServerIP
            // 
            this.TBServerIP.Location = new System.Drawing.Point(395, 153);
            this.TBServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.TBServerIP.Name = "TBServerIP";
            this.TBServerIP.Size = new System.Drawing.Size(157, 22);
            this.TBNick.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EnterClicked);
            this.TBServerIP.TabIndex = 10;
            // 
            // TBNick
            // 
            this.TBNick.Location = new System.Drawing.Point(395, 111);
            this.TBNick.Margin = new System.Windows.Forms.Padding(4);
            this.TBNick.MaxLength = 16;
            this.TBNick.Name = "TBNick";
            this.TBNick.Size = new System.Drawing.Size(157, 22);
            this.TBNick.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EnterClicked);
            this.TBNick.TabIndex = 9;
            // 
            // LServerIP
            // 
            this.LServerIP.AutoSize = true;
            this.LServerIP.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.LServerIP.Location = new System.Drawing.Point(355, 153);
            this.LServerIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LServerIP.Name = "LServerIP";
            this.LServerIP.Size = new System.Drawing.Size(32, 26);
            this.LServerIP.TabIndex = 8;
            this.LServerIP.Text = "IP:";
            // 
            // LNick
            // 
            this.LNick.AutoSize = true;
            this.LNick.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.LNick.Location = new System.Drawing.Point(291, 111);
            this.LNick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LNick.Name = "LNick";
            this.LNick.Size = new System.Drawing.Size(98, 26);
            this.LNick.TabIndex = 7;
            this.LNick.Text = "User name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 283);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ServerConnectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 341);
            this.Controls.Add(this.BConnect);
            this.Controls.Add(this.TBServerIP);
            this.Controls.Add(this.TBNick);
            this.Controls.Add(this.LServerIP);
            this.Controls.Add(this.LNick);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ServerConnectionPanel";
            this.Text = "ServerConnectionPanel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BConnect;
        private System.Windows.Forms.TextBox TBServerIP;
        private System.Windows.Forms.TextBox TBNick;
        private System.Windows.Forms.Label LServerIP;
        private System.Windows.Forms.Label LNick;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}