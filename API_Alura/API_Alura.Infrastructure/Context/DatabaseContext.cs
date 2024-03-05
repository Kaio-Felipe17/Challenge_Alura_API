using API_Alura.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alura.Infrastructure.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Depoimentos> Depoimentos { get; set; }
}
