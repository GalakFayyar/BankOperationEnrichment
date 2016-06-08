using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmbeddedExcel
{
    public partial class ExcelPreview : Form
	{
        public Dictionary<string, int> mappingColumns;
        public int startLineNumber;

        public ExcelPreview() {
			InitializeComponent();
		}

        public ExcelPreview(string fileName)
        {
            InitializeComponent();
            this.excelWrapper1.OpenFile(fileName);
        }

        private void button1_Click(object sender,EventArgs e) {
			if(this.openFileDialog1.ShowDialog()==DialogResult.Cancel) return;
			this.excelWrapper1.OpenFile(this.openFileDialog1.FileName);
		}

		private void checkBox1_CheckedChanged(object sender,EventArgs e) {
			this.excelWrapper1.ToolBarVisible=this.checkBox1.Checked;
		}

        private void ExcelPreview_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtColDateOperation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColLibOperation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColDepense_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColRecette_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                mappingColumns = new Dictionary<string, int>();
                mappingColumns.Add("date", ConvertCharToNum(txtColDateOperation.Text));
                mappingColumns.Add("libelle", ConvertCharToNum(txtColLibOperation.Text));
                mappingColumns.Add("depense", ConvertCharToNum(txtColDepense.Text));
                mappingColumns.Add("recette", ConvertCharToNum(txtColRecette.Text));

                startLineNumber = txtStartLineNumber.Text != null ? int.Parse(txtStartLineNumber.Text) : 0;

                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ConvertCharToNum(string txt)
        {
            string str = txt.ToUpper();
            char chr = str[0];
            return (int)chr - 65;
        }
    }
}