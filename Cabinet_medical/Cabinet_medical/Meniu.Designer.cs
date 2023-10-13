namespace Cabinet_medical
{
    partial class Meniu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pacientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ad_pacientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.istoricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oreLibereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultatiiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programareToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.afisareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peIntervalOrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incarcareCabinetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.usr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacientiToolStripMenuItem,
            this.consultatiiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pacientiToolStripMenuItem
            // 
            this.pacientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ad_pacientToolStripMenuItem,
            this.istoricToolStripMenuItem,
            this.oreLibereToolStripMenuItem});
            this.pacientiToolStripMenuItem.Name = "pacientiToolStripMenuItem";
            this.pacientiToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.pacientiToolStripMenuItem.Text = "Pacienti";
            // 
            // ad_pacientToolStripMenuItem
            // 
            this.ad_pacientToolStripMenuItem.Name = "ad_pacientToolStripMenuItem";
            this.ad_pacientToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.ad_pacientToolStripMenuItem.Text = "Adaugare";
            this.ad_pacientToolStripMenuItem.Click += new System.EventHandler(this.ad_pacientToolStripMenuItem_Click);
            // 
            // istoricToolStripMenuItem
            // 
            this.istoricToolStripMenuItem.Name = "istoricToolStripMenuItem";
            this.istoricToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.istoricToolStripMenuItem.Text = "Istoric";
            this.istoricToolStripMenuItem.Click += new System.EventHandler(this.istoricToolStripMenuItem_Click);
            // 
            // oreLibereToolStripMenuItem
            // 
            this.oreLibereToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugareToolStripMenuItem,
            this.coToolStripMenuItem});
            this.oreLibereToolStripMenuItem.Name = "oreLibereToolStripMenuItem";
            this.oreLibereToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.oreLibereToolStripMenuItem.Text = "Prescriptii";
            // 
            // adaugareToolStripMenuItem
            // 
            this.adaugareToolStripMenuItem.Name = "adaugareToolStripMenuItem";
            this.adaugareToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.adaugareToolStripMenuItem.Text = "Adaugare";
            this.adaugareToolStripMenuItem.Click += new System.EventHandler(this.adaugareToolStripMenuItem_Click);
            // 
            // coToolStripMenuItem
            // 
            this.coToolStripMenuItem.Name = "coToolStripMenuItem";
            this.coToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.coToolStripMenuItem.Text = "Vizualizare";
            this.coToolStripMenuItem.Click += new System.EventHandler(this.coToolStripMenuItem_Click);
            // 
            // consultatiiToolStripMenuItem
            // 
            this.consultatiiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programareToolStripMenuItem1,
            this.afisareToolStripMenuItem});
            this.consultatiiToolStripMenuItem.Name = "consultatiiToolStripMenuItem";
            this.consultatiiToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.consultatiiToolStripMenuItem.Text = "Consultatii";
            // 
            // programareToolStripMenuItem1
            // 
            this.programareToolStripMenuItem1.Name = "programareToolStripMenuItem1";
            this.programareToolStripMenuItem1.Size = new System.Drawing.Size(210, 30);
            this.programareToolStripMenuItem1.Text = "Programare";
            this.programareToolStripMenuItem1.Click += new System.EventHandler(this.programareToolStripMenuItem1_Click);
            // 
            // afisareToolStripMenuItem
            // 
            this.afisareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peToolStripMenuItem,
            this.peIntervalOrarToolStripMenuItem,
            this.incarcareCabinetToolStripMenuItem});
            this.afisareToolStripMenuItem.Name = "afisareToolStripMenuItem";
            this.afisareToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.afisareToolStripMenuItem.Text = "Afisare";
            // 
            // peToolStripMenuItem
            // 
            this.peToolStripMenuItem.Name = "peToolStripMenuItem";
            this.peToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.peToolStripMenuItem.Text = "Pe zile";
            this.peToolStripMenuItem.Click += new System.EventHandler(this.peToolStripMenuItem_Click);
            // 
            // peIntervalOrarToolStripMenuItem
            // 
            this.peIntervalOrarToolStripMenuItem.Name = "peIntervalOrarToolStripMenuItem";
            this.peIntervalOrarToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.peIntervalOrarToolStripMenuItem.Text = "Pe interval orar";
            this.peIntervalOrarToolStripMenuItem.Click += new System.EventHandler(this.peIntervalOrarToolStripMenuItem_Click);
            // 
            // incarcareCabinetToolStripMenuItem
            // 
            this.incarcareCabinetToolStripMenuItem.Name = "incarcareCabinetToolStripMenuItem";
            this.incarcareCabinetToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.incarcareCabinetToolStripMenuItem.Text = "Incarcare cabinet";
            this.incarcareCabinetToolStripMenuItem.Click += new System.EventHandler(this.incarcareCabinetToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "User";
            // 
            // usr
            // 
            this.usr.Location = new System.Drawing.Point(125, 126);
            this.usr.Name = "usr";
            this.usr.Size = new System.Drawing.Size(361, 26);
            this.usr.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parola";
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(125, 179);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(361, 26);
            this.pwd.TabIndex = 4;
            this.pwd.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Acces";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Iesire";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Meniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 339);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Meniu";
            this.Text = "Cabinet medical";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pacientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ad_pacientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oreLibereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultatiiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programareToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem afisareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peIntervalOrarToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem istoricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incarcareCabinetToolStripMenuItem;
    }
}

