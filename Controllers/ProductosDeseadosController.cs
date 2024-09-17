using ApiTienda.DTOs;
using ApiTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductosDeseadosController : ControllerBase
{
    private readonly TiendaDbContext _context;

    public ProductosDeseadosController(TiendaDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> AddProductoDeseado([FromBody] ProductoDeseadoDto productoDeseadoDto)
    {
        // Cargar Producto y Usuario desde la base de datos
        var producto = await _context.Productos.FindAsync(productoDeseadoDto.ProductoId);
        var usuario = await _context.Usuarios.FindAsync(productoDeseadoDto.UsuarioId);

        if (producto == null || usuario == null)
        {
           throw new NotFoundException("Producto o Usuario no encontrado.");
        }

        // Crear el objeto ProductoDeseado con los datos recibidos
        var productoDeseado = new ProductoDeseado
        {
            ProductoId = productoDeseadoDto.ProductoId,
            UsuarioId = productoDeseadoDto.UsuarioId,
            Producto = producto,
            Usuario = usuario
        };

        _context.ProductosDeseados.Add(productoDeseado);
        await _context.SaveChangesAsync();

        // Mapear el modelo ProductoDeseado al DTO para la respuesta
        var responseDto = new ProductoDeseadoDto
        {
            Id = productoDeseado.Id,
            ProductoId = productoDeseado.ProductoId,
            UsuarioId = productoDeseado.UsuarioId,
            Producto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion
            },
            Usuario = new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre
            }
        };

        // Devolver el DTO como respuesta
        return CreatedAtAction(nameof(GetProductosDeseados), new { id = productoDeseado.Id }, responseDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProductoDeseado(int id)
    {
        var productoDeseado = await _context.ProductosDeseados.FindAsync(id);
        if (productoDeseado == null)
        {
            throw new NotFoundException("Producto Deseado no encontrado.");
        }

        _context.ProductosDeseados.Remove(productoDeseado);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDeseadoDto>>> GetProductosDeseados()
    {
        var productosDeseados = await _context.ProductosDeseados
                                            .Include(pd => pd.Producto)
                                            .ThenInclude(p => p.Categoria)
                                            .Include(pd => pd.Usuario)
                                            .ToListAsync();

        // Mapear a DTO
        var productoDeseadoDtos = productosDeseados.Select(pd => new ProductoDeseadoDto
        {
            Id = pd.Id,
            ProductoId = pd.ProductoId,
            Producto = new ProductoDto
            {
                Id = pd.Producto.Id,
                Nombre = pd.Producto.Nombre,
                Categoria = new CategoriaDto
                {
                    Id = pd.Producto.Categoria.Id,
                    Nombre = pd.Producto.Categoria.Nombre
                }
            },
             Usuario = new UsuarioDto
            {
                Id = pd.Usuario.Id,
                Nombre = pd.Usuario.Nombre
            }
        }).ToList();

        return Ok(productoDeseadoDtos);
    }
}
