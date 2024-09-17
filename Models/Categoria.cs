namespace ApiTienda.Models
{
    public class Categoria
    {
    public int Id { get; set; }
    public string ?Nombre { get; set; }
    public required ICollection<Producto> Productos { get; set; }
    }
}