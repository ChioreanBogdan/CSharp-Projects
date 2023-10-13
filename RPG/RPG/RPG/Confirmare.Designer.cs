namespace RPG
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
            this.Text_Confirm = new System.Windows.Forms.Label();
            this.Da = new System.Windows.Forms.Button();
            this.Nu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text_Confirm
            // 
            this.Text_Confirm.AutoSize = true;
            this.Text_Confirm.Font = new System.Drawing.Font("Blackadder ITC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Confirm.Location = new System.Drawing.Point(75, 60);
            this.Text_Confirm.Name = "Text_Confirm";
            this.Text_Confirm.Size = new System.Drawing.Size(60, 41);
            this.Text_Confirm.TabIndex = 0;
            this.Text_Confirm.Text = "text";
            // 
            // Da
            // 
            this.Da.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Da.Font = new System.Drawing.Font("Blackadder ITC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Da.Location = new System.Drawing.Point(65, 192);
            this.Da.Name = "Da";
            this.Da.Size = new System.Drawing.Size(130, 56);
            this.Da.TabIndex = 1;
            this.Da.Text = "Da";
            this.Da.UseVisualStyleBackColor = true;
            // 
            // Nu
            // 
            this.Nu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Nu.Font = new System.Drawing.Font("Blackadder ITC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nu.Location = new System.Drawing.Point(290, 192);
            this.Nu.Name = "Nu";
            this.Nu.Size = new System.Drawing.Size(130, 56);
            this.Nu.TabIndex = 2;
            this.Nu.Text = "Nu";
            this.Nu.UseVisualStyleBackColor = true;
            // 
            // Confirmare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(496, 351);
            this.Controls.Add(this.Nu);
            this.Controls.Add(this.Da);
            this.Controls.Add(this.Text_Confirm);
            this.Name = "Confirmare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Text_Confirm;
        private System.Windows.Forms.Button Da;
        private System.Windows.Forms.Button Nu;
    }
}