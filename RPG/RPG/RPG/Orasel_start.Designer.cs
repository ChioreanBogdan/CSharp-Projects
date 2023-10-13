namespace RPG
{
    partial class Orasel_start
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
            this.han = new System.Windows.Forms.PictureBox();
            this.han_t = new System.Windows.Forms.PictureBox();
            this.ies = new System.Windows.Forms.PictureBox();
            this.ies_t = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.han)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.han_t)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ies_t)).BeginInit();
            this.SuspendLayout();
            // 
            // han
            // 
            this.han.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.han.BackColor = System.Drawing.Color.Transparent;
            this.han.Location = new System.Drawing.Point(720, 184);
            this.han.Name = "han";
            this.han.Size = new System.Drawing.Size(116, 316);
            this.han.TabIndex = 0;
            this.han.TabStop = false;
            this.han.MouseHover += new System.EventHandler(this.han_MouseHover);
            // 
            // han_t
            // 
            this.han_t.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.han_t.BackColor = System.Drawing.Color.Transparent;
            this.han_t.Location = new System.Drawing.Point(720, 184);
            this.han_t.Name = "han_t";
            this.han_t.Size = new System.Drawing.Size(116, 316);
            this.han_t.TabIndex = 1;
            this.han_t.TabStop = false;
            this.han_t.MouseLeave += new System.EventHandler(this.han_t_MouseLeave);
            // 
            // ies
            // 
            this.ies.BackColor = System.Drawing.Color.Transparent;
            this.ies.Location = new System.Drawing.Point(0, 476);
            this.ies.Name = "ies";
            this.ies.Size = new System.Drawing.Size(150, 142);
            this.ies.TabIndex = 2;
            this.ies.TabStop = false;
            this.ies.MouseHover += new System.EventHandler(this.ies_MouseHover);
            // 
            // ies_t
            // 
            this.ies_t.BackColor = System.Drawing.Color.Transparent;
            this.ies_t.Location = new System.Drawing.Point(0, 476);
            this.ies_t.Name = "ies_t";
            this.ies_t.Size = new System.Drawing.Size(150, 142);
            this.ies_t.TabIndex = 3;
            this.ies_t.TabStop = false;
            this.ies_t.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ies_t_MouseDoubleClick);
            this.ies_t.MouseLeave += new System.EventHandler(this.ies_t_MouseLeave);
            // 
            // Orasel_start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::RPG.Properties.Resources.orasel_start2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(998, 617);
            this.Controls.Add(this.ies_t);
            this.Controls.Add(this.ies);
            this.Controls.Add(this.han_t);
            this.Controls.Add(this.han);
            this.Name = "Orasel_start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orasel_start";
            ((System.ComponentModel.ISupportInitialize)(this.han)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.han_t)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ies_t)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox han;
        private System.Windows.Forms.PictureBox han_t;
        private System.Windows.Forms.PictureBox ies;
        private System.Windows.Forms.PictureBox ies_t;
    }
}