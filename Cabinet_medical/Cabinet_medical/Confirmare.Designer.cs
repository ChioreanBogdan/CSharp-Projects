namespace Cabinet_medical
{
    partial class Confirmare
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
            this.text_conf = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.da = new System.Windows.Forms.Button();
            this.Nu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_conf
            // 
            this.text_conf.AutoSize = true;
            this.text_conf.Location = new System.Drawing.Point(24, 61);
            this.text_conf.Name = "text_conf";
            this.text_conf.Size = new System.Drawing.Size(114, 20);
            this.text_conf.TabIndex = 0;
            this.text_conf.Text = "text confirmare";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.text_conf);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 144);
            this.panel1.TabIndex = 1;
            // 
            // da
            // 
            this.da.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.da.Location = new System.Drawing.Point(43, 187);
            this.da.Name = "da";
            this.da.Size = new System.Drawing.Size(95, 45);
            this.da.TabIndex = 2;
            this.da.Text = "Da";
            this.da.UseVisualStyleBackColor = true;
            // 
            // Nu
            // 
            this.Nu.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Nu.Location = new System.Drawing.Point(200, 187);
            this.Nu.Name = "Nu";
            this.Nu.Size = new System.Drawing.Size(95, 45);
            this.Nu.TabIndex = 3;
            this.Nu.Text = "Nu";
            this.Nu.UseVisualStyleBackColor = true;
            // 
            // Confirmare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 263);
            this.Controls.Add(this.Nu);
            this.Controls.Add(this.da);
            this.Controls.Add(this.panel1);
            this.Name = "Confirmare";
            this.Text = "Confirmare";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label text_conf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button da;
        private System.Windows.Forms.Button Nu;
    }
}