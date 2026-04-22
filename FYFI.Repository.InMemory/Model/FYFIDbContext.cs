using Microsoft.EntityFrameworkCore;

namespace FYFI.Repository.InMemory.Model
{
    public class FYFIDbContext : DbContext
    {

        DbSet<FiOutlook> FiOutlooks { get; set; }
        DbSet<FiOutlookYear> FiOutlookYears { get; set; }
        //public FYFIDbContext(DbContextOptions options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FYFIDb;Trusted_Connection=True;");
        }


    }
}
