namespace Cabinet_medical
{
    partial class Ad_Pacient
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
            this.num = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prenum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.TextBox();
            this.adr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.emai = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.asig = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(142, 77);
            this.num.MaxLength = 45;
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(378, 26);
            this.num.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adauga pacient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Prenume";
            // 
            // prenum
            // 
            this.prenum.Location = new System.Drawing.Point(142, 127);
            this.prenum.MaxLength = 45;
            this.prenum.Name = "prenum";
            this.prenum.Size = new System.Drawing.Size(378, 26);
            this.prenum.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Telefon";
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(142, 175);
            this.tel.MaxLength = 10;
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(149, 26);
            this.tel.TabIndex = 6;
            // 
            // adr
            // 
            this.adr.Location = new System.Drawing.Point(142, 220);
            this.adr.MaxLength = 200;
            this.adr.Name = "adr";
            this.adr.Size = new System.Drawing.Size(499, 26);
            this.adr.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Adresa";
            // 
            // emai
            // 
            this.emai.AutoSize = true;
            this.emai.Location = new System.Drawing.Point(20, 264);
            this.emai.Name = "emai";
            this.emai.Size = new System.Drawing.Size(48, 20);
            this.emai.TabIndex = 9;
            this.emai.Text = "Email";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(142, 264);
            this.mail.MaxLength = 80;
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(378, 26);
            this.mail.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Asigurare";
            // 
            // asig
            // 
            this.asig.Location = new System.Drawing.Point(142, 304);
            this.asig.MaxLength = 45;
            this.asig.Name = "asig";
            this.asig.Size = new System.Drawing.Size(378, 26);
            this.asig.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(181, 374);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 44);
            this.button5.TabIndex = 19;
            this.button5.Text = "Adauga";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(341, 374);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 44);
            this.button6.TabIndex = 20;
            this.button6.Text = "Renunta";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Ad_Pacient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 441);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.asig);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.emai);
            this.Controls.Add(this.adr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.prenum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num);
            this.Controls.Add(this.label1);
            this.Name = "Ad_Pacient";
            this.Text = "Adauga pacient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prenum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox adr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label emai;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox asig;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}