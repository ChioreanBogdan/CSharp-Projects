namespace Cabinet_medical
{
    partial class Ad_cont
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
            this.continut = new System.Windows.Forms.RichTextBox();
            this.titlu = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // continut
            // 
            this.continut.Location = new System.Drawing.Point(66, 101);
            this.continut.MaxLength = 200;
            this.continut.Name = "continut";
            this.continut.Size = new System.Drawing.Size(415, 250);
            this.continut.TabIndex = 0;
            this.continut.Text = "";
            // 
            // titlu
            // 
            this.titlu.AutoSize = true;
            this.titlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlu.Location = new System.Drawing.Point(218, 42);
            this.titlu.Name = "titlu";
            this.titlu.Size = new System.Drawing.Size(96, 32);
            this.titlu.TabIndex = 1;
            this.titlu.Text = "mesaj";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Renunta";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Ad_cont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 452);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.titlu);
            this.Controls.Add(this.continut);
            this.Name = "Ad_cont";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox continut;
        private System.Windows.Forms.Label titlu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}