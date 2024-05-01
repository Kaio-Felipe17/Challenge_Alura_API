using API_Alura.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alura.Infrastructure.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Depoimento> Depoimentos { get; set; }
    public DbSet<Destino> Destinos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Depoimento>(entity =>
        {
            entity.ToTable("Depoimentos").HasKey(x => x.Id);
            entity.Property(x => x.DepoimentoUsuario).HasColumnName("Depoimento");
        });
    }
}
