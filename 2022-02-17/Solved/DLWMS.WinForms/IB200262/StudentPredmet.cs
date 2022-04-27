using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.IB200262
{
    [Table("StudentiPredmeti")]
    public class StudentPredmet
    {
        public int Id { get; set; }
        public virtual Student Student_Id { get; set; }
        public virtual Predmet Predmet_Id { get; set; }
        public int Ocjena { get; set; }
        public DateTime DatumPolaganja { get; set; }

    }
}
