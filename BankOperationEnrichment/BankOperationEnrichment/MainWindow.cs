using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace BankOperationEnrichment
{
    public partial class MainWindow : Form
    {
        public string fileToOperate;
        public string fileCodeReferences;
        public string excelFiledelimiter;
        public HashSet<Data> arrayData;
        public List<string> listSheets;

        public MainWindow()
        {
            arrayData = new HashSet<Data>();
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
                if (fileToOperate != null)
                {
                    cbSheetName.Enabled = true;
                    listSheets = new List<string>();
                    foreach (var sheet in GetSheetsNameFromWorkbook(fileToOperate))
                    {
                        // Delete $ at the end and add to list for display
                        string _sheet = sheet.Replace("'", string.Empty);
                        listSheets.Add(_sheet.Substring(0, _sheet.Length - 1));
                    }
                    cbSheetName.DataSource = new BindingSource(listSheets, null);
                    btnExecute.Enabled = true;
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            HashSet<Data> arrayData = new HashSet<Data>();

            // Read Excel File depending Source File
            ReadExcelFile(fileToOperate, cbSheetName.SelectedItem.ToString());
        }

        private string[] GetSheetsNameFromWorkbook(string filePath)
        {
            string connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filePath + "; Extended Properties = 'Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            //string connString = @"provider = Microsoft.Jet.OLEDB.4.0; data source = " + filePath + "; Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=1'";
            //string connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + filePath + "; Extended Properties = 'Excel 8.0 Xml;HDR=Yes;IMEX=1'";
            
            OleDbConnection objConn = null;
            DataTable dt = null;
            try
            {
                objConn = new OleDbConnection(connString);
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                    return null;

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                return excelSheets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                    dt.Dispose();
            }
        }

        private void ReadExcelFile(string filePath, string sheetName)
        {
            OleDbDataAdapter dataAdapter;
            OleDbConnection connection;
            DataSet dataSet = new DataSet();
            DataTable excelSheet;

            // Open connection
            string connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filePath + "; Extended Properties = 'Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            //string connString = @"provider = Microsoft.Jet.OLEDB.4.0; data source = " + filePath + "; Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=1'";
            //string connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + filePath + "; Extended Properties = 'Excel 8.0 Xml;HDR=Yes;IMEX=1'";

            try
            {
                connection = new OleDbConnection(connString);

                // Select data from the Workbook Sheet1
                dataAdapter = new OleDbDataAdapter("select * from [" + sheetName + "$]", connection);
                dataAdapter.Fill(dataSet);
                excelSheet = dataSet.Tables[0];
                connection.Close();

                // Get line number & col number in excel sheet
                int nbLines = excelSheet.Rows.Count;
                int nbColumns = excelSheet.Columns.Count;

                if (rbSourceCA.Checked)
                    OperateCAExcelFile(excelSheet);
                if (rbSourceCM.Checked)
                    OperateCMExcelFile(excelSheet);
                if (rbSourceAutre.Checked)
                    OperateOtherExcelFile(excelSheet);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OperateOtherExcelFile(DataTable dataTable)
        {
            List<string> toto = new List<string>();
            toto.Add("momo");
            toto.Add("mama");
            toto.Add("mimi");
            PreviewFile preview = new PreviewFile(toto);
            preview.Show();
        }

        private void OperateCMExcelFile(DataTable dataTable)
        {
            //// Avoid Header
            //int startIndex = 0;
            //// Use of dates as pivot
            //Regex datePattern = new Regex(@"\d{2}/\d{2}/\d{4}");
            //for (int i = startIndex; i < dataTable.Rows.Count; i++)
            //{
            //    // Parsing data
            //    if (dataTable.Rows[i].ItemArray[0] != DBNull.Value)
            //    {
            //        var idxStartLibelle = datePattern.Matches(dataTable.Rows[i].ItemArray[0].ToString())[1].Index + datePattern.Matches(dataTable.Rows[i].ItemArray[0].ToString())[1].Length;
            //        var idxEndLibelle = datePattern.Matches(dataTable.Rows[i].ItemArray[0].ToString())[2].Index;
            //        var montant = Convert.ToDouble(dataTable.Rows[i].ItemArray[0].ToString().Substring(idxEndLibelle + datePattern.Matches(dataTable.Rows[i].ItemArray[0].ToString())[2].Length));

            //        arrayData.Add(new Data()
            //        {
            //            Date = Convert.ToDateTime(datePattern.Matches(dataTable.Rows[i].ItemArray[0].ToString())[1].ToString()),
            //            Libelle = dataTable.Rows[i].ItemArray[0].ToString().Substring(idxStartLibelle, idxEndLibelle - idxStartLibelle + 1),
            //            Depense = montant < 0 ? -1 * montant : 0,
            //            Recettes = montant > 0 ? montant : 0
            //        });
            //    }
            //}

            // Start reading data
            int startIndex = 0;
            int delimiter = 9;
            // 9  ==> \t 
            // 10 ==> \n
            // 13 ==> \r
            char _delimiter = Convert.ToChar(delimiter);

            // Use of tabulation as pivot
            for (int i = startIndex; i < dataTable.Rows.Count; i++)
            {
                // Parsing data
                if (dataTable.Rows[i].ItemArray[0] != DBNull.Value)
                {
                    var montant = Convert.ToDouble(dataTable.Rows[i].ItemArray[0].ToString().Split(_delimiter)[6].ToString());
                    arrayData.Add(new Data()
                    {
                        Date = Convert.ToDateTime(dataTable.Rows[i].ItemArray[0].ToString().Split(_delimiter)[2]),
                        Libelle = dataTable.Rows[i].ItemArray[0].ToString().Split(_delimiter)[3],
                        Depense = montant < 0 ? -1 * montant : 0,
                        Recettes = montant > 0 ? montant : 0
                    });
                }
            }
        }

        private void OperateCAExcelFile(DataTable dataTable)
        {
            bool test = false;
            foreach (DataRow excelLine in dataTable.Rows)
            {
                if (test)
                {
                    arrayData.Add(new Data()
                    {
                        Date = excelLine.ItemArray[0] != DBNull.Value ? Convert.ToDateTime(excelLine.ItemArray[0]) : new DateTime(),
                        Libelle = excelLine.ItemArray[2] != DBNull.Value ? excelLine.ItemArray[2].ToString() : string.Empty,
                        Depense = excelLine.ItemArray[3] != DBNull.Value ? Convert.ToDouble(excelLine.ItemArray[3]) : 0,
                        Recettes = excelLine.ItemArray[4] != DBNull.Value ? Convert.ToDouble(excelLine.ItemArray[4]) : 0
                    });
                }

                // Look for header line
                if (excelLine.ItemArray[0].ToString().ToLower().Contains("date") &&
                    excelLine.ItemArray[1].ToString().ToLower().Contains("date") &&
                    excelLine.ItemArray[2].ToString().ToLower().Contains("libell"))
                    test = true;
            }
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
