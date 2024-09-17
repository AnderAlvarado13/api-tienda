using ApiTienda.DTOs;
using ApiTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly TiendaDbContext _context;

    public ProductosController(TiendaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
    {
        var productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();

        // Mapeo de productos a ProductoDTO
        var productosDto = productos.Select(p => new ProductoDTO
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Precio = p.Precio,
            Descripcion = p.Descripcion,
            CategoriaNombre = p.Categoria.Nombre // Mapeas solo el nombre de la categoría
        }).ToList();

        return Ok(productosDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
    {
        
        var producto = await _context.Productos.Include(p => p.Categoria)
                                            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (producto == null)
        {
            throw new NotFoundException("Producto no encontrado");
        }

        // Mapeo de Producto a ProductoDTO
        var productoDto = new ProductoDTO
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Descripcion = producto.Descripcion,
            CategoriaNombre = producto.Categoria.Nombre
        };

        return Ok(productoDto);
    }
}
