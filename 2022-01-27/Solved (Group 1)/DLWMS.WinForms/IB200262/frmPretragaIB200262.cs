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

namespace DLWMS.WinForms.IB200262
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
            UcitajStudente();
        }

        private void UcitajStudente()
        {
            try
            {
                Filtriraj();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message}");
            }
        }

        private void Filtriraj()
        {
            var listaStudenata = DLWMSdb.Baza.StudentiPredmeti.ToList();
            var filter = txtFilter.Text.ToLower();
            if (String.IsNullOrEmpty(filter))
            {
                dgvMain.DataSource = listaStudenata;
                Text = $"Broj zapisa: {listaStudenata.Count}";
                return;
            }
            listaStudenata = DLWMSdb.Baza.StudentiPredmeti.Where(item => item.Predmet.Naziv.ToLower().Contains(filter)).ToList();
            dgvMain.DataSource = listaStudenata;
            Text = $"Broj zapisa: {listaStudenata.Count}";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("Jeste li sigurni da zelite izbrisati predmet?", "Obavijest", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var odabraniPredmet = dgvMain.SelectedRows[0].DataBoundItem as StudentiPredmeti;
                        DLWMSdb.Baza.StudentiPredmeti.Remove(odabraniPredmet);
                        DLWMSdb.Baza.SaveChanges();
                        UcitajStudente();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message}");
                    }
                }

            }
            if (e.ColumnIndex == 5)
            {
                var forma = new frmReport().ShowDialog();   
            }
        }
    }
}
