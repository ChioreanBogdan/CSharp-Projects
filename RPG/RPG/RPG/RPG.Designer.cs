namespace RPG
{
    partial class RPG
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.set = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.orasel_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 62);
            this.button1.TabIndex = 8;
            this.button1.Text = "Joc nou";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(241, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 63);
            this.button2.TabIndex = 9;
            this.button2.Text = "Încarcă";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(241, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 63);
            this.button3.TabIndex = 10;
            this.button3.Text = "Salvează";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(241, 394);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 63);
            this.button4.TabIndex = 11;
            this.button4.Text = "Ieșire";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // set
            // 
            this.set.Location = new System.Drawing.Point(241, 304);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(178, 63);
            this.set.TabIndex = 17;
            this.set.Text = "Setări";
            this.set.UseVisualStyleBackColor = true;
            this.set.Click += new System.EventHandler(this.set_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(72, 172);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(97, 60);
            this.test.TabIndex = 18;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // orasel_test
            // 
            this.orasel_test.Location = new System.Drawing.Point(461, 172);
            this.orasel_test.Name = "orasel_test";
            this.orasel_test.Size = new System.Drawing.Size(102, 60);
            this.orasel_test.TabIndex = 19;
            this.orasel_test.Text = "orasel";
            this.orasel_test.UseVisualStyleBackColor = true;
            this.orasel_test.Click += new System.EventHandler(this.orasel_test_Click);
            // 
            // RPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 516);
            this.Controls.Add(this.orasel_test);
            this.Controls.Add(this.test);
            this.Controls.Add(this.set);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "RPG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Button orasel_test;
    }
}

