namespace ApiTienda.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public ICollection<ProductoDeseado>? ProductosDeseados { get; set; }
    }
}
