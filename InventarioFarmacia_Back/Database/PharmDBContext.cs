using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;
namespace InventarioFarmacia_Back;

public class PharmDBContext : DbContext
{
    public PharmDBContext(DbContextOptions<PharmDBContext> options) : base(options) { }

    #region Tablas Independientes
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Inventario> Inventarios => Set<Inventario>();
    public DbSet<Lote> Lotes => Set<Lote>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Orden_Compra> Orden_Compras => Set<Orden_Compra>();
    #endregion

    #region Tablas Dependientes
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<Producto_Individual> Productos_Individuales => Set<Producto_Individual>();
    public DbSet<Detalle_Venta> Detalle_Ventas => Set<Detalle_Venta>();
    public DbSet<Bitacora_Inventario> Bitacora_Inventarios => Set<Bitacora_Inventario>();
    public DbSet<Bitacora_Producto> Bitacora_Productos => Set<Bitacora_Producto>();
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region CONFIGURACIÓN DE RELACIONES PARA NAVIGATION PROPERTIES

        // Categoria -> Producto (Many-to-Many)
        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.Id_Categoria)
            .OnDelete(DeleteBehavior.Restrict);

        // Producto -> Lotes (1:N)
        modelBuilder.Entity<Producto>()
            .HasMany(p => p.Lotes)
            .WithOne(l => l.Producto)
            .HasForeignKey(p => p.Id_Producto)
            .OnDelete(DeleteBehavior.Restrict);

        // Producto_Individual -> Lote (N:1)
        modelBuilder.Entity<Producto_Individual>()
            .HasOne<Lote>()
            .WithMany(l => l.ProductosIndividuales)
            .HasForeignKey(pi => pi.Id_Lote)
            .OnDelete(DeleteBehavior.Cascade);

        // Producto -> Inventario (1:N)
        modelBuilder.Entity<Producto_Individual>()
            .HasOne<Inventario>()
            .WithMany()
            .HasForeignKey(pi => pi.Id_Inventario)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario -> Ventas (1:N)
        modelBuilder.Entity<Venta>()
            .HasOne(v => v.Usuario)
            .WithMany(u => u.Ventas)
            .HasForeignKey(v => v.Id_Usuario)
            .OnDelete(DeleteBehavior.SetNull);

        // Lotes -> Inventarios (M:N)
        modelBuilder.Entity<Inventario>()
            .HasMany(i => i.LotesDeProducto)
            .WithMany(l => l.Inventarios)
            .UsingEntity(j => j.ToTable("InventarioLote"));

        // Venta -> DetalleVentas (1:N)
        modelBuilder.Entity<Detalle_Venta>()
            .HasOne(dv => dv.Venta)
            .WithMany(v => v.DetalleVentas)
            .HasForeignKey(dv => dv.Id_Venta)
            .OnDelete(DeleteBehavior.Cascade);

        // Producto -> DetalleVentas (1:N) - Sin Navigation Property en Producto
        modelBuilder.Entity<Detalle_Venta>()
            .HasOne(dv => dv.Producto)
            .WithMany()  // Sin Navigation Property
            .HasForeignKey(dv => dv.Id_Producto)
            .OnDelete(DeleteBehavior.Cascade);

        // Orden_Compra -> Lotes (N:M)
        modelBuilder.Entity<Lote>()
            .HasMany(l => l.OrdenesCompra)
            .WithMany(oc => oc.LotesInvolucrados)
            .UsingEntity(j => j.ToTable("OrdenCompraLote"));

        // Orden_Compra -> Productos Individuales (1:N)
        modelBuilder.Entity<Orden_Compra>()
            .HasMany<Producto_Individual>()
            .WithOne()
            .HasForeignKey(pi => pi.Id_OrdenCompra)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario -> BitacoraInventarios (1:N)
        modelBuilder.Entity<Bitacora_Inventario>()
            .HasOne<Usuario>()  // Sin Navigation Property en Bitacora
            .WithMany(u => u.BitacoraInventarios)
            .HasForeignKey(bi => bi.Id_Usuario)
            .OnDelete(DeleteBehavior.SetNull);

        // Inventario -> BitacoraInventarios (1:N)
        modelBuilder.Entity<Bitacora_Inventario>()
            .HasOne<Inventario>()  // Sin Navigation Property en Bitacora
            .WithMany(i => i.BitacoraInventarios)
            .HasForeignKey(bi => bi.Id_Inventario)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario -> BitacoraProductos (1:N)
        modelBuilder.Entity<Bitacora_Producto>()
            .HasOne<Usuario>()  // Sin Navigation Property en Bitacora
            .WithMany(u => u.BitacoraProductos)
            .HasForeignKey(bp => bp.Id_Usuario)
            .OnDelete(DeleteBehavior.SetNull);

        // Producto -> BitacoraProductos (1:N)
        modelBuilder.Entity<Bitacora_Producto>()
            .HasOne<Producto>()  // Sin Navigation Property en Bitacora
            .WithMany(p => p.BitacoraProductos)
            .HasForeignKey(bp => bp.Id_Producto)
            .OnDelete(DeleteBehavior.Cascade);

        // Lote -> ProductosIndividuales (1:N)
        modelBuilder.Entity<Producto_Individual>()
            .HasOne<Lote>()
            .WithMany(l => l.ProductosIndividuales)
            .HasForeignKey(pi => pi.Id_Lote)
            .OnDelete(DeleteBehavior.SetNull);
        #endregion

        // Indices para mejorar rendimiento en busquedas recurrentes
        modelBuilder.Entity<Producto_Individual>()
            .HasIndex(pi => pi.Id_Lote)
            .HasDatabaseName("IX_Productos_Individuales_Nro_Lote");

        modelBuilder.Entity<Detalle_Venta>()
            .HasIndex(dv => dv.Id_Venta)
            .HasDatabaseName("IX_Detalle_Ventas_Id_Venta");

        modelBuilder.Entity<Bitacora_Inventario>()
            .HasIndex(bi => bi.Id_Inventario)
            .HasDatabaseName("IX_Bitacora_Inventarios_Id_Inventario");

        modelBuilder.Entity<Bitacora_Producto>()
            .HasIndex(bp => bp.Id_Producto)
            .HasDatabaseName("IX_Bitacora_Productos_Id_Producto");

    }
}
