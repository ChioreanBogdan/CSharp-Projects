namespace Cabinet_medical
{
    partial class Ad_pres2
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
            this.cant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.um = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.med = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.zi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medicament :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantitate :";
            // 
            // cant
            // 
            this.cant.Location = new System.Drawing.Point(162, 157);
            this.cant.MaxLength = 6;
            this.cant.Name = "cant";
            this.cant.Size = new System.Drawing.Size(112, 26);
            this.cant.TabIndex = 3;
            this.cant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cant_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unitate de masura :";
            // 
            // um
            // 
            this.um.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.um.FormattingEnabled = true;
            this.um.Location = new System.Drawing.Point(450, 160);
            this.um.Name = "um";
            this.um.Size = new System.Drawing.Size(113, 28);
            this.um.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Adauga medicament";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "Finalizeaza prescriptie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(414, 268);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 44);
            this.button3.TabIndex = 10;
            this.button3.Text = "Renunta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // med
            // 
            this.med.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.med.FormattingEnabled = true;
            this.med.Location = new System.Drawing.Point(162, 51);
            this.med.Name = "med";
            this.med.Size = new System.Drawing.Size(401, 28);
            this.med.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(276, 98);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 37);
            this.button4.TabIndex = 13;
            this.button4.Text = "Medicament nou";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Pe durata a :";
            // 
            // zi
            // 
            this.zi.Location = new System.Drawing.Point(316, 200);
            this.zi.MaxLength = 3;
            this.zi.Name = "zi";
            this.zi.Size = new System.Drawing.Size(60, 26);
            this.zi.TabIndex = 15;
            this.zi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zi_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "zile";
            // 
            // Ad_pres2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 323);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.med);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.um);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Ad_pres2";
            this.Text = "Adauga prescriptie 2/2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox um;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox med;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox zi;
        private System.Windows.Forms.Label label5;
    }
}