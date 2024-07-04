# InscripcionAppMVC

# Proyecto InscripcionAppMVC

Este proyecto utiliza ASP.NET Core MVC con DevExpress, y las vistas están diseñadas usando Tailwind CSS y Blazor.

## Descripción

El proyecto facilita la inscripción de aspirantes a programas académicos. Incluye funcionalidades para registrar aspirantes, matricularlos en programas específicos y consultar inscripciones existentes.

## Estructura del Proyecto

El proyecto se organiza en controladores que manejan las principales funcionalidades:

- **InformacionController**: Controla vistas relacionadas con la información de inscripciones y detalles de aspirantes.
- **RegistroController**: Gestiona el registro de nuevos aspirantes y la matriculación en programas académicos.

## Modelos

### Aspirante

Representa los datos de un aspirante que se registrará en el sistema.

### Inscripcion

Representa la matrícula de un aspirante en un programa académico.

### Programa

Define los programas académicos disponibles para matrícula.

### TipoAspirante

Define los tipos de aspirantes que pueden registrarse.

### Otros Modelos

Se utilizan modelos adicionales para manejar tipos de documento y otros datos estáticos.

## Validaciones

Se han implementado validaciones de datos en los modelos utilizando atributos de validación de ASP.NET Core, como `Required`, `StringLength`, `DataType`, y `EmailAddress`.

## Vistas

Todas las vistas han sido diseñadas utilizando **Tailwind CSS** para la estilización y **Blazor** para la interactividad.

## Configuración del Proyecto

Para ejecutar este proyecto localmente:

1. Clona el repositorio desde GitHub.
2. Abre el proyecto en Visual Studio 2022.
3. Asegúrate de tener todos los paquetes NuGet necesarios instalados.
4. Configura la conexión a la base de datos en `appsettings.json`.
5. Ejecuta la aplicación desde Visual Studio.

¡Disfruta explorando y desarrollando con InscripcionAppMVC!
