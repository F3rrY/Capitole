# Prueba técnica de Capitole Consulting

En esta prueba técnica, se pedía lo siguiente:

Implementar un microservicio que permita gestionar la siguiente funcionalidad:

Una Empresa de renting. El microservicio debería de permitir realizar las siguientes acciones (a través de llamadas REST):
- Debería de gestionar la creación de nuevos vehículos para la flota.
- Poder listar los vehículos disponibles de la flota.
- Poder alquilar un vehículo.
- Devolución del vehículo.

Restricciones:
- Una misma persona no debería de poder reservar más de 1 vehículo al mismo tiempo.
- La flota no debe de contener vehículos cuya fecha de fabricación sea superior a 5 años.

Para ello, nos debíamos basar en una arquitectura hexagonal, además de implementar los siguientes test:
- Funcional
- Unitario
- Infraestructura

Para desplegar la aplicación, podíamos utilizar docker y/o docker-compose

## Implementación

Para realizar esta prueba técnica, el entorno de trabajo ha sido:

- Máquina: Macbook Pro 2018 (core i7, 16 GB Ram, 512 GB disco duro)
- IDE: Jetbrains Rider 2024 3.3
- Base de datos: SQL Server (en una imagen de docker)
- Azure Data Studio (en Windows se puede usar SQL Server Management Studio)

A nivel de código, se ha desarrollado un proyecto de tipo “ASP NET Core Webapi en .NET 8” llamado “RentingAPI”, en la que se ha implementado arquitectura hexagonal. Para mantener el control de estados, he decidido implementar un diseño enfocado hacía DDD con tres entidades: Alquiler, Vehículos y Clientes

Nota: La gestión de clientes no estaba en el enunciado, pero he considerado interesante ponerlo para gestionar los alquileres y vincularlos a los mismos.

Para mejorar la gestión/escalabilidad de la aplicación, he utilizado los siguientes patrones de diseño:
- MediatR
- CQRS (Command Query Responsability Segregation)
- Repository
- Factory
- Unit of Work

Además, he añadido un middleware para devolver las excepciones (customizadas) en un formato adecuado.

## Despliegue

Para poder desplegar y hacer las pruebas pertinentes, se tienen que realizar los siguientes pasos:
1.	Descargar el repositorio a una carpeta local
2.	Asegurarnos de tener docker instalado en la máquina local
3.	Abrir una terminal (o Powershell o cmd con derechos de administrador) y acceder a la carpeta de la raíz del proyecto (donde está el fichero yaml)
4.	Ejecutar el comando “docker-compose up --build” para desplegar los contenedores de las dos imágenes
a.	Imagen con el proyecto
b.	Imagen con el SQL Server 2022
5.	Una vez ejecutado, nos aseguraremos que está desplegado si, al ejecutar el comando “docker ps” vemos dos contenedores:
6.	Acceder a la carpeta “RentingAPI.Infrastructure”, ya que ahí es donde están los ficheros relativos a las migraciones
7.	Ejecutar el comando “dotnet ef update database” para inicializar la estructura de base de datos (a partir de la migración Inicial)
8.	Una vez con todo, ya podremos acceder a http://localhost:8080/swagger y ver los endpoints disponibles
