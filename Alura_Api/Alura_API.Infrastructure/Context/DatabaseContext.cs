using Alura_API.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura_API.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Depoimentos> Depoimentos { get; set; }
    }
}
