using CachingWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CachingWebAPI.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }



        public DbSet<Driver> Drivers { get; set; }
    }
}
