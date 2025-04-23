using System;
using System.Collections.Generic;
using AccesoDatos.EntidadesSeguridad;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.DBContext;

public partial class SEGContext : DbContext
{
    private readonly string lContextoBD;
    public SEGContext(string lContext)
    {
        lContextoBD = lContext;
    }

    public SEGContext(DbContextOptions<SEGContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TusrPerfile> TusrPerfiles { get; set; }

    public virtual DbSet<TusrUsuario> TusrUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Jose\\SQLEXPRESS; Database=SEGURIDAD_APP; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TusrPerfile>(entity =>
        {
            entity.HasKey(e => e.TnPerfil);

            entity.ToTable("TUSR_PERFILES");

            entity.Property(e => e.TnPerfil)
                .ValueGeneratedNever()
                .HasColumnName("TN_Perfil");
            entity.Property(e => e.TcNomPerfil)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_NomPerfil");

            entity.HasMany(d => d.TcUsuarios).WithMany(p => p.TnPerfils)
                .UsingEntity<Dictionary<string, object>>(
                    "TusrPerfilesxusuario",
                    r => r.HasOne<TusrUsuario>().WithMany()
                        .HasForeignKey("TcUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TUSR_PERFILESXUSUARIO_TUSR_USUARIOS"),
                    l => l.HasOne<TusrPerfile>().WithMany()
                        .HasForeignKey("TnPerfil")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TUSR_PERFILESXUSUARIO_TUSR_PERFILES"),
                    j =>
                    {
                        j.HasKey("TnPerfil", "TcUsuario");
                        j.ToTable("TUSR_PERFILESXUSUARIO");
                        j.IndexerProperty<int>("TnPerfil").HasColumnName("TN_Perfil");
                        j.IndexerProperty<string>("TcUsuario")
                            .HasMaxLength(40)
                            .IsUnicode(false)
                            .HasColumnName("TC_Usuario");
                    });
        });

        modelBuilder.Entity<TusrUsuario>(entity =>
        {
            entity.HasKey(e => e.TcUsuario);

            entity.ToTable("TUSR_USUARIOS");

            entity.Property(e => e.TcUsuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TC_Usuario");
            entity.Property(e => e.TcContrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_Contrasena");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
