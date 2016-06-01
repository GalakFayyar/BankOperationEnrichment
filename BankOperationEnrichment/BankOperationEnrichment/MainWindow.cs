using System;
using System.Reflection;
using System.Windows.Forms;

namespace BankOperationEnrichment
{
    public partial class MainWindow : Form
    {
        public string fileToOperate;
        public string fileCodeReferences;

        public MainWindow()
        {
            InitializeComponent();
            lblVersion.Text = "BOE v0.1";
            txtRefFilePath.Text = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainWindow.ActiveForm.Dispose();
        }

        private void menuBtnSetRefCodeFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileCodeReferences = openFileDialog1.FileName;
                txtRefFilePath.Text = fileCodeReferences;
            }
        }

        private void menuBtnSetRefCode_Click(object sender, EventArgs e)
        {

        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileToOperate = openFileDialog1.FileName;
                txtFilePath.Text = fileToOperate;
                btnExecute.Enabled = true;
            }
        }
    }
}
