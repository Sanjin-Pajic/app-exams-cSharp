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
        private List<StudentiPredmeti> listaStudenata;
       
        public frmIzvjestaj(List<StudentiPredmeti> listaStudenata)
        {
            InitializeComponent();
            this.listaStudenata = listaStudenata;
        }

        private void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            var rds = new ReportDataSource();
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("BrojPolozenih", listaStudenata.Count.ToString()));
            rpc.Add(new ReportParameter("Prosjecna", listaStudenata.Average(o=>o.Ocjena).ToString()));

            var tbl = new dsStudenti.tblStudentiDataTable();
            foreach (var s in listaStudenata)
            {
                var red = tbl.NewtblStudentiRow();
                red.Rb = s.Id.ToString();
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
