namespace Cabinet_medical
{
    partial class Programare
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dat = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Timp_inc = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pac = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Timp_fin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.motiv = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume pacient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data:";
            // 
            // dat
            // 
            this.dat.Location = new System.Drawing.Point(196, 131);
            this.dat.Name = "dat";
            this.dat.Size = new System.Drawing.Size(324, 26);
            this.dat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ora inceput:";
            // 
            // Timp_inc
            // 
            this.Timp_inc.Location = new System.Drawing.Point(196, 202);
            this.Timp_inc.Name = "Timp_inc";
            this.Timp_inc.Size = new System.Drawing.Size(324, 26);
            this.Timp_inc.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 523);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Anuleaza";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pac
            // 
            this.pac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pac.FormattingEnabled = true;
            this.pac.Location = new System.Drawing.Point(196, 61);
            this.pac.Name = "pac";
            this.pac.Size = new System.Drawing.Size(324, 28);
            this.pac.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ora sfarsit:";
            // 
            // Timp_fin
            // 
            this.Timp_fin.Location = new System.Drawing.Point(196, 266);
            this.Timp_fin.Name = "Timp_fin";
            this.Timp_fin.Size = new System.Drawing.Size(324, 26);
            this.Timp_fin.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Motivul:";
            // 
            // motiv
            // 
            this.motiv.Location = new System.Drawing.Point(196, 341);
            this.motiv.Name = "motiv";
            this.motiv.Size = new System.Drawing.Size(324, 141);
            this.motiv.TabIndex = 12;
            this.motiv.Text = "";
            // 
            // Programare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 582);
            this.Controls.Add(this.motiv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Timp_fin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pac);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Timp_inc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Programare";
            this.Text = "Programare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Timp_inc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox pac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Timp_fin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox motiv;
    }
}