namespace RPG
{
    partial class Audio
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
            this.poz_volmuz = new System.Windows.Forms.Button();
            this.volmuz = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.poz_volsun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.volsun = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volmuz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volsun)).BeginInit();
            this.SuspendLayout();
            // 
            // poz_volmuz
            // 
            this.poz_volmuz.BackgroundImage = global::RPG.Properties.Resources.Sound_off;
            this.poz_volmuz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.poz_volmuz.Location = new System.Drawing.Point(53, 67);
            this.poz_volmuz.Name = "poz_volmuz";
            this.poz_volmuz.Size = new System.Drawing.Size(86, 86);
            this.poz_volmuz.TabIndex = 0;
            this.poz_volmuz.UseVisualStyleBackColor = true;
            this.poz_volmuz.Click += new System.EventHandler(this.poz_volmuz_Click);
            // 
            // volmuz
            // 
            this.volmuz.Location = new System.Drawing.Point(224, 84);
            this.volmuz.Name = "volmuz";
            this.volmuz.Size = new System.Drawing.Size(261, 69);
            this.volmuz.TabIndex = 1;
            this.volmuz.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volmuz.Scroll += new System.EventHandler(this.volmuz_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Volum muzică";
            // 
            // poz_volsun
            // 
            this.poz_volsun.BackgroundImage = global::RPG.Properties.Resources.Sound_off;
            this.poz_volsun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.poz_volsun.Location = new System.Drawing.Point(53, 231);
            this.poz_volsun.Name = "poz_volsun";
            this.poz_volsun.Size = new System.Drawing.Size(86, 86);
            this.poz_volsun.TabIndex = 5;
            this.poz_volsun.UseVisualStyleBackColor = true;
            this.poz_volsun.Click += new System.EventHandler(this.poz_volsun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Volum sunete";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "min";
            // 
            // volsun
            // 
            this.volsun.Location = new System.Drawing.Point(224, 248);
            this.volsun.Name = "volsun";
            this.volsun.Size = new System.Drawing.Size(261, 69);
            this.volsun.TabIndex = 7;
            this.volsun.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volsun.Scroll += new System.EventHandler(this.volsun_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 42);
            this.button1.TabIndex = 10;
            this.button1.Text = "Înapoi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 42);
            this.button2.TabIndex = 11;
            this.button2.Text = "Resetează";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Audio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 577);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.volsun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.poz_volsun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volmuz);
            this.Controls.Add(this.poz_volmuz);
            this.Name = "Audio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audio";
            ((System.ComponentModel.ISupportInitialize)(this.volmuz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volsun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button poz_volmuz;
        private System.Windows.Forms.TrackBar volmuz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button poz_volsun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar volsun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}