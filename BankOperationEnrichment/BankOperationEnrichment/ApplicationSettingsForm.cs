using SettingsProviderNet;
using System;
using System.Windows.Forms;

namespace BankOperationEnrichment
{
    public partial class ApplicationSettingsForm : Form
    {
        #region Public Members
        SettingsProvider settingsProvider = new SettingsProvider(new RoamingAppDataStorage("BankAccountEnrichment"));
        public ApplicationSettings mySettings;
        #endregion

        #region Constructor

        public ApplicationSettingsForm()
        {
            InitializeComponent();

            mySettings = settingsProvider.GetSettings<ApplicationSettings>();

            // If first init : settings file does not exist : create default values
            if (mySettings.CPT_ATTENTE == null)
                mySettings.CPT_ATTENTE = "472000";
            if (mySettings.MAX_CHAR_LIBELLE == 0)
                mySettings.MAX_CHAR_LIBELLE = 40;
            if (mySettings.DICO == null)
            {
                mySettings.DICO = new System.Collections.Generic.Dictionary<ApplicationSettings.TYPEBANQUE, ApplicationSettings.InfoBank>();
                mySettings.DICO[ApplicationSettings.TYPEBANQUE.CA] = new ApplicationSettings.InfoBank() { code = string.Empty, codeJournal = string.Empty, libelle = "Cent. CA" };
                mySettings.DICO[ApplicationSettings.TYPEBANQUE.CM] = new ApplicationSettings.InfoBank() { code = string.Empty, codeJournal = string.Empty, libelle = "Cent. CM" };
                mySettings.DICO[ApplicationSettings.TYPEBANQUE.CMA] = new ApplicationSettings.InfoBank() { code = string.Empty, codeJournal = string.Empty, libelle = "Cent. CMA" };
                mySettings.DICO[ApplicationSettings.TYPEBANQUE.BNP] = new ApplicationSettings.InfoBank() { code = string.Empty, codeJournal = string.Empty, libelle = "Cent. BNP" };
                mySettings.DICO[ApplicationSettings.TYPEBANQUE.AUTRE] = new ApplicationSettings.InfoBank() { code = string.Empty, codeJournal = string.Empty, libelle = "Cent. AUTRE" };
            }
            if (mySettings.DECIMAL_SEPARATOR == null)
                mySettings.DECIMAL_SEPARATOR = ",";
            else
            {
                rbDecimalPoint.Checked = mySettings.DECIMAL_SEPARATOR == ".";
                rbDecimalVirgule.Checked = mySettings.DECIMAL_SEPARATOR == ",";
            }

            txtCptAttente.Text = (mySettings.CPT_ATTENTE != null) ? mySettings.CPT_ATTENTE.ToString() : string.Empty;
            nbLblMaxLen.Value = mySettings.MAX_CHAR_LIBELLE;

            txtCodeCA.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CA].code;
            txtCodeCM.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CM].code;
            txtCodeCMa.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CMA].code;
            txtCodeBNP.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.BNP].code;
            txtCodeAutre.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.AUTRE].code;

            txtLblCA.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CA].libelle;
            txtLblCM.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CM].libelle;
            txtLblCMa.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CMA].libelle;
            txtLblBNP.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.BNP].libelle;
            txtLblAutre.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.AUTRE].libelle;

            txtCptJournalCA.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CA].codeJournal;
            txtCptJournalCM.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CM].codeJournal;
            txtCptJournalCMa.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.CMA].codeJournal;
            txtCptJournalBNP.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.BNP].codeJournal;
            txtCptJournalAutre.Text = mySettings.DICO[ApplicationSettings.TYPEBANQUE.AUTRE].codeJournal;
        }

        #endregion

        #region UI Controls

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Tool functions

        private void saveSettings()
        {
            mySettings = new ApplicationSettings{
                CPT_ATTENTE = txtCptAttente.Text.ToString(),
                MAX_CHAR_LIBELLE = Convert.ToInt32(nbLblMaxLen.Value),
                DECIMAL_SEPARATOR = (rbDecimalPoint.Checked) ? "." : ","
            };
            mySettings.DICO = new System.Collections.Generic.Dictionary<ApplicationSettings.TYPEBANQUE, ApplicationSettings.InfoBank>();
            mySettings.DICO.Add(ApplicationSettings.TYPEBANQUE.CA, new ApplicationSettings.InfoBank() { code = txtCodeCA.Text, libelle = txtLblCA.Text, codeJournal = txtCptJournalCA.Text });
            mySettings.DICO.Add(ApplicationSettings.TYPEBANQUE.CM, new ApplicationSettings.InfoBank() { code = txtCodeCM.Text, libelle = txtLblCM.Text, codeJournal = txtCptJournalCM.Text });
            mySettings.DICO.Add(ApplicationSettings.TYPEBANQUE.CMA, new ApplicationSettings.InfoBank() { code = txtCodeCMa.Text, libelle = txtLblCMa.Text, codeJournal = txtCptJournalCMa.Text });
            mySettings.DICO.Add(ApplicationSettings.TYPEBANQUE.BNP, new ApplicationSettings.InfoBank() { code = txtCodeBNP.Text, libelle = txtLblBNP.Text, codeJournal = txtCptJournalBNP.Text });
            mySettings.DICO.Add(ApplicationSettings.TYPEBANQUE.AUTRE, new ApplicationSettings.InfoBank() { code = txtCodeAutre.Text, libelle = txtLblAutre.Text, codeJournal = txtCptJournalAutre.Text });

            settingsProvider.SaveSettings(mySettings);
        }

        #endregion
    }
}
