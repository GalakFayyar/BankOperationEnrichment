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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFilePath = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnSetRefCodeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnSetRefCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtRefFilePath = new System.Windows.Forms.TextBox();
            this.lblRefFile = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(338, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFilePath
            // 
            this.btnFilePath.Location = new System.Drawing.Point(338, 27);
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
            this.btnExecute.Location = new System.Drawing.Point(257, 131);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Exécuter";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFilePath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtFilePath.Location = new System.Drawing.Point(12, 29);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(320, 20);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.Text = "Sélectionner un fichier ...";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblVersion.Location = new System.Drawing.Point(12, 137);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 90);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(401, 23);
            this.progressBar.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.menuBtnHelp,
            this.menuBtnExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(425, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBtnSetRefCodeFile,
            this.menuBtnSetRefCode});
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
            // menuBtnSetRefCode
            // 
            this.menuBtnSetRefCode.Name = "menuBtnSetRefCode";
            this.menuBtnSetRefCode.Size = new System.Drawing.Size(200, 22);
            this.menuBtnSetRefCode.Text = "Codes de Références";
            this.menuBtnSetRefCode.Click += new System.EventHandler(this.menuBtnSetRefCode_Click);
            // 
            // menuBtnHelp
            // 
            this.menuBtnHelp.Name = "menuBtnHelp";
            this.menuBtnHelp.Size = new System.Drawing.Size(43, 20);
            this.menuBtnHelp.Text = "Aide";
            // 
            // menuBtnExit
            // 
            this.menuBtnExit.Name = "menuBtnExit";
            this.menuBtnExit.Size = new System.Drawing.Size(12, 20);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtRefFilePath
            // 
            this.txtRefFilePath.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRefFilePath.Location = new System.Drawing.Point(109, 55);
            this.txtRefFilePath.Name = "txtRefFilePath";
            this.txtRefFilePath.ReadOnly = true;
            this.txtRefFilePath.Size = new System.Drawing.Size(304, 20);
            this.txtRefFilePath.TabIndex = 7;
            // 
            // lblRefFile
            // 
            this.lblRefFile.AutoSize = true;
            this.lblRefFile.Location = new System.Drawing.Point(12, 58);
            this.lblRefFile.Name = "lblRefFile";
            this.lblRefFile.Size = new System.Drawing.Size(91, 13);
            this.lblRefFile.TabIndex = 8;
            this.lblRefFile.Text = "Fichier Référénce";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(425, 169);
            this.Controls.Add(this.lblRefFile);
            this.Controls.Add(this.txtRefFilePath);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnFilePath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.ToolStripMenuItem menuBtnSetRefCode;
        private System.Windows.Forms.ToolStripMenuItem menuBtnHelp;
        private System.Windows.Forms.ToolStripMenuItem menuBtnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtRefFilePath;
        private System.Windows.Forms.Label lblRefFile;
    }
}

