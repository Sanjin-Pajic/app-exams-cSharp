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
        int filterOcjena;
        List<StudentiPredmeti> listaStudenata;
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        public frmPretragaIB200002()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            textBox2.ScrollBars = ScrollBars.Vertical; //da se mogu skrolati generisani predmeti
        }

        private void frmPretragaIB200002_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
            comboBox2.DataSource = _baza.Studenti.ToList();
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Filtriraj();
        }

        private List<StudentiPredmeti> Filtriraj()
        {
            listaStudenata = _baza.StudentiPredmeti.Where(o => o.Ocjena >= filterOcjena).ToList();
            this.Text = $"Ukupno zapisa: {listaStudenata.Count()}";
            return listaStudenata;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                filterOcjena = int.Parse(comboBox1.SelectedItem.ToString());
                UcitajPodatke();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                int brojac = int.Parse(textBox1.Text);
                var rand = new Random();
                for (int i = 0; i < brojac; i++)
                {
                    Thread.Sleep(100);
                    var noviS = new StudentiPredmeti
                    {
                        Student = comboBox2.SelectedItem as Student,
                        Predmet = _baza.Predmeti.ToList().ElementAt(rand.Next(1, 4)),
                        Ocjena = rand.Next(5, 11),
                        DatumPolaganja = DateTime.Now,
                    };
                    _baza.StudentiPredmeti.Add(noviS);
                    Action akcija = () => textBox2.Text += $"Za {comboBox2.SelectedItem as Student} dodat polozeni -> {noviS.Predmet.Naziv} ({noviS.Ocjena}) {Environment.NewLine}";
                    BeginInvoke(akcija);
                }
                _baza.SaveChanges();
                UcitajPodatke();
                MessageBox.Show("Dodavanje predmeta završeno");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frmTeorija = new frmTeorijaIB200002();
            frmTeorija.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frmI = new frmIzvjestaj(listaStudenata);
            frmI.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                var _student = dataGridView1.SelectedRows[0].DataBoundItem as StudentiPredmeti;
                var frmSeminarski = new frmStudentSeminarskiIB200002(_student);
                frmSeminarski.Show();
            }
        }
    }
}
