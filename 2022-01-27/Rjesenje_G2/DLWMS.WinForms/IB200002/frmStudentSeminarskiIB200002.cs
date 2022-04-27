using DLWMS.WinForms.DB;
using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.P5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IB200002
{
    public partial class frmStudentSeminarskiIB200002 : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        private StudentiPredmeti _student;
        int brojacSlika = 0;

        public frmStudentSeminarskiIB200002(StudentiPredmeti student)
        {
            InitializeComponent();
            _student = student;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                _student.Student.SlikeSeminarskih.Add(new PredmetiSeminarski
                {
                    Student = _student.Student,
                    Predmet = _student.Predmet,
                    DatumDodavanja = DateTime.Now,
                    Opis = textBox1.Text,
                    Slika = ImageHelper.FromImageToByte(pictureBox1.Image),
                });
                _baza.SaveChanges();
                MessageBox.Show("Slika uspjesno dodana", "Obavijest");
                OcistiSadrzaje();
                UcitajSlikuDatumOpis();
            }
        }

        private void OcistiSadrzaje()
        {
            pictureBox1.Image = null;
            textBox1.Clear();
        }

        private bool Validiraj()
        {
            return Validator.ValidirajKontrolu(pictureBox1, errorProvider1, Poruke.ObaveznaVrijednost) &&
                 Validator.ValidirajKontrolu(textBox1, errorProvider1, Poruke.ObaveznaVrijednost);
        }

        private void frmStudentSeminarskiIB200002_Load(object sender, EventArgs e)
        {
            lblImePrezime.Text = _student.Student.ToString();
            lblPredmet.Text = _student.Predmet.ToString();
            UcitajSlikuDatumOpis();
        }

        private void UcitajSlikuDatumOpis()
        {
                    if (_student.Student.SlikeSeminarskih.Count() != 0)
                    {
                        var prvaSlika = _student.Student.SlikeSeminarskih[brojacSlika];
                        pictureBox2.Image = ImageHelper.FromByteToImage(prvaSlika.Slika);
                        UcitajDatumOpis(_student.Student.SlikeSeminarskih[brojacSlika].DatumDodavanja,
                            _student.Student.SlikeSeminarskih[brojacSlika].Opis);
                        lblStranica.Text = $"Stranica {brojacSlika + 1}/{_student.Student.SlikeSeminarskih.Count()}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var brojac = brojacSlika + 1;
            if(brojac <= _student.Student.SlikeSeminarskih.Count() - 1)
            {
                brojacSlika++;
                pictureBox2.Image = ImageHelper.FromByteToImage(_student.Student.SlikeSeminarskih[brojacSlika].Slika);
                UcitajDatumOpis(_student.Student.SlikeSeminarskih[brojacSlika].DatumDodavanja, 
                    _student.Student.SlikeSeminarskih[brojacSlika].Opis);
                lblStranica.Text = $"Stranica {brojacSlika + 1}/{_student.Student.SlikeSeminarskih.Count()}";
            }
            else
            {
                MessageBox.Show("Nema slike", "Obavijest");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var brojac = brojacSlika - 1;
            if (brojac >= 0)
            {
                brojacSlika--;
                pictureBox2.Image = ImageHelper.FromByteToImage(_student.Student.SlikeSeminarskih[brojacSlika].Slika);
                UcitajDatumOpis(_student.Student.SlikeSeminarskih[brojacSlika].DatumDodavanja,
                    _student.Student.SlikeSeminarskih[brojacSlika].Opis);
                lblStranica.Text = $"Stranica {brojacSlika + 1}/{_student.Student.SlikeSeminarskih.Count()}";
            }
            else
            {
                MessageBox.Show("Nema slike", "Obavijest");
            }
        }

        private void UcitajDatumOpis(DateTime datumDodavanja, string opis)
        {
            lblDatum.Text = datumDodavanja.ToString();
            lblOpis.Text = opis;
        }
    }
}
