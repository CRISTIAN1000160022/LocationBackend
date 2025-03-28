# Location
## Descripción
Location es una aplicación diseñada para gestionar ubicaciones y rastrear la información relevante de diferentes puntos geográficos.

## Tecnologías utilizadas
- **Backend**: .NET Framework (Web API)
- **Frontend**: Angular 19+
- **Base de Datos**: SQL Server

## Requisitos previos
Antes de ejecutar el proyecto, asegúrate de tener instalados:
- **SQL Server** con la base de datos `LocationDB` importada (usar el script `DBBexTech.sql`)
- **.NET Framework**
- **Node.js** y **Angular CLI** (para el frontend)
- **Git** (para el control de versiones)

## Instalación y ejecución

### Backend (.NET Framework)
1. Navega a la carpeta del backend:
   ```sh
   cd Location.Api
   ```
2. Restaura los paquetes NuGet:
   ```sh
   nuget restore
   ```
3. Configura la cadena de conexión en `Web.config`.
4. Ejecuta el proyecto desde Visual Studio o con:
   ```sh
   dotnet run
   ```
La API debería estar disponible en https://localhost:44329.

### Frontend (Angular 19+)
1. Navega a la carpeta del frontend:
   ```sh
   cd Location.Web
   ```
2. Instala las dependencias:
   ```sh
   npm install
   ```
3. Ejecuta la aplicación:
   ```sh
   ng serve --open
   ```

Esto abrirá la aplicación en el navegador en `http://localhost:4200/`.

## Endpoints principales (API)
- **GET** `/Country/GetAllCountries` - Obtiene la información de todos los paises
- **POST** `/Country/AddCountry` - Crea un nuevo país
- **PUT** `/Country/UpdateCountry` - Actualiza la información de un país
- **DELETE** `/Country/DeleteCountry/{id}` - Elimina un país

## Notas sobre la prueba técnica
- Se aplicaron principios **SOLID** en el diseño de la API.
- Se implementó paginación y ordenamiento en la tabla de ubicaciones.

## Autor
Cristian Andres Jimenez Arciniegas

