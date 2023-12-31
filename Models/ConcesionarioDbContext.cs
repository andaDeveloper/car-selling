﻿using System;
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

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = KAISER; Trusted_Connection=True;TrustServerCertificate=True ;Database = ConcesionarioDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Cliente__9B8553FC15502E78");

            entity.ToTable("Cliente");

            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NombreCliente).HasMaxLength(50);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK__Marca__CEC375E77F60ED59");

            entity.ToTable("Marca");

            entity.Property(e => e.Idmarca).HasColumnName("IDMarca");
            entity.Property(e => e.NombreMarca).HasMaxLength(50);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Idmodelo).HasName("PK__Modelo__A33B9CD603317E3D");

            entity.ToTable("Modelo");

            entity.Property(e => e.Idmodelo).HasColumnName("IDModelo");
            entity.Property(e => e.Idmarca).HasColumnName("IDMarca");
            entity.Property(e => e.NombreModelo).HasMaxLength(50);

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.Idmarca)
                .HasConstraintName("FK__Modelo__IDMarca__0519C6AF");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Idsucursal).HasName("PK__Sucursal__696BA6100BC6C43E");

            entity.ToTable("Sucursal");

            entity.Property(e => e.Idsucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.NombreSucursal).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__5231116907F6335A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Contra).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.Idvendedor).HasName("PK__Vendedor__AE8889FF0F975522");

            entity.ToTable("Vendedor");

            entity.Property(e => e.Idvendedor).HasColumnName("IDVendedor");
            entity.Property(e => e.Idsucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.NombreVendedor).HasMaxLength(50);

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Vendedors)
                .HasForeignKey(d => d.Idsucursal)
                .HasConstraintName("FK__Vendedor__IDSucu__1273C1CD");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Vendedors)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Vendedor__IDUsua__117F9D94");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__Venta__27134B821920BF5C");

            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Idmodelo).HasColumnName("IDModelo");
            entity.Property(e => e.Idvendedor).HasColumnName("IDVendedor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK__Venta__IDCliente__1B0907CE");

            entity.HasOne(d => d.IdmodeloNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idmodelo)
                .HasConstraintName("FK__Venta__IDModelo__1BFD2C07");

            entity.HasOne(d => d.IdvendedorNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idvendedor)
                .HasConstraintName("FK__Venta__IDVendedo__1CF15040");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
