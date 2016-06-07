using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BankOperationEnrichment
{
    public partial class PreviewFile : Form
    {
        private BindingSource bsGrid = new BindingSource();

        public PreviewFile()
        {
            InitializeComponent();
            dataGridPreview = new DataGridView();
        }

        public PreviewFile(List<string> dataList)
        {
            InitializeComponent();
            dataGridPreview = new DataGridView();
            bsGrid.DataSource = dataList;
            dataGridPreview.DataSource = bsGrid;
        }

        public PreviewFile(DataTable dataTable)
        {
            InitializeComponent();
            dataGridPreview = new DataGridView();
            bsGrid.DataSource = dataTable;
            dataGridPreview.DataSource = bsGrid;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }
    }
}
