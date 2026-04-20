using Microsoft.EntityFrameworkCore;

namespace FYFI.Repository.InMemory
{
    public class FYFIContext : DbContext
    {
        public FYFIContext(DbContextOptions options) : base(options)
        {
        }


    }
}
