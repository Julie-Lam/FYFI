using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FyFi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } //DbSert<> represents the db table(s)

        public AppDbContext() 
        { 
        }

    }
}
