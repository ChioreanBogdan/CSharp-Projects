namespace RPG
{
    partial class Ecran_sfarsit_lupta
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
            this.rezultat_lupta = new System.Windows.Forms.Label();
            this.restart_lupta = new System.Windows.Forms.Button();
            this.buton_meniu_p = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rezultat_lupta
            // 
            this.rezultat_lupta.AutoSize = true;
            this.rezultat_lupta.Font = new System.Drawing.Font("Blackadder ITC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rezultat_lupta.Location = new System.Drawing.Point(299, 66);
            this.rezultat_lupta.Name = "rezultat_lupta";
            this.rezultat_lupta.Size = new System.Drawing.Size(162, 63);
            this.rezultat_lupta.TabIndex = 0;
            this.rezultat_lupta.Text = "descriere";
            // 
            // restart_lupta
            // 
            this.restart_lupta.Font = new System.Drawing.Font("Blackadder ITC", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart_lupta.Location = new System.Drawing.Point(258, 259);
            this.restart_lupta.Name = "restart_lupta";
            this.restart_lupta.Size = new System.Drawing.Size(454, 148);
            this.restart_lupta.TabIndex = 1;
            this.restart_lupta.Text = "Reîncearca";
            this.restart_lupta.UseVisualStyleBackColor = true;
            this.restart_lupta.Click += new System.EventHandler(this.restart_lupta_Click);
            // 
            // buton_meniu_p
            // 
            this.buton_meniu_p.Font = new System.Drawing.Font("Blackadder ITC", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buton_meniu_p.Location = new System.Drawing.Point(258, 452);
            this.buton_meniu_p.Name = "buton_meniu_p";
            this.buton_meniu_p.Size = new System.Drawing.Size(454, 148);
            this.buton_meniu_p.TabIndex = 2;
            this.buton_meniu_p.Text = "Înapoi";
            this.buton_meniu_p.UseVisualStyleBackColor = true;
            this.buton_meniu_p.Click += new System.EventHandler(this.buton_meniu_p_Click);
            // 
            // Ecran_sfarsit_lupta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 657);
            this.Controls.Add(this.buton_meniu_p);
            this.Controls.Add(this.restart_lupta);
            this.Controls.Add(this.rezultat_lupta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ecran_sfarsit_lupta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concluzie luptă";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rezultat_lupta;
        private System.Windows.Forms.Button restart_lupta;
        private System.Windows.Forms.Button buton_meniu_p;
    }
}