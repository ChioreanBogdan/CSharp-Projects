namespace RPG
{
    partial class Mesaj_atac
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
            this.desc_atac = new System.Windows.Forms.Label();
            this.timer_msg_atc = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // desc_atac
            // 
            this.desc_atac.AutoSize = true;
            this.desc_atac.Font = new System.Drawing.Font("Blackadder ITC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_atac.Location = new System.Drawing.Point(132, 95);
            this.desc_atac.Name = "desc_atac";
            this.desc_atac.Size = new System.Drawing.Size(120, 46);
            this.desc_atac.TabIndex = 0;
            this.desc_atac.Text = "descriere";
            // 
            // timer_msg_atc
            // 
            this.timer_msg_atc.Tick += new System.EventHandler(this.timer_msg_atc_Tick);
            // 
            // Mesaj_atac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 346);
            this.Controls.Add(this.desc_atac);
            this.Name = "Mesaj_atac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atac!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label desc_atac;
        private System.Windows.Forms.Timer timer_msg_atc;
    }
}