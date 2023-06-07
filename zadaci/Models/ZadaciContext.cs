using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace zadaci.Models;

public partial class ZadaciContext : DbContext
{
    public ZadaciContext()
    {
    }

    public ZadaciContext(DbContextOptions<ZadaciContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Zadaci> Zadacis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RICCI\\SQLEXPRESS;Database=zadaci;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Zadaci>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__zadaci__3213E83F9EB3A634");

            entity.ToTable("zadaci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NazivZadatka)
                .HasMaxLength(200)
                .HasColumnName("nazivZadatka");
            entity.Property(e => e.Stanje)
                .HasDefaultValueSql("((0))")
                .HasColumnName("stanje");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
