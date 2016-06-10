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