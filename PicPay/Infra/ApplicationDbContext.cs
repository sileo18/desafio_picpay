using Microsoft.EntityFrameworkCore;
using PicPay.Entidades;

namespace PicPay.Infra;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Carteira> Carteiras { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(u => u.CpfCnpj).IsUnique();

            entity.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            entity.Property(u => u.CpfCnpj).IsRequired().HasMaxLength(14);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.HasIndex(u => u.Email).IsUnique();
           
            entity.HasOne(u => u.Carteira) 
                .WithOne(c => c.Titular) 
                .HasForeignKey<Carteira>(c => c.TitularId) 
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Carteira>(entity =>
        {
            entity.Property(c => c.Saldo).HasColumnType("decimal(18,2)");
        });
        
        modelBuilder.Entity<Transferencia>(entity =>
        {
            entity.Property(t => t.Valor).IsRequired().HasColumnType("decimal(18,2)");
            
            entity.HasOne(t => t.Credor) 
                  .WithMany() 
                  .HasForeignKey(t => t.CredorId) 
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(t => t.Tomador) 
                .WithMany() 
                .HasForeignKey(t => t.TomadorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });
        
    }
}