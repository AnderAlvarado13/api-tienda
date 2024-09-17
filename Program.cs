using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiTienda.Models;
using ApiTienda.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión y versión del servidor MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

// Agregar servicios necesarios
builder.Services.AddControllers();

var app = builder.Build();

// Agregar middleware de manejo de excepciones
app.UseMiddleware<ExceptionMiddleware>();

// Configuración del pipeline de la aplicación
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();