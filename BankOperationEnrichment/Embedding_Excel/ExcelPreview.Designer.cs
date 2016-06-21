namespace EmbeddedExcel
{
    partial class ExcelPreview
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtStartLineNumber = new System.Windows.Forms.TextBox();
            this.lblStartLineNumber = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.gbMapping = new System.Windows.Forms.GroupBox();
            this.txtColRecette = new System.Windows.Forms.TextBox();
            this.lblColRecette = new System.Windows.Forms.Label();
            this.txtColDepense = new System.Windows.Forms.TextBox();
            this.lblColDepense = new System.Windows.Forms.Label();
            this.txtColLibOperation = new System.Windows.Forms.TextBox();
            this.lblColLibelle = new System.Windows.Forms.Label();
            this.txtColDateOperation = new System.Windows.Forms.TextBox();
            this.lblColDate = new System.Windows.Forms.Label();
            this.excelWrapper1 = new EmbeddedExcel.ExcelWrapper();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblColNumOperation = new System.Windows.Forms.Label();
            this.txtColNumOperation = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbMapping.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtStartLineNumber);
            this.splitContainer1.Panel1.Controls.Add(this.lblStartLineNumber);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnContinue);
            this.splitContainer1.Panel1.Controls.Add(this.gbMapping);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.excelWrapper1);
            this.splitContainer1.Size = new System.Drawing.Size(713, 302);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtStartLineNumber
            // 
            this.txtStartLineNumber.Location = new System.Drawing.Point(142, 176);
            this.txtStartLineNumber.MaxLength = 2;
            this.txtStartLineNumber.Name = "txtStartLineNumber";
            this.txtStartLineNumber.Size = new System.Drawing.Size(33, 20);
            this.txtStartLineNumber.TabIndex = 8;
            this.txtStartLineNumber.Text = "2";
            // 
            // lblStartLineNumber
            // 
            this.lblStartLineNumber.AutoSize = true;
            this.lblStartLineNumber.Location = new System.Drawing.Point(15, 179);
            this.lblStartLineNumber.Name = "lblStartLineNumber";
            this.lblStartLineNumber.Size = new System.Drawing.Size(81, 13);
            this.lblStartLineNumber.TabIndex = 1;
            this.lblStartLineNumber.Text = "Ligne de départ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(102, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(21, 208);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "Valider";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // gbMapping
            // 
            this.gbMapping.Controls.Add(this.txtColNumOperation);
            this.gbMapping.Controls.Add(this.lblColNumOperation);
            this.gbMapping.Controls.Add(this.txtColRecette);
            this.gbMapping.Controls.Add(this.lblColRecette);
            this.gbMapping.Controls.Add(this.txtColDepense);
            this.gbMapping.Controls.Add(this.lblColDepense);
            this.gbMapping.Controls.Add(this.txtColLibOperation);
            this.gbMapping.Controls.Add(this.lblColLibelle);
            this.gbMapping.Controls.Add(this.txtColDateOperation);
            this.gbMapping.Controls.Add(this.lblColDate);
            this.gbMapping.Location = new System.Drawing.Point(11, 12);
            this.gbMapping.Name = "gbMapping";
            this.gbMapping.Size = new System.Drawing.Size(172, 155);
            this.gbMapping.TabIndex = 4;
            this.gbMapping.TabStop = false;
            this.gbMapping.Text = "Mapping des colonnes";
            // 
            // txtColRecette
            // 
            this.txtColRecette.Location = new System.Drawing.Point(133, 123);
            this.txtColRecette.MaxLength = 1;
            this.txtColRecette.Name = "txtColRecette";
            this.txtColRecette.Size = new System.Drawing.Size(33, 20);
            this.txtColRecette.TabIndex = 8;
            this.txtColRecette.Text = "F";
            // 
            // lblColRecette
            // 
            this.lblColRecette.AutoSize = true;
            this.lblColRecette.Location = new System.Drawing.Point(6, 126);
            this.lblColRecette.Name = "lblColRecette";
            this.lblColRecette.Size = new System.Drawing.Size(45, 13);
            this.lblColRecette.TabIndex = 7;
            this.lblColRecette.Text = "Recette";
            // 
            // txtColDepense
            // 
            this.txtColDepense.Location = new System.Drawing.Point(133, 97);
            this.txtColDepense.MaxLength = 1;
            this.txtColDepense.Name = "txtColDepense";
            this.txtColDepense.Size = new System.Drawing.Size(33, 20);
            this.txtColDepense.TabIndex = 6;
            this.txtColDepense.Text = "E";
            // 
            // lblColDepense
            // 
            this.lblColDepense.AutoSize = true;
            this.lblColDepense.Location = new System.Drawing.Point(7, 100);
            this.lblColDepense.Name = "lblColDepense";
            this.lblColDepense.Size = new System.Drawing.Size(50, 13);
            this.lblColDepense.TabIndex = 5;
            this.lblColDepense.Text = "Dépense";
            // 
            // txtColLibOperation
            // 
            this.txtColLibOperation.Location = new System.Drawing.Point(133, 45);
            this.txtColLibOperation.MaxLength = 1;
            this.txtColLibOperation.Name = "txtColLibOperation";
            this.txtColLibOperation.Size = new System.Drawing.Size(33, 20);
            this.txtColLibOperation.TabIndex = 4;
            this.txtColLibOperation.Text = "C";
            // 
            // lblColLibelle
            // 
            this.lblColLibelle.AutoSize = true;
            this.lblColLibelle.Location = new System.Drawing.Point(6, 48);
            this.lblColLibelle.Name = "lblColLibelle";
            this.lblColLibelle.Size = new System.Drawing.Size(86, 13);
            this.lblColLibelle.TabIndex = 3;
            this.lblColLibelle.Text = "Libellé Opération";
            // 
            // txtColDateOperation
            // 
            this.txtColDateOperation.Location = new System.Drawing.Point(133, 19);
            this.txtColDateOperation.MaxLength = 1;
            this.txtColDateOperation.Name = "txtColDateOperation";
            this.txtColDateOperation.Size = new System.Drawing.Size(33, 20);
            this.txtColDateOperation.TabIndex = 2;
            this.txtColDateOperation.Text = "A";
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
            // excelWrapper1
            // 
            this.excelWrapper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelWrapper1.Location = new System.Drawing.Point(0, 0);
            this.excelWrapper1.Name = "excelWrapper1";
            this.excelWrapper1.Size = new System.Drawing.Size(514, 302);
            this.excelWrapper1.TabIndex = 0;
            this.excelWrapper1.ToolBarVisible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files | *.xls";
            // 
            // lblColNumOperation
            // 
            this.lblColNumOperation.AutoSize = true;
            this.lblColNumOperation.Location = new System.Drawing.Point(6, 74);
            this.lblColNumOperation.Name = "lblColNumOperation";
            this.lblColNumOperation.Size = new System.Drawing.Size(93, 13);
            this.lblColNumOperation.TabIndex = 9;
            this.lblColNumOperation.Text = "Numéro Opération";
            // 
            // txtColNumOperation
            // 
            this.txtColNumOperation.Location = new System.Drawing.Point(133, 71);
            this.txtColNumOperation.Name = "txtColNumOperation";
            this.txtColNumOperation.Size = new System.Drawing.Size(33, 20);
            this.txtColNumOperation.TabIndex = 10;
            this.txtColNumOperation.Text = "D";
            // 
            // ExcelPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 302);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ExcelPreview";
            this.Text = "Prévisualisation fichier Excel";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbMapping.ResumeLayout(false);
            this.gbMapping.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ExcelWrapper excelWrapper1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbMapping;
        private System.Windows.Forms.TextBox txtColRecette;
        private System.Windows.Forms.Label lblColRecette;
        private System.Windows.Forms.TextBox txtColDepense;
        private System.Windows.Forms.Label lblColDepense;
        private System.Windows.Forms.TextBox txtColLibOperation;
        private System.Windows.Forms.Label lblColLibelle;
        private System.Windows.Forms.TextBox txtColDateOperation;
        private System.Windows.Forms.Label lblColDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox txtStartLineNumber;
        private System.Windows.Forms.Label lblStartLineNumber;
        private System.Windows.Forms.TextBox txtColNumOperation;
        private System.Windows.Forms.Label lblColNumOperation;
    }
}

