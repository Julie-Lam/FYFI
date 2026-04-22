using Microsoft.EntityFrameworkCore;

namespace FYFI.Repository.InMemory.Model
{
    public class FYFIDbContext : DbContext
    {

        public DbSet<FiOutlook> FiOutlooks { get; set; }
        public DbSet<FiOutlookYear> FiOutlookYears { get; set; }
        //public FYFIDbContext(DbContextOptions options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=FYFIDb;Trusted_Connection=True;Trust Server Certificate=True");
        }


    }
}
