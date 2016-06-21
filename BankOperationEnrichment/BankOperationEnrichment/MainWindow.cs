using EmbeddedExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace BankOperationEnrichment
{
    public partial class MainWindow : Form
    {
        #region Public members

        public string fileToOperate;
        public string fileCodeReferences;
        public string excelFiledelimiter;
        public HashSet<Data> arrayData;
        public HashSet<AccountReference> arrayRefData;
        public List<string> listSheets;
        public List<string> listSheetsRef;
        public string strRegPathExcel8 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Excel.Sheet.8";
        public string strRegPathExcel12 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Excel.Sheet.12";
        public string keyExcelAccess = "BrowserFlags";
        public object oldValueExcel8 = null;
        public object oldValueExcel12 = null;
        public ApplicationSettings settings;
        public ApplicationSettingsForm settingsForm;

        #endregion

        #region Private members
        private string SYSTEM_DECIMAL_SEPARATOR = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
        #endregion

        #region Constructor

        public MainWindow()
        {
            arrayData = new HashSet<Data>();
            arrayRefData = new HashSet<AccountReference>();
            InitializeComponent();
            lblVersion.Text = "BOE v1.5";
            txtRefFilePath.Text = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString();

            settingsForm = new ApplicationSettingsForm();
            settings = settingsForm.mySettings;
        }

        #endregion

        #region UI actions

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetRegistryKeysForNavigator();
            MainWindow.ActiveForm.Dispose();
        }

        private void menuBtnSetRefCodeFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog1.FileName = string.Empty;
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileCodeReferences = openFileDialog1.FileName;
                    txtRefFilePath.Text = fileCodeReferences;
                    if (fileCodeReferences != null)
                    {
                        lblRefFileSheet.Visible = true;
                        cbRefSheetName.Visible = true;
                        listSheetsRef = new List<string>();
                        foreach (var sheet in GetSheetsNameFromWorkbook(fileCodeReferences))
                        {
                            // Delete $ at the end and add to list for display
                            string _sheet = sheet.Replace("'", string.Empty);
                            listSheetsRef.Add(_sheet.Substring(0, _sheet.Length - 1));
                        }
                        cbRefSheetName.DataSource = new BindingSource(listSheetsRef, null);
                    }
                    else
                    {
                        lblRefFileSheet.Visible = false;
                        cbRefSheetName.Visible = false;
                    }
                    if (fileToOperate != null && fileCodeReferences != null)
                        btnExecute.Enabled = true;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
                openFileDialog1.FileName = string.Empty;
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileToOperate = openFileDialog1.FileName;
                    txtFilePath.Text = fileToOperate;
                    if (fileToOperate != null && Path.GetExtension(fileToOperate) != ".csv")
                    {
                        lblSheetName.Visible = true;
                        cbSheetName.Visible = true;
                        listSheets = new List<string>();
                        foreach (var sheet in GetSheetsNameFromWorkbook(fileToOperate))
                        {
                            // Delete $ at the end and add to list for display
                            string _sheet = sheet.Replace("'", string.Empty);
                            listSheets.Add(_sheet.Substring(0, _sheet.Length - 1));
                        }
                        cbSheetName.DataSource = new BindingSource(listSheets, null);
                    }
                    else
                    {
                        lblSheetName.Visible = false;
                        cbSheetName.Visible = false;
                    }

                    if (fileToOperate != null && fileCodeReferences != null)
                        btnExecute.Enabled = true;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Label status operation properties reset
            lblStatut.Visible = false;
            lblStatut.Text = string.Format("Traitement terminé (enrichi_{0}.xls)", Path.GetFileNameWithoutExtension(fileToOperate).ToString());
            lblStatut.ForeColor = System.Drawing.Color.Black;

            bool operationStatus = true;
            arrayData.Clear();
            arrayRefData.Clear();

            // Read Excel File depending Source File
            var selectedFile = cbRefSheetName.SelectedItem.ToString();
            switch (Path.GetExtension(fileToOperate).ToString())
            {
                case ".csv":
                    operationStatus &= ReadCsvFile(fileToOperate);
                    break;
                case ".xls":
                case ".xlsx":
                case ".xlsxm":
                    operationStatus &= ReadExcelFile(fileToOperate, cbSheetName.SelectedItem.ToString());
                    break;
                default:
                    MessageBox.Show("Format du fichier source incorrect. Entrer un fichier Excel au format csv, xls, xlsx ou xlsm.", "Erreur de traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Value = 0;
                    return;
            }
            progressBar.Value = 25;

            // Read Reference Excel File
            if (Path.GetExtension(fileCodeReferences) == ".csv")
            {
                MessageBox.Show("Format du fichier de réference incorrect. Entrer un fichier Excel au format xls, xlsx ou xlsm.", "Erreur de traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar.Value = 0;
                return;
            } else
            {
                operationStatus &= ReadExcelFile(fileCodeReferences, cbRefSheetName.SelectedItem.ToString(), true);
                progressBar.Value = 50;
            }

            // Data enrichment
            operationStatus &= DataEnrichment();
            progressBar.Value = 75;

            // Export data
            operationStatus &= ExportEnrichedData();
            progressBar.Value = (operationStatus) ? 100 : 0;

            // Label status operation properties set
            lblStatut.ForeColor = (!operationStatus) ? System.Drawing.Color.Red : lblStatut.ForeColor;
            lblStatut.Text = (!operationStatus) ? "Erreur de traitement" : lblStatut.Text;
            lblStatut.Visible = true;
        }

        private void btnRefFilePath_Click(object sender, EventArgs e)
        {
            menuBtnSetRefCodeFile_Click(sender, e);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        #endregion

        #region Operation Functions

        private bool ExportEnrichedData()
        {
            OleDbConnection connection = null;

            string resultFile = string.Concat(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString(), "\\enrichi_", Path.GetFileNameWithoutExtension(fileToOperate).ToString().Replace(' ', '_'), ".xls");

            // Open connection
            string connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + resultFile + "; Extended Properties = 'Excel 8.0;HDR=YES;'";
            //string connString = @"provider = Microsoft.Jet.OLEDB.4.0; data source = " + resultFile + "; Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=1'";
            //string connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + filePath + "; Extended Properties = 'Excel 8.0 Xml;HDR=Yes;IMEX=1'";

            try
            {
                connection = new OleDbConnection(connString);
                
                string requete = string.Empty;

                // Create File
                bool fileExists = File.Exists(resultFile);
                if (fileExists)
                {
                    string message = string.Format("Le fichier '{0}' existe déja. Voulez-vous le remplacer ?", resultFile);
                    DialogResult dr = MessageBox.Show(new Form() { TopMost = true }, message, "Fichier déja existant", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                        File.Delete(resultFile);
                    if (dr == DialogResult.No)
                        return false;
                }

                connection.Open();

                // Create Table
                OleDbCommand createcmdData = new OleDbCommand(requete, connection);
                createcmdData.Connection = connection;
                createcmdData.CommandText = @"CREATE TABLE Donnees (DATE_OPERATION char(50), CODE_JOURNAL char(50), NUM_COMPTE char(50), NUM_OPERATION char(50), LIBELLE char(255), DEPENSES char(50), RECETTES char(50))";
                createcmdData.ExecuteNonQuery();

                foreach (Data data in arrayData)
                {
                    requete = string.Format("INSERT INTO [Donnees$] VALUES (@date, @codeJournal, @numeroCompte, @numeroOperation, @libelle, @depenses, @recettes);",
                        data.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        TryConvertToString(data.CodeJournal),
                        TryConvertToString(data.NumeroCompte),
                        TryConvertToString(data.NumeroOperation),
                        Convert.ToString(data.Libelle),
                        Convert.ToString(data.Depense),
                        Convert.ToString(data.Recettes));

                    OleDbCommand insertCmdData = new OleDbCommand(requete, connection);
                    insertCmdData.Parameters.Add(new OleDbParameter("@date", data.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
                    insertCmdData.Parameters.Add(new OleDbParameter("@codeJournal", TryConvertToString(data.CodeJournal)));
                    insertCmdData.Parameters.Add(new OleDbParameter("@numeroCompte", TryConvertToString(data.NumeroCompte)));
                    insertCmdData.Parameters.Add(new OleDbParameter("@numeroOperation", TryConvertToString(data.NumeroOperation)));

                    // Substring if necessary
                    var _libelle = string.Empty;
                    if (data.Libelle != null && data.Libelle != string.Empty)
                        _libelle = Convert.ToString(data.Libelle).Length > settings.MAX_CHAR_LIBELLE ? Convert.ToString(data.Libelle).Substring(0, settings.MAX_CHAR_LIBELLE) : data.Libelle;
                    insertCmdData.Parameters.Add(new OleDbParameter("@libelle", _libelle));

                    insertCmdData.Parameters.Add(new OleDbParameter("@depenses", Convert.ToString(data.Depense)));
                    insertCmdData.Parameters.Add(new OleDbParameter("@recettes", Convert.ToString(data.Recettes)));
                    insertCmdData.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur d'écriture", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private bool DataEnrichment()
        {
            if (arrayData.Count > 0)
            {
                // Var for last inserted date
                var _lastDate = arrayData.Max(x => x.Date);
                // Read Data
                foreach (Data data in arrayData)
                {
                    var accountRef = arrayRefData.Where(x => data.Libelle.ToUpper().Contains(x.LibelleCompte.ToUpper())).FirstOrDefault();
                    // Enrich data
                    data.NumeroCompte = accountRef != null ? accountRef.NumeroCompte : settings.CPT_ATTENTE;
                    data.CodeJournal = settings.DICO[GetSelectedTypeBanque()].codeJournal.ToString();
                }

                // Add Sum data
                var depenses = Convert.ToDouble(arrayData.Sum(x => x.Depense));
                var recettes = Convert.ToDouble(arrayData.Sum(x => x.Recettes));
                arrayData.Add(new Data()
                {
                    Date = Convert.ToDateTime(arrayData.Max(x => x.Date)),
                    Libelle = settings.DICO[GetSelectedTypeBanque()].libelle,
                    NumeroCompte = settings.DICO[GetSelectedTypeBanque()].code,
                    CodeJournal = settings.DICO[GetSelectedTypeBanque()].codeJournal,
                    Depense = depenses
                });
                arrayData.Add(new Data()
                {
                    Date = Convert.ToDateTime(arrayData.Max(x => x.Date)),
                    Libelle = settings.DICO[GetSelectedTypeBanque()].libelle,
                    NumeroCompte = settings.DICO[GetSelectedTypeBanque()].code,
                    CodeJournal = settings.DICO[GetSelectedTypeBanque()].codeJournal,
                    Recettes = recettes
                });

                return true;
            }
            else
                return false;
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
                MessageBox.Show(ex.Message, "Erreur de traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ReadExcelFile(string filePath, string sheetName, bool isRefFile = false)
        {
            OleDbDataAdapter dataAdapter;
            OleDbConnection connection;
            DataSet dataSet = new DataSet();
            DataTable excelSheet;

            bool operationStatus = true;

            // Open connection
            string connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filePath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
            //string connString = @"provider = Microsoft.Jet.OLEDB.4.0; data source = " + filePath + "; Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=1'";
            //string connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + filePath + "; Extended Properties = 'Excel 8.0 Xml;HDR=Yes;IMEX=1'";

            try
            {
                connection = new OleDbConnection(connString);
                connection.Open();

                // Select data from the Workbook Sheet1
                dataAdapter = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", connection);
                dataAdapter.Fill(dataSet);
                excelSheet = dataSet.Tables[0];
                connection.Close();

                // Get line number & col number in excel sheet
                int nbLines = excelSheet.Rows.Count;
                int nbColumns = excelSheet.Columns.Count;
                
                if (!isRefFile)
                {
                    if (rbSourceCA.Checked)
                        return operationStatus && OperateCAExcelFile(excelSheet);
                    if (rbSourceCM.Checked)
                        return operationStatus && OperateCMExcelFile(excelSheet);
                    if (rbSourceBNP.Checked)
                        return operationStatus && OperateBNPExcelFile(excelSheet);
                    if (rbSourceAutre.Checked)
                        return operationStatus && OperateOtherExcelFile(excelSheet);
                }
                else
                    return operationStatus && OperateReferenceExcelFile(excelSheet);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool OperateReferenceExcelFile(DataTable dataTable)
        {
            foreach (DataRow excelLine in dataTable.Rows)
            {
                if (excelLine.ItemArray[0] != DBNull.Value && excelLine.ItemArray[1] != DBNull.Value)
                {
                    arrayRefData.Add(new AccountReference()
                    {
                        NumeroCompte = excelLine.ItemArray[0].ToString(),
                        LibelleCompte = excelLine.ItemArray[1].ToString()
                    });
                }
            }

            return true;
        }

        public bool OperateOtherExcelFile(DataTable dataTable)
        {
            UpdateRegistryKeysForNavigator();

            ExcelPreview preview = new ExcelPreview(fileToOperate);
            preview.ShowDialog();

            if (preview.mappingColumns != null)
            {
                Dictionary<string, int> mappingColumns = preview.mappingColumns;
                int startIndex = preview.startLineNumber;

                for (int i = startIndex; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i].ItemArray[mappingColumns["date"]] != DBNull.Value)
                    {
                        arrayData.Add(new Data()
                        {
                            Date = dataTable.Rows[i].ItemArray[mappingColumns["date"]] != DBNull.Value ? Convert.ToDateTime(dataTable.Rows[i].ItemArray[mappingColumns["date"]]) : new DateTime(),
                            Libelle = dataTable.Rows[i].ItemArray[mappingColumns["libelle"]] != DBNull.Value ? CastAndTruncateStringLibelle(dataTable.Rows[i].ItemArray[mappingColumns["libelle"]]) : string.Empty,
                            Depense = dataTable.Rows[i].ItemArray[mappingColumns["depense"]] != DBNull.Value ? CastStringToDouble(dataTable.Rows[i].ItemArray[mappingColumns["depense"]].ToString()) : 0,
                            Recettes = dataTable.Rows[i].ItemArray[mappingColumns["recette"]] != DBNull.Value ? CastStringToDouble(dataTable.Rows[i].ItemArray[mappingColumns["recette"]].ToString()) : 0
                        });
                    }
                }

                return true;
            } 
            else
                return false;
            
        }

        private bool OperateCMExcelFile(DataTable dataTable)
        {
            // Set Delimiter
            rbTab.Checked = true;
            
            // Start reading data
            int startIndex = 0;
            int delimiter = GetDelimiterSelected();
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
                    var montant = CastStringToDouble(dataTable.Rows[i].ItemArray[0].ToString().Split(_delimiter)[6].ToString());
                    arrayData.Add(new Data()
                    {
                        Date = Convert.ToDateTime(dataTable.Rows[i].ItemArray[0].ToString().Split(_delimiter)[2]),
                        Libelle = CastAndTruncateStringLibelle(dataTable.Rows[i].ItemArray[0].ToString().Split(_delimiter)[3]),
                        Depense = montant < 0 ? -1 * montant : 0,
                        Recettes = montant > 0 ? montant : 0
                    });
                }
            }

            return true;
        }

        private bool OperateCAExcelFile(DataTable dataTable)
        {
            bool test = false;
            foreach (DataRow excelLine in dataTable.Rows)
            {
                if (test && excelLine.ItemArray[0] != DBNull.Value && excelLine.ItemArray[2] != DBNull.Value)
                    arrayData.Add(new Data()
                    {
                        Date = excelLine.ItemArray[0] != DBNull.Value ? Convert.ToDateTime(excelLine.ItemArray[0]) : new DateTime(),
                        Libelle = excelLine.ItemArray[2] != DBNull.Value ? CastAndTruncateStringLibelle(excelLine.ItemArray[2]) : string.Empty,
                        Depense = excelLine.ItemArray[3] != DBNull.Value ? CastStringToDouble(excelLine.ItemArray[3].ToString()) : 0,
                        Recettes = excelLine.ItemArray[4] != DBNull.Value ? CastStringToDouble(excelLine.ItemArray[4].ToString()) : 0
                    });

                // Look for header line
                if (excelLine.ItemArray[0].ToString().ToLower().Contains("date") &&
                    excelLine.ItemArray[1].ToString().ToLower().Contains("date") &&
                    excelLine.ItemArray[2].ToString().ToLower().Contains("libell"))
                    test = true;
            }

            return true;
        }

        private bool OperateBNPExcelFile(DataTable dataTable)
        {
            bool end = false;
            for (int i = 4; !end; i++)
            {
                DataRow excelLine = dataTable.Rows[i];

                // Look for end of file
                if (string.IsNullOrEmpty(excelLine.ItemArray[0].ToString()) &&
                    string.IsNullOrEmpty(excelLine.ItemArray[1].ToString()))
                    end = true;

                if (!end)
                    arrayData.Add(new Data()
                    {
                        Date = excelLine.ItemArray[0] != DBNull.Value ? Convert.ToDateTime(excelLine.ItemArray[0]) : new DateTime(),
                        Libelle = excelLine.ItemArray[2] != DBNull.Value ? CastAndTruncateStringLibelle(excelLine.ItemArray[2]) : string.Empty,
                        NumeroOperation = excelLine.ItemArray[3] != DBNull.Value ? excelLine.ItemArray[3].ToString().Trim() : string.Empty,
                        Depense = excelLine.ItemArray[4] != DBNull.Value ? CastStringToDouble(excelLine.ItemArray[4].ToString()) : 0,
                        Recettes = excelLine.ItemArray[5] != DBNull.Value ? CastStringToDouble(excelLine.ItemArray[5].ToString()) : 0
                    });
            }

            return true;
        }

        private bool ReadCsvFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);

                using (CsvReader csv = new CsvReader(file.OpenText()))
                {
                    switch (GetSelectedTypeBanque())
                    {
                        case ApplicationSettings.TYPEBANQUE.CA:
                            rbSemiColon.Checked = true;
                            ReadCACsvFile(csv, GetDelimiterSelected());
                            break;
                        case ApplicationSettings.TYPEBANQUE.CM:
                            rbTab.Checked = true;
                            ReadCMCsvFile(csv, GetDelimiterSelected());
                            break;
                        case ApplicationSettings.TYPEBANQUE.CMA:
                            rbTab.Checked = true;
                            ReadCMaCsvFile(csv, GetDelimiterSelected());
                            break;
                        default:
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ReadCACsvFile(CsvReader csv, int separator)
        {
            var test = false;

            csv.Configuration.Delimiter = TryConvertToString((char)separator);
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.IgnoreQuotes = false;
            csv.Configuration.TrimFields = true;
            csv.Configuration.WillThrowOnMissingField = false;

            while (csv.Read())
            {
                string[] fieldData = csv.CurrentRecord;
                if (test)
                    arrayData.Add(new Data()
                    {
                        Date = (fieldData[0] != "") ? Convert.ToDateTime(fieldData[0].ToString()) : new DateTime(),
                        Libelle = (fieldData[2] != "") ? fieldData[2].ToString() : string.Empty,
                        Depense = CastStringToDouble(fieldData[3].ToString()),
                        Recettes = CastStringToDouble(fieldData[4].ToString())
                    });

                // Look for header line
                if (fieldData[0].ToString().ToLower().Contains("date") &&
                    fieldData[1].ToString().ToLower().Contains("date") &&
                    fieldData[2].ToString().ToLower().Contains("libell"))
                    test = true;
            }
        }

        private void ReadCMCsvFile(CsvReader csv, int separator)
        {
            csv.Configuration.Delimiter = TryConvertToString((char)separator);
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.IgnoreQuotes = false;
            csv.Configuration.TrimFields = true;
            csv.Configuration.WillThrowOnMissingField = false;

            while (csv.Read())
            {
                string[] fieldData = csv.CurrentRecord;

                arrayData.Add(new Data()
                {
                    Date = (fieldData[0] != "") ? Convert.ToDateTime(fieldData[0].ToString()) : new DateTime(),
                    Libelle = (fieldData[4] != "") ? fieldData[4].ToString() : string.Empty,
                    Depense = (-1) * CastStringToDouble(fieldData[2].ToString()),
                    Recettes = CastStringToDouble(fieldData[3].ToString())
                });
            }
        }

        private void ReadCMaCsvFile(CsvReader csv, int separator)
        {
            csv.Configuration.Delimiter = TryConvertToString((char)separator);
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.IgnoreQuotes = false;
            csv.Configuration.TrimFields = true;
            csv.Configuration.WillThrowOnMissingField = false;

            while (csv.Read())
            {
                string[] fieldData = csv.CurrentRecord;
                var montant = CastStringToDouble(fieldData[6].ToString());
                arrayData.Add(new Data()
                {
                    Date = (fieldData[2] != "") ? Convert.ToDateTime(fieldData[2].ToString()) : new DateTime(),
                    Libelle = (fieldData[3] != "") ? fieldData[3].ToString() : string.Empty,
                    Depense = montant < 0 ? -1 * montant : 0,
                    Recettes = montant > 0 ? montant : 0
                });
            }
        }

        #endregion

        #region Tool functions

        private string TryConvertToString(object input)
        {
            return input == null ? "" : input.ToString();
        }

        private int GetDelimiterSelected()
        {
            if (rbColon.Checked)
                //return ",";
                return 44;
            if (rbSemiColon.Checked)
                //return ";";
                return 59;
            if (rbSpace.Checked)
                //return " ";
                return 32;
            if (rbTab.Checked)
                //return "\t";
                return 9;
            if (rbPipe.Checked)
                //return "|";
                return 124;
            return 0;
        }

        private ApplicationSettings.TYPEBANQUE GetSelectedTypeBanque()
        {
            if (rbSourceCA.Checked)
                return ApplicationSettings.TYPEBANQUE.CA;
            if (rbSourceCM.Checked)
                return ApplicationSettings.TYPEBANQUE.CM;
            if (rbSourceCMa.Checked)
                return ApplicationSettings.TYPEBANQUE.CMA;
            if (rbSourceBNP.Checked)
                return ApplicationSettings.TYPEBANQUE.BNP;

            return ApplicationSettings.TYPEBANQUE.AUTRE;
        }

        private bool TestIfKeyExists(string regPath, string valueName)
        {
            return (Registry.GetValue(regPath, valueName, null) != null);
        }

        private void UpdateRegistryKeysForNavigator()
        {
            try
            {
                if (TestIfKeyExists(strRegPathExcel8, keyExcelAccess))
                {
                    oldValueExcel8 = Registry.GetValue(strRegPathExcel8, keyExcelAccess, null);
                    Registry.SetValue(strRegPathExcel8, keyExcelAccess, "80000A00");
                }

                if (TestIfKeyExists(strRegPathExcel12, keyExcelAccess))
                {
                    oldValueExcel12 = Registry.GetValue(strRegPathExcel12, keyExcelAccess, null);
                    Registry.SetValue(strRegPathExcel12, keyExcelAccess, "80000A00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur d'écriture", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetRegistryKeysForNavigator()
        {
            try
            {
                if (TestIfKeyExists(strRegPathExcel8, keyExcelAccess) && oldValueExcel8 != null)
                    Registry.SetValue(strRegPathExcel8, keyExcelAccess, oldValueExcel8);

                if (TestIfKeyExists(strRegPathExcel12, keyExcelAccess) && oldValueExcel12 != null)
                    Registry.SetValue(strRegPathExcel12, keyExcelAccess, oldValueExcel12);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur d'écriture", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CastStringToDouble(string nombre)
        {
            // Get System decimal separator
            double result = 0;
            if (!string.IsNullOrEmpty(nombre))
            {
                if (SYSTEM_DECIMAL_SEPARATOR == ",")
                    nombre = nombre.Replace('.', ',');
                else if (SYSTEM_DECIMAL_SEPARATOR == ".")
                    nombre = nombre.Replace(',', '.');

                result = Convert.ToDouble(nombre);
            }
            return result;
        }

        private string CastAndTruncateStringLibelle(object libelle)
        {
            try
            {
                string _libelle = libelle.ToString();
                if (_libelle.Length > settings.MAX_CHAR_LIBELLE)
                    return _libelle.Substring(0, settings.MAX_CHAR_LIBELLE);
                else
                    return _libelle;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de lecture", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        #endregion
    }
}