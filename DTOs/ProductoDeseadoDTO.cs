namespace ApiTienda.DTOs
{
    public class ProductoDeseadoDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public ProductoDto? Producto { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDto? Usuario { get; set; }
    }

    public class ProductoDto
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public string ? Descripcion { get; set; }
        public CategoriaDto ? Categoria { get; set; }
    }

    public class UsuarioDto
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
    }

    public class CategoriaDto
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
    }
}