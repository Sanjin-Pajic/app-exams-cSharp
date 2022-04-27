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
    public partial class frmStudentSlikeIB200002 : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        private StudentiPredmeti _student;
        int brojacSlika = 0;
        public frmStudentSlikeIB200002(StudentiPredmeti student)
        {
            InitializeComponent();
            _student = student;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var novaSlika = new StudentiSlike()
                {
                    Student = _student.Student,
                    DatumDodavanja = DateTime.Now,
                    Opis = textBox1.Text,
                    Slika = ImageHelper.FromImageToByte(pictureBox1.Image),
                };
                _baza.StudentiSlike.Add(novaSlika);
                _baza.SaveChanges();
                OcistiSadrzaj();
                UcitajSlike();
                MessageBox.Show("Uspjesno dodana slika", "Obavijest");
            }
        }
        private void frmStudentSlikeIB200002_Load(object sender, EventArgs e)
        {
            UcitajSlike();
        }

        private void UcitajSlike()
        {
            if (_student.Student.SlikeStudenta.Count() != 0)
            {
                var prvaSlika = ImageHelper.FromByteToImage(_student.Student.SlikeStudenta[brojacSlika].Slika);
                pictureBox2.Image = prvaSlika;
                lblBrojacSlika.Text = $"Slika {brojacSlika + 1} / {_student.Student.SlikeStudenta.Count()}";
                UcitajDatumOpis(_student.Student.SlikeStudenta[brojacSlika].DatumDodavanja, _student.Student.SlikeStudenta[brojacSlika].Opis);
            }
        }

        private void UcitajDatumOpis(DateTime datumDodavanja, string opis)
        {
            lblDatum.Text = datumDodavanja.ToString();
            lblOpis.Text = opis;
        }

        private bool Validiraj()
        {
            return Validator.ValidirajKontrolu(textBox1, errorProvider1, Poruke.ObaveznaVrijednost) &&
                  Validator.ValidirajKontrolu(pictureBox1, errorProvider1, Poruke.ObaveznaVrijednost);
        }
        private void OcistiSadrzaj()
        {
            textBox1.Clear();
            pictureBox1.Image = null;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var brojac = brojacSlika + 1;
            if (brojac <= _student.Student.SlikeStudenta.Count() - 1) 
            {
                brojacSlika++;
                var prvaSlika = ImageHelper.FromByteToImage(_student.Student.SlikeStudenta[brojacSlika].Slika);
                pictureBox2.Image = prvaSlika;
                lblBrojacSlika.Text = $"Slika {brojacSlika + 1} / {_student.Student.SlikeStudenta.Count()}";
                UcitajDatumOpis(_student.Student.SlikeStudenta[brojacSlika].DatumDodavanja, _student.Student.SlikeStudenta[brojacSlika].Opis);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var brojac = brojacSlika - 1;
            if (brojac >= 0)
            {
                brojacSlika--;
                var prvaSlika = ImageHelper.FromByteToImage(_student.Student.SlikeStudenta[brojacSlika].Slika);
                pictureBox2.Image = prvaSlika;
                lblBrojacSlika.Text = $"Slika {brojacSlika + 1} / {_student.Student.SlikeStudenta.Count()}";
                UcitajDatumOpis(_student.Student.SlikeStudenta[brojacSlika].DatumDodavanja, _student.Student.SlikeStudenta[brojacSlika].Opis);
            }
        }
    }
}
