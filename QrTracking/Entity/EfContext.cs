using System.Data.Entity;

namespace MasterDetail.WebApp.Entity
{
    public class EfContext : DbContext
    {
        public EfContext()
            : base("name=DefaultConnection")
        {
        
        }

        static EfContext()
        {
//            try
//            {
//                Database.SetInitializer<EfContext>(new DropCreateDatabaseIfModelChanges<EfContext>());
//            }
//            catch (Exception)
//            {
//                throw;
//            }
        }

        public DbSet<QrTracking> QrTrackings { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }

    }
}