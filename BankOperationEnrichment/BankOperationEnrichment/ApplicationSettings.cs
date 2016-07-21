using System.Collections.Generic;

namespace BankOperationEnrichment
{
    public class ApplicationSettings
    {
        public enum TYPEBANQUE
        {
            CA,
            CM,
            CMA,
            BNP,
            AUTRE
        }

        public class InfoBank
        {
            public string code { get; set; }
            public string libelle { get; set; }
            public string codeJournal { get; set; }
        }

        public Dictionary<TYPEBANQUE, InfoBank> DICO { get; set; }
        public int MAX_CHAR_LIBELLE { get; set; }
        public string CPT_ATTENTE { get; set; }
        public string DECIMAL_SEPARATOR { get; set; }
        public bool AUTO_DECIMAL_SEPARATOR { get; set; }
    }
}
