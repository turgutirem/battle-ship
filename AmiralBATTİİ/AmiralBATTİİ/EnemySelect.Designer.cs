
namespace AmiralBATTİİ
{
    partial class EnemySelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DGVAvailableEnemies = new System.Windows.Forms.DataGridView();
            this.IPAndPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnemyNick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAvailableEnemies)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AmiralBATTİİ.Properties.Resources.MainPic;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 332);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // DGVAvailableEnemies
            // 
            this.DGVAvailableEnemies.AllowUserToAddRows = false;
            this.DGVAvailableEnemies.AllowUserToDeleteRows = false;
            this.DGVAvailableEnemies.AllowUserToResizeRows = false;
            this.DGVAvailableEnemies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVAvailableEnemies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAvailableEnemies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAvailableEnemies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAvailableEnemies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPAndPort,
            this.EnemyNick});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAvailableEnemies.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVAvailableEnemies.Location = new System.Drawing.Point(243, 12);
            this.DGVAvailableEnemies.Margin = new System.Windows.Forms.Padding(4);
            this.DGVAvailableEnemies.MultiSelect = false;
            this.DGVAvailableEnemies.Name = "DGVAvailableEnemies";
            this.DGVAvailableEnemies.ReadOnly = true;
            this.DGVAvailableEnemies.RowHeadersVisible = false;
            this.DGVAvailableEnemies.RowHeadersWidth = 51;
            this.DGVAvailableEnemies.Size = new System.Drawing.Size(355, 278);
            this.DGVAvailableEnemies.TabIndex = 10;
            this.DGVAvailableEnemies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAvailableEnemies_CellClick);
            // 
            // IPAndPort
            // 
            this.IPAndPort.HeaderText = "IPAndPort";
            this.IPAndPort.MinimumWidth = 6;
            this.IPAndPort.Name = "IPAndPort";
            this.IPAndPort.ReadOnly = true;
            this.IPAndPort.Visible = false;
            this.IPAndPort.Width = 125;
            // 
            // EnemyNick
            // 
            this.EnemyNick.HeaderText = "Enemy nick";
            this.EnemyNick.MinimumWidth = 6;
            this.EnemyNick.Name = "EnemyNick";
            this.EnemyNick.ReadOnly = true;
            this.EnemyNick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EnemyNick.Width = 249;
            // 
            // BConnect
            // 
            this.BConnect.BackColor = System.Drawing.Color.DarkOrange;
            this.BConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BConnect.ForeColor = System.Drawing.Color.White;
            this.BConnect.Location = new System.Drawing.Point(243, 316);
            this.BConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BConnect.Name = "BConnect";
            this.BConnect.Size = new System.Drawing.Size(355, 28);
            this.BConnect.TabIndex = 9;
            this.BConnect.Text = "Select enemy and play!";
            this.BConnect.UseVisualStyleBackColor = false;
            this.BConnect.Click += new System.EventHandler(this.BConnect_Click);
            // 
            // EnemySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 364);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DGVAvailableEnemies);
            this.Controls.Add(this.BConnect);
            this.Name = "EnemySelect";
            this.Text = "EnemySelect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseApp);
            this.Load += new System.EventHandler(this.EnemySelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAvailableEnemies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.DataGridView DGVAvailableEnemies;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAndPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnemyNick;
        private System.Windows.Forms.Button BConnect;
    }
}