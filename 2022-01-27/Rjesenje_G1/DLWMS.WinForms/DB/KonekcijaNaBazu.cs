
using DLWMS.WinForms.IB200002;
using System.Data.Entity;

namespace DLWMS.WinForms.DB
{

    //DLWMSContext
    public class KonekcijaNaBazu : DbContext
    {
        public KonekcijaNaBazu() : base("DLWMSPutanja")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Studenti");                      
        }       
        public virtual DbSet<Student> Studenti { get; set; }
        public virtual DbSet<Predmeti> Predmeti { get; set; }
        public virtual DbSet<StudentiPredmeti> StudentiPredmeti { get; set; }
        public virtual DbSet<StudentiSlike> StudentiSlike { get; set; }
       
    }
}