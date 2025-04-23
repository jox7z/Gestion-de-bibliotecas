using System;
using System.Collections.Generic;
using AccesoDatos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.DBContext;

public partial class GBContext : DbContext
{
    private readonly string lContextoBD;
    public GBContext(string lContext)
    {
        lContextoBD = lContext ;
    }

    public GBContext(DbContextOptions<GBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbiblioAutor> TbiblioAutors { get; set; }

    public virtual DbSet<TbiblioCliente> TbiblioClientes { get; set; }

    public virtual DbSet<TbiblioLibro> TbiblioLibros { get; set; }

    public virtual DbSet<TbiblioPrestamo> TbiblioPrestamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Jose\\SQLEXPRESS; Database=GestionBibliotecas; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbiblioAutor>(entity =>
        {
            entity.HasKey(e => e.TnIdAutor).HasName("PK__TBIBLIO___131676C743AB1BA4");

            entity.ToTable("TBIBLIO_AUTOR");

            entity.Property(e => e.TnIdAutor).HasColumnName("TN_IdAutor");
            entity.Property(e => e.TcNacionalidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_Nacionalidad");
            entity.Property(e => e.TcNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_Nombre");
        });

        modelBuilder.Entity<TbiblioCliente>(entity =>
        {
            entity.HasKey(e => e.TnIdCliente).HasName("PK__TBIBLIO___491B3672F806575E");

            entity.ToTable("TBIBLIO_CLIENTES");

            entity.Property(e => e.TnIdCliente).HasColumnName("TN_IdCliente");
            entity.Property(e => e.TcAp1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Ap1");
            entity.Property(e => e.TcAp2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Ap2");
            entity.Property(e => e.TcCorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_CorreoElectronico");
            entity.Property(e => e.TcNombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Nombre");
            entity.Property(e => e.TcNumTelefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TC_NumTelefono");
        });

        modelBuilder.Entity<TbiblioLibro>(entity =>
        {
            entity.HasKey(e => e.TnIdLibro).HasName("PK__TBIBLIO___75F3BBC5F8E633BC");

            entity.ToTable("TBIBLIO_LIBRO");

            entity.Property(e => e.TnIdLibro).HasColumnName("TN_IdLibro");
            entity.Property(e => e.TcCategoria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TC_Categoria");
            entity.Property(e => e.TcEditorial)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TC_Editorial");
            entity.Property(e => e.TcTitulo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TC_Titulo");
            entity.Property(e => e.TnIdAutor).HasColumnName("TN_IdAutor");

            entity.HasOne(d => d.TnIdAutorNavigation).WithMany(p => p.TbiblioLibros)
                .HasForeignKey(d => d.TnIdAutor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TBIBLIO_L__TN_Id__398D8EEE");
        });

        modelBuilder.Entity<TbiblioPrestamo>(entity =>
        {
            entity.HasKey(e => e.TnIdPrestamo).HasName("PK__TBIBLIO___618FD074C55D1D53");

            entity.ToTable("TBIBLIO_PRESTAMO");

            entity.Property(e => e.TnIdPrestamo).HasColumnName("TN_IdPrestamo");
            entity.Property(e => e.TfFecDevolucion).HasColumnName("TF_FecDevolucion");
            entity.Property(e => e.TfFecPrestamo).HasColumnName("TF_FecPrestamo");
            entity.Property(e => e.TnIdCliente).HasColumnName("TN_IdCliente");
            entity.Property(e => e.TnIdLibro).HasColumnName("TN_IdLibro");

            entity.HasOne(d => d.TnIdClienteNavigation).WithMany(p => p.TbiblioPrestamos)
                .HasForeignKey(d => d.TnIdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TBIBLIO_P__TN_Id__3F466844");

            entity.HasOne(d => d.TnIdLibroNavigation).WithMany(p => p.TbiblioPrestamos)
                .HasForeignKey(d => d.TnIdLibro)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TBIBLIO_P__TN_Id__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
