namespace Hamzawey
{
    partial class load
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
            this.components = new System.ComponentModel.Container();
            this.prog = new Bunifu.Framework.UI.BunifuProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblmove = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // prog
            // 
            this.prog.BackColor = System.Drawing.Color.Silver;
            this.prog.BorderRadius = 5;
            this.prog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prog.Location = new System.Drawing.Point(0, 213);
            this.prog.Margin = new System.Windows.Forms.Padding(6);
            this.prog.MaximumValue = 100;
            this.prog.Name = "prog";
            this.prog.ProgressColor = System.Drawing.Color.Teal;
            this.prog.Size = new System.Drawing.Size(694, 16);
            this.prog.TabIndex = 0;
            this.prog.Value = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Hamzawey.Properties.Resources.icons8_loading_sign_64;
            this.pictureBox1.Location = new System.Drawing.Point(324, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblmove
            // 
            this.lblmove.AutoSize = true;
            this.lblmove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblmove.ForeColor = System.Drawing.Color.White;
            this.lblmove.Location = new System.Drawing.Point(235, 9);
            this.lblmove.Name = "lblmove";
            this.lblmove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblmove.Size = new System.Drawing.Size(229, 26);
            this.lblmove.TabIndex = 20;
            this.lblmove.Text = "برنامج ادارة مخازن الأقمشة";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(376, 213);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(8, 8);
            this.progressBar1.TabIndex = 21;
            // 
            // load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Hamzawey.Properties.Resources.pngtree_beautiful_dreamy_atmosphere_late_summer_sale_banner_background_image_520193;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(694, 229);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblmove);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.prog);
            this.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "load";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar prog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblmove;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}