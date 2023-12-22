using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sql_oriented_app.Models;

public partial class ConcesionarioDbContext : DbContext
{
    public ConcesionarioDbContext()
    {
    }

    public ConcesionarioDbContext(DbContextOptions<ConcesionarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vendedore> Vendedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = KAISER; Trusted_Connection=True;TrustServerCertificate=True ;Database = ConcesionarioDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Clientes__9B8553FC15502E78");

            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NombreCliente).HasMaxLength(50);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK__Marcas__CEC375E77F60ED59");

            entity.Property(e => e.Idmarca).HasColumnName("IDMarca");
            entity.Property(e => e.NombreMarca).HasMaxLength(50);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Idmodelo).HasName("PK__Modelos__A33B9CD603317E3D");

            entity.Property(e => e.Idmodelo).HasColumnName("IDModelo");
            entity.Property(e => e.Idmarca).HasColumnName("IDMarca");
            entity.Property(e => e.NombreModelo).HasMaxLength(50);

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.Idmarca)
                .HasConstraintName("FK__Modelos__IDMarca__0519C6AF");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.Idsucursal).HasName("PK__Sucursal__696BA6100BC6C43E");

            entity.Property(e => e.Idsucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.NombreSucursal).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__5231116907F6335A");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Vendedore>(entity =>
        {
            entity.HasKey(e => e.Idvendedor).HasName("PK__Vendedor__AE8889FF0F975522");

            entity.Property(e => e.Idvendedor).HasColumnName("IDVendedor");
            entity.Property(e => e.Idsucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.NombreVendedor).HasMaxLength(50);

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Vendedores)
                .HasForeignKey(d => d.Idsucursal)
                .HasConstraintName("FK__Vendedore__IDSuc__1273C1CD");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Vendedores)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Vendedore__IDUsu__117F9D94");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__Ventas__27134B821920BF5C");

            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Idmodelo).HasColumnName("IDModelo");
            entity.Property(e => e.Idvendedor).HasColumnName("IDVendedor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK__Ventas__IDClient__1B0907CE");

            entity.HasOne(d => d.IdmodeloNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idmodelo)
                .HasConstraintName("FK__Ventas__IDModelo__1BFD2C07");

            entity.HasOne(d => d.IdvendedorNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idvendedor)
                .HasConstraintName("FK__Ventas__IDVended__1CF15040");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
