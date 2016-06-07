using System;

namespace BankOperationEnrichment
{
    public class Data
    {
        public DateTime Date { get; set; }
        public string CodeJournal { get; set; }
        public string NumeroCompte { get; set; }
        public string NumeroOperation { get; set; }
        public string Libelle { get; set; }
        public double Depense { get; set; }
        public double Recettes { get; set; }
    }
}
