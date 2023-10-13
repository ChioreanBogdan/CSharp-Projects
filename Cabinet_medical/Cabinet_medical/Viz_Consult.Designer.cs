namespace Cabinet_medical
{
    partial class Viz_Consult
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
            this.mesaj = new System.Windows.Forms.Label();
            this.dat = new System.Windows.Forms.DateTimePicker();
            this.consult_grid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mesaj2 = new System.Windows.Forms.Label();
            this.Interval_inc = new System.Windows.Forms.DateTimePicker();
            this.mesaj3 = new System.Windows.Forms.Label();
            this.Interval_fin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.consult_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // mesaj
            // 
            this.mesaj.AutoSize = true;
            this.mesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesaj.Location = new System.Drawing.Point(50, 204);
            this.mesaj.Name = "mesaj";
            this.mesaj.Size = new System.Drawing.Size(124, 25);
            this.mesaj.TabIndex = 0;
            this.mesaj.Text = "Alegeti ziua :";
            // 
            // dat
            // 
            this.dat.Location = new System.Drawing.Point(35, 242);
            this.dat.Name = "dat";
            this.dat.Size = new System.Drawing.Size(336, 26);
            this.dat.TabIndex = 1;
            // 
            // consult_grid
            // 
            this.consult_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consult_grid.Location = new System.Drawing.Point(384, 12);
            this.consult_grid.Name = "consult_grid";
            this.consult_grid.RowTemplate.Height = 28;
            this.consult_grid.Size = new System.Drawing.Size(643, 577);
            this.consult_grid.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cauta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "Inapoi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mesaj2
            // 
            this.mesaj2.AutoSize = true;
            this.mesaj2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesaj2.Location = new System.Drawing.Point(30, 12);
            this.mesaj2.Name = "mesaj2";
            this.mesaj2.Size = new System.Drawing.Size(263, 25);
            this.mesaj2.TabIndex = 5;
            this.mesaj2.Text = "Alegeti inceputul intervalului :";
            // 
            // Interval_inc
            // 
            this.Interval_inc.Location = new System.Drawing.Point(35, 50);
            this.Interval_inc.Name = "Interval_inc";
            this.Interval_inc.Size = new System.Drawing.Size(336, 26);
            this.Interval_inc.TabIndex = 6;
            // 
            // mesaj3
            // 
            this.mesaj3.AutoSize = true;
            this.mesaj3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesaj3.Location = new System.Drawing.Point(30, 102);
            this.mesaj3.Name = "mesaj3";
            this.mesaj3.Size = new System.Drawing.Size(251, 25);
            this.mesaj3.TabIndex = 7;
            this.mesaj3.Text = "Alegeti sfarsitul intervalului :";
            // 
            // Interval_fin
            // 
            this.Interval_fin.Location = new System.Drawing.Point(35, 146);
            this.Interval_fin.Name = "Interval_fin";
            this.Interval_fin.Size = new System.Drawing.Size(336, 26);
            this.Interval_fin.TabIndex = 8;
            // 
            // Viz_Consult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 617);
            this.Controls.Add(this.Interval_fin);
            this.Controls.Add(this.mesaj3);
            this.Controls.Add(this.Interval_inc);
            this.Controls.Add(this.mesaj2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.consult_grid);
            this.Controls.Add(this.dat);
            this.Controls.Add(this.mesaj);
            this.Name = "Viz_Consult";
            this.Text = "Vizualizare consultatii";
            ((System.ComponentModel.ISupportInitialize)(this.consult_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mesaj;
        private System.Windows.Forms.DateTimePicker dat;
        private System.Windows.Forms.DataGridView consult_grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label mesaj2;
        private System.Windows.Forms.DateTimePicker Interval_inc;
        private System.Windows.Forms.Label mesaj3;
        private System.Windows.Forms.DateTimePicker Interval_fin;
    }
}