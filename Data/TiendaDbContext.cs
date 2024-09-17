using Microsoft.EntityFrameworkCore;
using ApiTienda.Models;

public class TiendaDbContext : DbContext
{
    public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<ProductoDeseado> ProductosDeseados { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}