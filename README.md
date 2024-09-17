<h2 align="center"> API Tienda </h2>

Este proyecto es una API RESTful para una tienda en línea que permite a los usuarios buscar productos y gestionar una lista de productos deseados. Está construida con .NET y utiliza MySQL para la gestión de datos.

## Características

- Consultar el listado de categorías de productos.
- Consultar el listado de productos.
- Consultar el detalle de un producto.
- Agregar un producto a la lista de "Productos deseados".
- Eliminar un producto de la lista de "Productos deseados".
- Consultar el listado de productos deseados de un usuario.

## Tecnologías utilizadas

- **.NET 6**
- **Entity Framework Core** (para la gestión de datos)
- **MySQL** (como base de datos)
- **Postman** (para probar los endpoints)
- **Git** y **GitHub** (para el control de versiones)

## Instalación

### Requisitos previos

Antes de empezar, asegúrate de tener instalado lo siguiente:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL](https://www.mysql.com/downloads/)
- [Git](https://git-scm.com/)
- [Postman](https://www.postman.com/downloads/) (opcional, para probar la API)

### Pasos para instalar y ejecutar el proyecto

1. **Clonar el repositorio**

   Clona este repositorio en tu máquina local:

   ```bash
   git clone https://github.com/AnderAlvarado13/api-tienda.git

2. **Configurar la base de datos MySQL**
   ```sql
    CREATE DATABASE tienda_db;
   ```
> [!NOTE]
    > Es necesario que cree en su base de datos MySQL cree el schemas `tienda_db` y modificar las credencias en la ruta: appsettings.json:
    ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=tienda_db;User=root;Password=tucontrasena;"
      }
    ```
    Reemplaza root por tu usuario de MySQL y tu-contrasena por tu contraseña de MySQL.
   
4. **Instalar las dependencias del proyecto**
   ```bash
   dotnet restore
5. **Agregar la migración inicial**
   Si es la primera vez que trabajas con el proyecto y necesitas crear la estructura de la base de datos, deberás agregar una migración inicial. Para ello, ejecuta el siguiente comando:
   ```bash
   dotnet ef migrations add InitialCreate
   ```
   Una vez creada la migración, debes aplicarla a la base de datos ejecutando:
   ```bash
   dotnet ef database update
   ```
   Esto creará todas las tablas necesarias en la base de datos MySQL.

6. **Ejecutar la API**
  ```bash
   dotnet run
   ```
  La API debería estar disponible en `https://localhost:5023`

### Probar la API
   Para probar la API, puedes usar Postman o cualquier cliente HTTP. Aquí hay un ejemplo de cómo probar la funcionalidad de agregar un producto a la lista de productos deseados:
  > [!NOTE]
  > Se realizaron pruebas unitarias con postman puedes encontrar estos casos de uso en el siguiente link `[https://documenter.getpostman.com/view/31586031/2sAXjM3B9r](https://documenter.getpostman.com/view/31586031/2sAXqpAQ8B#1d89b836-42f7-42de-8a93-b91445d7b5f5)`.


