namespace RPG
{
    partial class Teren_ostil
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
            this.Lupta_noua = new System.Windows.Forms.Button();
            this.Inapoi = new System.Windows.Forms.Button();
            this.Alege = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lupta_noua
            // 
            this.Lupta_noua.BackColor = System.Drawing.Color.Transparent;
            this.Lupta_noua.Font = new System.Drawing.Font("Blackadder ITC", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lupta_noua.Location = new System.Drawing.Point(559, 673);
            this.Lupta_noua.Name = "Lupta_noua";
            this.Lupta_noua.Size = new System.Drawing.Size(834, 122);
            this.Lupta_noua.TabIndex = 0;
            this.Lupta_noua.Text = "text lupta noua";
            this.Lupta_noua.UseVisualStyleBackColor = false;
            this.Lupta_noua.Click += new System.EventHandler(this.Lupta_noua_Click);
            // 
            // Inapoi
            // 
            this.Inapoi.Font = new System.Drawing.Font("Blackadder ITC", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inapoi.Location = new System.Drawing.Point(559, 862);
            this.Inapoi.Name = "Inapoi";
            this.Inapoi.Size = new System.Drawing.Size(834, 122);
            this.Inapoi.TabIndex = 1;
            this.Inapoi.Text = "text inapoi";
            this.Inapoi.UseVisualStyleBackColor = true;
            this.Inapoi.Click += new System.EventHandler(this.Inapoi_Click);
            // 
            // Alege
            // 
            this.Alege.AutoSize = true;
            this.Alege.BackColor = System.Drawing.Color.Transparent;
            this.Alege.Font = new System.Drawing.Font("Blackadder ITC", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alege.ForeColor = System.Drawing.Color.LightGray;
            this.Alege.Location = new System.Drawing.Point(713, 576);
            this.Alege.Name = "Alege";
            this.Alege.Size = new System.Drawing.Size(499, 72);
            this.Alege.TabIndex = 2;
            this.Alege.Text = "Alege actiunea grupului :";
            // 
            // Teren_ostil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1910, 1034);
            this.Controls.Add(this.Alege);
            this.Controls.Add(this.Inapoi);
            this.Controls.Add(this.Lupta_noua);
            this.Name = "Teren_ostil";
            this.Text = "Teren_ostil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lupta_noua;
        private System.Windows.Forms.Button Inapoi;
        private System.Windows.Forms.Label Alege;
    }
}