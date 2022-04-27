using DLWMS.WinForms.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms
{
    public partial class frmPretragaIB200262 : Form
    {
        public frmPretragaIB200262()
        {
            InitializeComponent();
            dgvMain.AutoGenerateColumns = false;
        }

        private void frmPretragaIB200262_Load(object sender, EventArgs e)
        {
            try
            {
            UcitajStudente();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message}");
            }

        }

        private void UcitajStudente()
        {
            dgvMain.DataSource = null;
            dgvMain.DataSource = DLWMSdb.Baza.StudentiPredmeti.ToList();
        }
    }
}
