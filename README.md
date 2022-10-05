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
