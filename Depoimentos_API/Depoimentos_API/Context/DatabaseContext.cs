using Depoimentos_API.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Depoimentos_API.Context
{
    public interface IDatabaseContext
    {
        DbSet<Depoimentos> Depoimentos { get; set; }
    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Depoimentos> Depoimentos { get; set; }
    }
}
