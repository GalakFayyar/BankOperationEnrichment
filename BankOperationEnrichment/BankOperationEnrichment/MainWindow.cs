using System;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BankOperationEnrichment
{
    public partial class MainWindow : Form
    {
        public string fileToOperate;
        public string fileCodeReferences;
        public string excelFiledelimiter;

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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(fileToOperate, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, getDelimiterSelected(), false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            for (rCnt = 15; rCnt <= range.Rows.Count; rCnt++)
            {
                // Test si la ligne est à traiter
                //if (!string.IsNullOrWhiteSpace((string)(range.Cells[rCnt, 1] as Excel.Range).Value2) && 
                //    !string.IsNullOrWhiteSpace((string)(range.Cells[rCnt, 2] as Excel.Range).Value2) &&
                //    !string.IsNullOrWhiteSpace((string)(range.Cells[rCnt, 3] as Excel.Range).Value2))
                //{
                //    try
                //    {
                //        var data = new Data()
                //        {
                //            Date = (DateTime)(range.Cells[rCnt, 1] as Excel.Range).Value,
                //            Libelle = (string)(range.Cells[rCnt, 3] as Excel.Range).Value,
                //            Depense = (float)(range.Cells[rCnt, 4] as Excel.Range).Value,
                //            Recettes = (float)(range.Cells[rCnt, 5] as Excel.Range).Value
                //        };
                //    }
                //    catch (Exception)
                //    {
                //        throw;
                //    }
                //}

                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    MessageBox.Show(str);
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private string getDelimiterSelected()
        {
            if (rbColon.Checked)
                return ",";
            if (rbSemiColon.Checked)
                return ";";
            if (rbSpace.Checked)
                return " ";
            if (rbNone.Checked)
                return "";
            if (rbTab.Checked)
                return "\t";
            return "";
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
