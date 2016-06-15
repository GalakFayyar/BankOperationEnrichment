using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankOperationEnrichment
{
    public partial class Settings : Form
    {
        #region Public Members

        public int MAX_LENGTH_LIBELLE = 40;
        public string CPT_ATTENTE = "472000";
        public string CPT_CA = "";
        public string LBL_CA = "Cent. CA";
        public string CPT_CM = "";
        public string LBL_CM = "Cent. CM";
        public string CPT_CMA = "";
        public string LBL_CMA = "Cent. CMA";
        public string CPT_BNP = "";
        public string LBL_BNP = "Cent. BNP";
        public string CPT_AUTRE = "";
        public string LBL_AUTRE = "Cent. AUTRE";
        public enum TYPEBANQUE
        {
            CA,
            CM,
            CMA,
            BNP,
            AUTRE
        }
        public class infoBanque
        {
            public string code { get; set; }
            public string libelle { get; set; }
        }
        public Dictionary<TYPEBANQUE, infoBanque> dictInfoBanques = new Dictionary<TYPEBANQUE, infoBanque>();
        public string CODE_JOURNAL = "";
        #endregion

        public Settings()
        {
            InitializeComponent();

            txtCodeJournal.Text = CODE_JOURNAL;
            txtCptAttente.Text = CPT_ATTENTE;
            nbLblMaxLen.Value = MAX_LENGTH_LIBELLE;

            txtCodeCA.Text = CPT_CA;
            txtCodeCM.Text = CPT_CM;
            txtCodeCMa.Text = CPT_CMA;
            txtCodeBNP.Text = CPT_BNP;
            txtCodeAutre.Text = CPT_AUTRE;

            txtLblCA.Text = LBL_CA;
            txtLblCM.Text = LBL_CM;
            txtLblCMa.Text = LBL_CMA;
            txtLblBNP.Text = LBL_BNP;
            txtLblAutre.Text = LBL_AUTRE;

            fillDict();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fillDict();

            MAX_LENGTH_LIBELLE = Convert.ToInt32(nbLblMaxLen.Value);
            CODE_JOURNAL = txtCodeJournal.Text.ToLower();
            CPT_ATTENTE = txtCptAttente.Text;
            this.Dispose();
        }

        private void fillDict()
        {
            dictInfoBanques.Clear();
            dictInfoBanques.Add(TYPEBANQUE.CA, new infoBanque() { code = txtCodeCA.Text, libelle = txtLblCA.Text });
            dictInfoBanques.Add(TYPEBANQUE.CM, new infoBanque() { code = txtCodeCM.Text, libelle = txtLblCM.Text });
            dictInfoBanques.Add(TYPEBANQUE.CMA, new infoBanque() { code = txtCodeCMa.Text, libelle = txtLblCMa.Text });
            dictInfoBanques.Add(TYPEBANQUE.BNP, new infoBanque() { code = txtCodeBNP.Text, libelle = txtLblBNP.Text });
            dictInfoBanques.Add(TYPEBANQUE.AUTRE, new infoBanque() { code = txtCodeAutre.Text, libelle = txtLblAutre.Text });
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
