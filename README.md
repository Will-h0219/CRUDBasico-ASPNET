# CRUDBasico-ASPNET
En este API se crean las funciones para realizar operaciones básicas CRUD (Create - Read - Update -Delete) en una base de datos utilizando equipos de futbol colombianos. Este proyecto es una base para entender el funcionamiento del framework ASP.NET Core y pueden expandirse las tablas, metodos, etc necesarios; como se menciono, solo es la base para un entendimiento de operaciones basicas y algunas buenas practicas.
En este documento se podrán ver los pasos realizados para crear el proyecto, así como notas de conceptos a tener en cuenta, al final del mismo se encontrarn los pasos para recrear la base de datos y poder utilizar los endpoints de forma local ya sea con Swagger (herramienta por defecto de ASP.NET) o Postman.

## Requisitos
- Visual Studio Community 2019
- Microsoft SQL Server Management Studio - [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- Postman - Opcional para probar los endpoints

**Nota: EL proyecto fue desarrollado con .net 5.0 el cual ya no tiene soporte, para recrear el proyecto en .net6 se requiere Visual Studio 2022. Se recomienda consultar la documentación oficial sobre los cambios en el framework**

## Pasos para recrear el proyecto
El proyecto se desarrollo con los siguientes pasos, pueden seguirse de forma similar para .net6 teniendo en cuenta las diferencias entre las versiones del framework.
1. Crear el nuevo proyecto como un web api. Para más información consultar la [documentación oficial](https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
2. Despues de iniciado el proyecto se eliminan las clases WeatherForecast (controller y clase) en caso de no quererla, en el proyecto se eliminaron para no generar ruido en la aplicación.
3. Se instalan los paquetes que nos permitiran trabajar con Sql Server (Se utilizara una base de datos local) y [EntityFramework Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools

   Los paquetes se instalan a traves del NuGet PackageManager: Solution Explorer > Click derecho en CRUDBasico > Manage NuGet Packages...
4. La base de datos se crea a partir del codigo (Code First) para utilizar Entity Framework Core, tambien se podria migrar de una base de datos existente. Se utiliza esta aproximación ya que es más sencilla.
   - Crear la clase AppDbContext la cual tendra el llamado de los modelos que conformaran las tablas de la base de datos.
   - Crear los modelos necesarios para la base de datos, en este caso las propiedades de cada clase hacen referencia a las columnas de la tabla en la base de datos a excepción de las propiedades de referencia. Consultar la documentación de EF Core para más información sobre las relaciones (uno a uno, uno a muchos, mucho sa muchos)
5. Definir en AppSetting.Development.json la seccion "ConnectionString" para poder conectar con la base de datos
   - Initial Catalog contiene el nombre de la base de datos
6. Registrar la clase AppDbContext en la clase startup
7. Por medio de la consola (Package Manager Console) escribir los comandos que crearan la base de datos
   - ```Add-Migration DESCRIPCION_CORTA_SIN_COMILLAS_NI_ESPACION```
   - ```Update-Database```
   
   **Nota: Cada que se realice una modificación o se cree una clase que requiera de una tabla en la base de datos se vuelven a correr los comandos para actualizar la base de datos. Cada "Migration" crea un archivo en la carpeta "Migrations"**
8. Crear servicios encargados de manipular la data de la base de datos. EN el proyecto se utiliza la configuración de EF Core para acceder a la data.
9. Crear las interfaces correspondientes a cada Servicio (Se recomienda revisar documentación sobre Inyección de dependencias en ASP.NET).
10. Registrar los servicios en la clase startup para poder inyectarlos en las clases que los requieran. Este paso es impotante ya que sin este registro las clases no podran hacer uso de los metodos de las clases que se estan inyectando.
11. Crear clases DTOs para la creación o actualización de las entidades de la base de datos.

    **Nota: Consultar información sobre el uso de Data Transfer Objects (DTO)**
12. Crear los controladores necesarios, usualmente es buena practica crear un controlador para una función especifica, en este caso para una tabla especifica (equipo o jugador)
    - Inyectar el servicio necesario en el constructor e inicializarlo como un campo.
    - Crear los metodos Http necesarios para un CRUD (Get - Post - Put - Delete)

**Nota: Agregar configuración en la clase startup > ConfigureServices >** ```services.AddControllers()``` **en caso de tener error de referencias circulares. Este error es comun al tratar de traer los objectos directamente de la base de datos incluyendo listas o referencias a objetos de otras tablas, este error se puede prevenir con el uso de DTOs y AutoMapper.**

## Pasos para recrear la base de datos
La forma más sencilla para recrear la base de datos es la siguiente:
1. Una vez clonado el repositorio y abierto en Visual Studio, Solution Explorer > Click derecho en la carpeta "Migrations" y "Delete" para eliminar la carpeta Migrations.
2. Verificar el nombre de la base de datos a crear. El nombre se puede cambiar desde el archivo ```appsettings.Development.json``` el cual se puede encontrar expandiendo el archivo ```appsettings.json```.
3. Verificar que no exista una base de datos previa con el mismo nombre. Para esto en Visual Studio, en la barra superior de herramientas click en "View" > SQL Server Object Explorer > (localdb)\MSSQLLocalDB > Databases. En el listado no debe existir una base de datos con elmismo nombre que la que vamos a usar.
