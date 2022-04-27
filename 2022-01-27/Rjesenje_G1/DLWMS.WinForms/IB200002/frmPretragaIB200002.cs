using DLWMS.WinForms.DB;
using DLWMS.WinForms.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IB200002
{
    public partial class frmPretragaIB200002 : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        string filterPredmeta = "";
        List<StudentiPredmeti> listaStudenata;
        public frmPretragaIB200002()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmPretragaIB200002_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Filtriraj();
        }

        private List<StudentiPredmeti> Filtriraj()
        {
            listaStudenata = _baza.StudentiPredmeti.Where(p => filterPredmeta == "" || p.Predmet.Naziv.ToLower().Contains(filterPredmeta)).ToList();
            this.Text = $"Ukupno zapisa: {listaStudenata.Count()}";
            return listaStudenata;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                filterPredmeta = textBox1.Text.ToLower();
                UcitajPodatke();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("Jeste li sigurni da zelite obrisati predmet?", "Obavijest", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var odabraniPredmet = dataGridView1.SelectedRows[0].DataBoundItem as StudentiPredmeti;
                    _baza.StudentiPredmeti.Remove(odabraniPredmet);
                    _baza.SaveChanges();
                    UcitajPodatke();
                }
            }
            if(e.ColumnIndex == 5)
            {
                var _student = dataGridView1.SelectedRows[0].DataBoundItem as StudentiPredmeti;
                var frmSlike = new frmStudentSlikeIB200002(_student);
                frmSlike.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmIzvj = new frmIzvjestaj(listaStudenata);
            frmIzvj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frmT = new frmTeorijaIB200002();
            frmT.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            double suma = 0;
            await Task.Run(() =>
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    int Od = int.Parse(textBox2.Text);
                    int Do = int.Parse(textBox3.Text);
                    for (int i = Od; i < Do; i++)
                    {
                        Thread.Sleep(50);
                        suma += i;
                    }
                }
            });
            Action akcija = () => textBox4.Text = suma.ToString();
            BeginInvoke(akcija);
        }
    }
}
