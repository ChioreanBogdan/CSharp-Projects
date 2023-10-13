namespace Cabinet_medical
{
    partial class Viz_Pres
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
            this.pac = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pres_grid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pres_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pac
            // 
            this.pac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pac.FormattingEnabled = true;
            this.pac.Location = new System.Drawing.Point(30, 197);
            this.pac.Name = "pac";
            this.pac.Size = new System.Drawing.Size(269, 28);
            this.pac.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alegeti pacientul :";
            // 
            // pres_grid
            // 
            this.pres_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pres_grid.Location = new System.Drawing.Point(330, 12);
            this.pres_grid.Name = "pres_grid";
            this.pres_grid.RowTemplate.Height = 28;
            this.pres_grid.Size = new System.Drawing.Size(790, 530);
            this.pres_grid.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cauta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "Renunta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Viz_Pres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pres_grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pac);
            this.Name = "Viz_Pres";
            this.Text = "Vizualizare prescriptii";
            ((System.ComponentModel.ISupportInitialize)(this.pres_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView pres_grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}