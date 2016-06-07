namespace BankOperationEnrichment
{
    partial class PreviewFile
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
            this.dataGridPreview = new System.Windows.Forms.DataGridView();
            this.lblColDate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbMapping = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblColRecette = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblColDepense = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblColLibelle = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreview)).BeginInit();
            this.gbMapping.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridPreview
            // 
            this.dataGridPreview.AllowUserToAddRows = false;
            this.dataGridPreview.AllowUserToDeleteRows = false;
            this.dataGridPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridPreview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPreview.Location = new System.Drawing.Point(13, 13);
            this.dataGridPreview.Name = "dataGridPreview";
            this.dataGridPreview.ReadOnly = true;
            this.dataGridPreview.Size = new System.Drawing.Size(461, 164);
            this.dataGridPreview.TabIndex = 0;
            // 
            // lblColDate
            // 
            this.lblColDate.AutoSize = true;
            this.lblColDate.Location = new System.Drawing.Point(6, 22);
            this.lblColDate.Name = "lblColDate";
            this.lblColDate.Size = new System.Drawing.Size(79, 13);
            this.lblColDate.TabIndex = 1;
            this.lblColDate.Text = "Date Opération";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // gbMapping
            // 
            this.gbMapping.Controls.Add(this.textBox4);
            this.gbMapping.Controls.Add(this.lblColRecette);
            this.gbMapping.Controls.Add(this.textBox3);
            this.gbMapping.Controls.Add(this.lblColDepense);
            this.gbMapping.Controls.Add(this.textBox2);
            this.gbMapping.Controls.Add(this.lblColLibelle);
            this.gbMapping.Controls.Add(this.textBox1);
            this.gbMapping.Controls.Add(this.lblColDate);
            this.gbMapping.Location = new System.Drawing.Point(480, 13);
            this.gbMapping.Name = "gbMapping";
            this.gbMapping.Size = new System.Drawing.Size(229, 135);
            this.gbMapping.TabIndex = 3;
            this.gbMapping.TabStop = false;
            this.gbMapping.Text = "Mapping des colonnes";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(123, 108);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            // 
            // lblColRecette
            // 
            this.lblColRecette.AutoSize = true;
            this.lblColRecette.Location = new System.Drawing.Point(6, 111);
            this.lblColRecette.Name = "lblColRecette";
            this.lblColRecette.Size = new System.Drawing.Size(45, 13);
            this.lblColRecette.TabIndex = 7;
            this.lblColRecette.Text = "Recette";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(123, 79);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // lblColDepense
            // 
            this.lblColDepense.AutoSize = true;
            this.lblColDepense.Location = new System.Drawing.Point(6, 82);
            this.lblColDepense.Name = "lblColDepense";
            this.lblColDepense.Size = new System.Drawing.Size(50, 13);
            this.lblColDepense.TabIndex = 5;
            this.lblColDepense.Text = "Dépense";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(123, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // lblColLibelle
            // 
            this.lblColLibelle.AutoSize = true;
            this.lblColLibelle.Location = new System.Drawing.Point(6, 52);
            this.lblColLibelle.Name = "lblColLibelle";
            this.lblColLibelle.Size = new System.Drawing.Size(86, 13);
            this.lblColLibelle.TabIndex = 3;
            this.lblColLibelle.Text = "Libellé Opération";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(553, 154);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Valider";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(634, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PreviewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 187);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.gbMapping);
            this.Controls.Add(this.dataGridPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = false;
            this.Name = "PreviewFile";
            this.Text = "Aperçu du fichier";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreview)).EndInit();
            this.gbMapping.ResumeLayout(false);
            this.gbMapping.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblColDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbMapping;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblColDepense;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblColLibelle;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblColRecette;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DataGridView dataGridPreview;
    }
}