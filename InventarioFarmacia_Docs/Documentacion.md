# Documentación del Proyecto - Inventario de Farmacéutica

## Resumen

El siguiente documento proporciona una guía completa sobre el proyecto de inventario de farmacéutica, incluyendo su propósito, análisis estructura y uso, complementandose con el avance de dichos temas en transcurso de los cursos pertenecientes a la carrera.

## Propósito del Proyecto

El proyecto tiene como objetivo principal desarrollar un sistema de gestión de inventario para una farmacéutica, que permita llevar un control eficiente de los productos farmacéuticos, automatizando el control de exitencias, y optimizando los procesos de compra y venta.

### Análisis de Requerimientos

El análisis de requerimientos se centra en identificar las necesidades del usuario y los requisitos funcionales y no funcionales del sistema, estos son extraídos a través una entrevista directa con el cliente. Algunos de los requerimientos clave incluyen:

- **Gestión de Inventarios**: Capacidad para controlar el inventario y sus productos existentes, al tener esta farmacia 2 inventarios distintos, un inventario local que es el que se maneja en la farmacia para la venta de medicamentos al público, y un inventario externo donde se realiza el almacenamiento del stock en reserva.
- **Gestión de Productos**: Capacidad para añadir, editar y eliminar productos del registro de productos contemplados por la farmacia.
- **Actualización de precios**: Capacidad de actualizar el precio de un producto de manera automática al realizar una compra del mismo, en este caso, aplicar el precio medio obtenido del precio anterior en comparación al nuevo precio.
- **Gestión de Productos Individuales**: Capacidad de gestionar cada existencia de un producto de manera individual, considerando su ubicación entre los los diferentes inventarios, asi como su estado y fecha de caducidad.
- **Control de Stock**: Monitoreo de niveles de stock y alertas para reabastecimiento o fecha de caducidad próxima, asi como una metodología FIFO para las ventas.
- **Orden y filtrado**: Capacidad de retornar al usuario solo la información que precisa, haciendo uso de categorías y filtros para facilitar la búsqueda de productos específicos.
- **Gestión de Compras y Ventas**: Registro de transacciones de compra y venta, automatizando el registro y actualización de los inventarios luego de esas operaciones, brindando la capacidad de generar facturas al momento de realizar una venta.
- **Informes y Estadísticas**: Control sobre las operaciones realizadas, disponiendo de una bitacora de operaciones para productos y para inventarios, de la cual se pueden generar informes acerca de los movimientos realizados en la farmacia.
- **Gestión de Usuarios**: Control de acceso al sistema, permitiendo la creación de perfiles de usuario para mantener un nivel de registro que incluya a los mismos en las operaciones realizadas y su registro en las bitácoras de operaciones.
- **Interfaz de Usuario Intuitiva**: Un diseño amigable que facilite la navegación y uso del sistema.

### Elección de tecnologías Utilizadas

Para el desarrollo del sistema de gestión de inventario, se han seleccionado las siguientes tecnologías:

- **Base de Datos**: SQLite para un almacenamiento ligero y eficiente de datos, asi como por la capacidad de crear backups de manera rápida al ser un archivo local.
- **Backend**: .NET Core Minimal APIs para la creación de la API RESTful, aprovechando los conocimientos adquiridos en el transcurso de la carrera, así como por su facilidad de uso y escalabilidad.
- **Frontend**: Blazor Pages para una interfaz de usuario dinámica y responsiva, siendo una solución muy ideal para el manejo de estados globales, así como para la creación de componentes reutilizables.
- **Control de Versiones**: Git y GitHub para el seguimiento del desarrollo.
- **Despliegue**: Despliegue en la plataforma de Azure para todo el proyecto, haciendo uso de Azure App Service.
- **Documentación**: Swagger, utilizado para la documentación de la API.
