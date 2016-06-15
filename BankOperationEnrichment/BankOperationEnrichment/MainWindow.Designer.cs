namespace BankOperationEnrichment
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFilePath = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnSetRefCodeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtRefFilePath = new System.Windows.Forms.TextBox();
            this.rbTab = new System.Windows.Forms.RadioButton();
            this.rbColon = new System.Windows.Forms.RadioButton();
            this.groupDelimiter = new System.Windows.Forms.GroupBox();
            this.rbPipe = new System.Windows.Forms.RadioButton();
            this.lblExplNone = new System.Windows.Forms.Label();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbSpace = new System.Windows.Forms.RadioButton();
            this.rbSemiColon = new System.Windows.Forms.RadioButton();
            this.cbSheetName = new System.Windows.Forms.ComboBox();
            this.lblSheetName = new System.Windows.Forms.Label();
            this.gpFileType = new System.Windows.Forms.GroupBox();
            this.rbSourceAutre = new System.Windows.Forms.RadioButton();
            this.rbSourceCM = new System.Windows.Forms.RadioButton();
            this.rbSourceCA = new System.Windows.Forms.RadioButton();
            this.gpSourceFile = new System.Windows.Forms.GroupBox();
            this.gpReference = new System.Windows.Forms.GroupBox();
            this.cbRefSheetName = new System.Windows.Forms.ComboBox();
            this.btnRefFilePath = new System.Windows.Forms.Button();
            this.lblRefFileSheet = new System.Windows.Forms.Label();
            this.lblStatut = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupDelimiter.SuspendLayout();
            this.gpFileType.SuspendLayout();
            this.gpSourceFile.SuspendLayout();
            this.gpReference.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(382, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Fermer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFilePath
            // 
            this.btnFilePath.Location = new System.Drawing.Point(360, 17);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnFilePath.TabIndex = 1;
            this.btnFilePath.Text = "Parcourir ...";
            this.btnFilePath.UseVisualStyleBackColor = true;
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(301, 373);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Exécuter";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFilePath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtFilePath.Location = new System.Drawing.Point(6, 19);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(348, 20);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.Text = "Sélectionner un fichier à enrichir ...";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblVersion.Location = new System.Drawing.Point(9, 379);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 332);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(445, 23);
            this.progressBar.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.menuBtnHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBtnSetRefCodeFile,
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // menuBtnSetRefCodeFile
            // 
            this.menuBtnSetRefCodeFile.Name = "menuBtnSetRefCodeFile";
            this.menuBtnSetRefCodeFile.Size = new System.Drawing.Size(200, 22);
            this.menuBtnSetRefCodeFile.Text = "Fichier Codes Référence";
            this.menuBtnSetRefCodeFile.Click += new System.EventHandler(this.menuBtnSetRefCodeFile_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.settingsToolStripMenuItem.Text = "Paramétrage";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // menuBtnHelp
            // 
            this.menuBtnHelp.Name = "menuBtnHelp";
            this.menuBtnHelp.Size = new System.Drawing.Size(43, 20);
            this.menuBtnHelp.Text = "Aide";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtRefFilePath
            // 
            this.txtRefFilePath.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRefFilePath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtRefFilePath.Location = new System.Drawing.Point(6, 19);
            this.txtRefFilePath.Name = "txtRefFilePath";
            this.txtRefFilePath.ReadOnly = true;
            this.txtRefFilePath.Size = new System.Drawing.Size(348, 20);
            this.txtRefFilePath.TabIndex = 7;
            this.txtRefFilePath.Text = "Sélectionner un fichier référence ...";
            // 
            // rbTab
            // 
            this.rbTab.AutoSize = true;
            this.rbTab.Checked = true;
            this.rbTab.Location = new System.Drawing.Point(6, 19);
            this.rbTab.Name = "rbTab";
            this.rbTab.Size = new System.Drawing.Size(75, 17);
            this.rbTab.TabIndex = 10;
            this.rbTab.TabStop = true;
            this.rbTab.Text = "Tabulation";
            this.rbTab.UseVisualStyleBackColor = true;
            // 
            // rbColon
            // 
            this.rbColon.AutoSize = true;
            this.rbColon.Location = new System.Drawing.Point(87, 19);
            this.rbColon.Name = "rbColon";
            this.rbColon.Size = new System.Drawing.Size(57, 17);
            this.rbColon.TabIndex = 11;
            this.rbColon.Text = "Virgule";
            this.rbColon.UseVisualStyleBackColor = true;
            // 
            // groupDelimiter
            // 
            this.groupDelimiter.Controls.Add(this.rbPipe);
            this.groupDelimiter.Controls.Add(this.lblExplNone);
            this.groupDelimiter.Controls.Add(this.rbNone);
            this.groupDelimiter.Controls.Add(this.rbSpace);
            this.groupDelimiter.Controls.Add(this.rbSemiColon);
            this.groupDelimiter.Controls.Add(this.rbTab);
            this.groupDelimiter.Controls.Add(this.rbColon);
            this.groupDelimiter.Enabled = false;
            this.groupDelimiter.Location = new System.Drawing.Point(12, 258);
            this.groupDelimiter.Name = "groupDelimiter";
            this.groupDelimiter.Size = new System.Drawing.Size(445, 69);
            this.groupDelimiter.TabIndex = 12;
            this.groupDelimiter.TabStop = false;
            this.groupDelimiter.Text = "Type de Séparateur";
            // 
            // rbPipe
            // 
            this.rbPipe.AutoSize = true;
            this.rbPipe.Location = new System.Drawing.Point(6, 42);
            this.rbPipe.Name = "rbPipe";
            this.rbPipe.Size = new System.Drawing.Size(51, 17);
            this.rbPipe.TabIndex = 16;
            this.rbPipe.TabStop = true;
            this.rbPipe.Text = "Pipe |";
            this.rbPipe.UseVisualStyleBackColor = true;
            // 
            // lblExplNone
            // 
            this.lblExplNone.AutoSize = true;
            this.lblExplNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplNone.Location = new System.Drawing.Point(358, 23);
            this.lblExplNone.Name = "lblExplNone";
            this.lblExplNone.Size = new System.Drawing.Size(81, 12);
            this.lblExplNone.TabIndex = 15;
            this.lblExplNone.Text = "(taille colonne fixe)";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(309, 20);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(56, 17);
            this.rbNone.TabIndex = 14;
            this.rbNone.Text = "Aucun";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // rbSpace
            // 
            this.rbSpace.AutoSize = true;
            this.rbSpace.Location = new System.Drawing.Point(241, 20);
            this.rbSpace.Name = "rbSpace";
            this.rbSpace.Size = new System.Drawing.Size(61, 17);
            this.rbSpace.TabIndex = 13;
            this.rbSpace.Text = "Espace";
            this.rbSpace.UseVisualStyleBackColor = true;
            // 
            // rbSemiColon
            // 
            this.rbSemiColon.AutoSize = true;
            this.rbSemiColon.Location = new System.Drawing.Point(150, 19);
            this.rbSemiColon.Name = "rbSemiColon";
            this.rbSemiColon.Size = new System.Drawing.Size(84, 17);
            this.rbSemiColon.TabIndex = 12;
            this.rbSemiColon.Text = "Point Virgule";
            this.rbSemiColon.UseVisualStyleBackColor = true;
            // 
            // cbSheetName
            // 
            this.cbSheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheetName.FormattingEnabled = true;
            this.cbSheetName.Location = new System.Drawing.Point(97, 46);
            this.cbSheetName.Name = "cbSheetName";
            this.cbSheetName.Size = new System.Drawing.Size(338, 21);
            this.cbSheetName.TabIndex = 13;
            this.cbSheetName.Visible = false;
            // 
            // lblSheetName
            // 
            this.lblSheetName.AutoSize = true;
            this.lblSheetName.Location = new System.Drawing.Point(6, 49);
            this.lblSheetName.Name = "lblSheetName";
            this.lblSheetName.Size = new System.Drawing.Size(79, 13);
            this.lblSheetName.TabIndex = 14;
            this.lblSheetName.Text = "Feuille classeur";
            this.lblSheetName.Visible = false;
            // 
            // gpFileType
            // 
            this.gpFileType.Controls.Add(this.rbSourceAutre);
            this.gpFileType.Controls.Add(this.rbSourceCM);
            this.gpFileType.Controls.Add(this.rbSourceCA);
            this.gpFileType.Location = new System.Drawing.Point(12, 202);
            this.gpFileType.Name = "gpFileType";
            this.gpFileType.Size = new System.Drawing.Size(445, 50);
            this.gpFileType.TabIndex = 15;
            this.gpFileType.TabStop = false;
            this.gpFileType.Text = "Source";
            // 
            // rbSourceAutre
            // 
            this.rbSourceAutre.AutoSize = true;
            this.rbSourceAutre.Location = new System.Drawing.Point(198, 19);
            this.rbSourceAutre.Name = "rbSourceAutre";
            this.rbSourceAutre.Size = new System.Drawing.Size(59, 17);
            this.rbSourceAutre.TabIndex = 2;
            this.rbSourceAutre.Text = "Autre...";
            this.rbSourceAutre.UseVisualStyleBackColor = true;
            // 
            // rbSourceCM
            // 
            this.rbSourceCM.AutoSize = true;
            this.rbSourceCM.Location = new System.Drawing.Point(105, 19);
            this.rbSourceCM.Name = "rbSourceCM";
            this.rbSourceCM.Size = new System.Drawing.Size(87, 17);
            this.rbSourceCM.TabIndex = 1;
            this.rbSourceCM.Text = "Crédit Mutuel";
            this.rbSourceCM.UseVisualStyleBackColor = true;
            // 
            // rbSourceCA
            // 
            this.rbSourceCA.AutoSize = true;
            this.rbSourceCA.Checked = true;
            this.rbSourceCA.Location = new System.Drawing.Point(6, 19);
            this.rbSourceCA.Name = "rbSourceCA";
            this.rbSourceCA.Size = new System.Drawing.Size(93, 17);
            this.rbSourceCA.TabIndex = 0;
            this.rbSourceCA.TabStop = true;
            this.rbSourceCA.Text = "Crédit Agricole";
            this.rbSourceCA.UseVisualStyleBackColor = true;
            // 
            // gpSourceFile
            // 
            this.gpSourceFile.Controls.Add(this.lblSheetName);
            this.gpSourceFile.Controls.Add(this.btnFilePath);
            this.gpSourceFile.Controls.Add(this.cbSheetName);
            this.gpSourceFile.Controls.Add(this.txtFilePath);
            this.gpSourceFile.Location = new System.Drawing.Point(12, 27);
            this.gpSourceFile.Name = "gpSourceFile";
            this.gpSourceFile.Size = new System.Drawing.Size(445, 79);
            this.gpSourceFile.TabIndex = 16;
            this.gpSourceFile.TabStop = false;
            this.gpSourceFile.Text = "Fichier à enrichir";
            // 
            // gpReference
            // 
            this.gpReference.Controls.Add(this.cbRefSheetName);
            this.gpReference.Controls.Add(this.btnRefFilePath);
            this.gpReference.Controls.Add(this.txtRefFilePath);
            this.gpReference.Controls.Add(this.lblRefFileSheet);
            this.gpReference.Location = new System.Drawing.Point(12, 112);
            this.gpReference.Name = "gpReference";
            this.gpReference.Size = new System.Drawing.Size(445, 84);
            this.gpReference.TabIndex = 17;
            this.gpReference.TabStop = false;
            this.gpReference.Text = "Fichier des Comptes de Référence";
            // 
            // cbRefSheetName
            // 
            this.cbRefSheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRefSheetName.FormattingEnabled = true;
            this.cbRefSheetName.Location = new System.Drawing.Point(97, 51);
            this.cbRefSheetName.Name = "cbRefSheetName";
            this.cbRefSheetName.Size = new System.Drawing.Size(338, 21);
            this.cbRefSheetName.TabIndex = 15;
            this.cbRefSheetName.Visible = false;
            // 
            // btnRefFilePath
            // 
            this.btnRefFilePath.Location = new System.Drawing.Point(360, 17);
            this.btnRefFilePath.Name = "btnRefFilePath";
            this.btnRefFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnRefFilePath.TabIndex = 8;
            this.btnRefFilePath.Text = "Parcourir ...";
            this.btnRefFilePath.UseVisualStyleBackColor = true;
            this.btnRefFilePath.Click += new System.EventHandler(this.btnRefFilePath_Click);
            // 
            // lblRefFileSheet
            // 
            this.lblRefFileSheet.AutoSize = true;
            this.lblRefFileSheet.Location = new System.Drawing.Point(3, 54);
            this.lblRefFileSheet.Name = "lblRefFileSheet";
            this.lblRefFileSheet.Size = new System.Drawing.Size(91, 13);
            this.lblRefFileSheet.TabIndex = 8;
            this.lblRefFileSheet.Text = "Fichier Référénce";
            this.lblRefFileSheet.Visible = false;
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatut.Location = new System.Drawing.Point(278, 357);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(179, 13);
            this.lblStatut.TabIndex = 18;
            this.lblStatut.Text = "Traitement terminé (Result.xls)";
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblStatut.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(469, 406);
            this.Controls.Add(this.lblStatut);
            this.Controls.Add(this.gpReference);
            this.Controls.Add(this.gpSourceFile);
            this.Controls.Add(this.gpFileType);
            this.Controls.Add(this.groupDelimiter);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Operation Enrichment";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupDelimiter.ResumeLayout(false);
            this.groupDelimiter.PerformLayout();
            this.gpFileType.ResumeLayout(false);
            this.gpFileType.PerformLayout();
            this.gpSourceFile.ResumeLayout(false);
            this.gpSourceFile.PerformLayout();
            this.gpReference.ResumeLayout(false);
            this.gpReference.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFilePath;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBtnSetRefCodeFile;
        private System.Windows.Forms.ToolStripMenuItem menuBtnHelp;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtRefFilePath;
        private System.Windows.Forms.RadioButton rbTab;
        private System.Windows.Forms.RadioButton rbColon;
        private System.Windows.Forms.GroupBox groupDelimiter;
        private System.Windows.Forms.Label lblExplNone;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbSpace;
        private System.Windows.Forms.RadioButton rbSemiColon;
        private System.Windows.Forms.ComboBox cbSheetName;
        private System.Windows.Forms.Label lblSheetName;
        private System.Windows.Forms.GroupBox gpFileType;
        private System.Windows.Forms.RadioButton rbSourceAutre;
        private System.Windows.Forms.RadioButton rbSourceCM;
        private System.Windows.Forms.RadioButton rbSourceCA;
        private System.Windows.Forms.GroupBox gpSourceFile;
        private System.Windows.Forms.GroupBox gpReference;
        private System.Windows.Forms.ComboBox cbRefSheetName;
        private System.Windows.Forms.Button btnRefFilePath;
        private System.Windows.Forms.Label lblRefFileSheet;
        private System.Windows.Forms.RadioButton rbPipe;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

