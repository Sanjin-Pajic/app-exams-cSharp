using DLWMS.WinForms.IB200002;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.Reports
{
    public partial class frmIzvjestaj : Form
    {
        private List<StudentiPredmeti> _listaStudenata;
        public frmIzvjestaj(List<StudentiPredmeti> listaStudenata)
        {
            InitializeComponent();
            _listaStudenata = listaStudenata;
        }

        private void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            var rds = new ReportDataSource();
            var rpc = new ReportParameterCollection();
            var tbl = new dsStudenti.tblStudentiDataTable();
            rpc.Add(new ReportParameter("ProsjecnaOcjena", _listaStudenata.Average(o => o.Ocjena).ToString()));

            foreach (var s in _listaStudenata)
            {
                var red = tbl.NewtblStudentiRow();
                red.ImePrezime = s.Student.ToString();
                red.Predmet = s.Predmet.ToString();
                red.Datum = s.DatumPolaganja.ToString();
                red.Ocjena = s.Ocjena.ToString();
                tbl.AddtblStudentiRow(red);
            }
            rds.Value = tbl;
            rds.Name = "dsStudenti";
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.RefreshReport();
        }
    }
}
