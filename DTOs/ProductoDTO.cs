namespace ApiTienda.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public required string Descripcion { get; set; }
        public required string CategoriaNombre { get; set; } // Solo incluimos el nombre de la categoría
    }
}