# SisVentas
Este es un Sistema de Ventas sencillo en C# utilizando Windows Forms y SQL Server, donde pude aprender y aplicar:
* Programación en capas
* Procedimientos almacenados
* Triggers
* Re-utilización de código
* Controles mas comunes en Windows Forms
* Debug
* Conexión entre C# y SQL Server
* Utilización de parámetros desde C#
* [ADO.NET](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ "ADO.NET")

Entre otras cosas que me sirvieron de experiencia durante el aprendizaje del lenguaje C#.

## Para utilizar el proyecto 
Para poder utilizar el proyecto deben de crear la base de datos ejecutando el Script _"dbventas_Script.sql"_ o restaurar el backup _"dbventas_Bakup.bak"_ ubicados en [SisVentas/Base de Datos/](https://github.com/robertlluberes/SisVentas/tree/master/Base%20de%20Datos "Base de Datos"), tener en cuenta que utilice SQL Server 2008 R2.

Posteriormente cambiar el _ConnetionString_ correspondiente a su equipo en el archivo _"app.config"_ ubicado en [ SisVentas/CapaDatos/
](https://github.com/robertlluberes/SisVentas/tree/master/CapaDatos), tener en cuenta que utilice Visual Studio 2015 Community Update 2.

Acceso al sistema

**Usuario:** admin
**Contraseña:** admin

## Funcionalidades
* Gestión de acceso (trabajadores) de acuerdo a perfil
* Gestión de proveedores
* Gestión de almacén (Artículos, Categorías, Presentación)
* Gestión de compras (Ingresos a almacén, Proveedores)
* Gestión de ventas y clientes
* Backup de base de datos del sistema
* Reportes

## Fuente original
Este sistema fue desarrollado siguiendo el tutorial "[Sistema de Ventas C# - Visual Studio 2013 y Sql Server 2014](https://www.youtube.com/playlist?list=PLZPrWDz1Molqn16IORKg8nFYTejgYCHJp)" por Juan Carlos Arcila Díaz. Sin embargo he realizado cambios simples en cuanto a optimización de código o "Clean code" y funcionalidades no fueron desarrolladas en el tutorial, como la encriptación de contraseñas o poder realizar backup de la base de datos directamente desde la aplicación.

El sistema se puede mejorar considerablemente, aunque entiendo es una buena base para empezar.
