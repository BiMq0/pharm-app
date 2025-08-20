# Documentación del Proyecto - Sistema de Inventario Farmacéutico

## Resumen Ejecutivo

> **Objetivo Principal:** Desarrollar un sistema integral de gestión de inventario farmacéutico que optimice los procesos operativos y mejore el control de existencias mediante la automatización y digitalización de procesos.

Este documento proporciona una guía completa sobre el proyecto de inventario farmacéutico, incluyendo su propósito, análisis de requerimientos, arquitectura técnica y metodología de desarrollo, complementándose con los conocimientos adquiridos durante el transcurso de los cursos de la carrera.

## Propósito del Proyecto

El proyecto tiene como **objetivo principal** desarrollar un sistema de gestión de inventario para una farmacia, que permita llevar un control eficiente de los productos farmacéuticos, automatizando el control de existencias y optimizando los procesos de compra y venta.

### Beneficios Esperados

Los beneficios clave que se esperan obtener con la implementación del sistema incluyen:

- **Automatización** de procesos manuales repetitivos
- **Reducción significativa** de errores humanos en el manejo de inventario
- **Optimización** del tiempo de gestión y operaciones diarias
- **Mejora** en el control de fechas de caducidad y vencimientos
- **Incremento** en la eficiencia operativa general
- **Trazabilidad completa** de productos y movimientos
- **Generación automática** de reportes y estadísticas

## Análisis de Requerimientos

El análisis de requerimientos se centra en identificar las necesidades del usuario y los requisitos funcionales y no funcionales del sistema. Estos son extraídos a través de una entrevista directa con el cliente y análisis de procesos actuales.

> **Nota Importante:** El sistema debe manejar dos tipos de inventario distintos debido a la naturaleza del negocio farmacéutico.

### Requerimientos Funcionales Principales

#### 1. Gestión de Inventarios

**Capacidad para controlar múltiples inventarios:**

- **Inventario Local**: Manejo en farmacia para venta directa al público
- **Inventario Externo**: Almacenamiento de stock en reserva
- Transferencias entre inventarios
- Sincronización automática de datos

#### 2. Gestión de Productos

**Control completo del catálogo de productos:**

- Añadir nuevos productos con información completa
- Editar información de productos existentes
- Eliminar productos obsoletos del registro
- Categorización y clasificación de medicamentos

#### 3. Actualización Automática de Precios

**Sistema inteligente de gestión de precios:**

- Actualización automática al realizar compras
- Aplicación de precio medio ponderado
- Historial de cambios de precios
- Alertas de variaciones significativas

#### 4. Gestión de Productos Individuales

**Control granular de cada unidad:**

- Gestión individual de cada existencia
- Control de ubicación entre inventarios
- Seguimiento de estado del producto
- Monitoreo de fechas de caducidad

#### 5. Control de Stock y Alertas

**Monitoreo inteligente de inventario:**

- Monitoreo continuo de niveles de stock
- Alertas automáticas para reabastecimiento
- Notificaciones de productos próximos a caducar
- Implementación de metodología `FIFO` (First In, First Out)

#### 6. Sistema de Búsqueda y Filtrado

**Acceso eficiente a la información:**

- Filtros por categorías de productos
- Búsqueda por nombre, código o principio activo
- Ordenamiento personalizable de resultados
- Filtros avanzados por fecha, precio, stock

#### 7. Gestión de Compras y Ventas

**Automatización de transacciones comerciales:**

- Registro automático de compras y ventas
- Actualización instantánea de inventarios
- Generación automática de facturas
- Historial completo de transacciones
- Integración con sistemas de pago

#### 8. Reportes y Estadísticas

**Inteligencia de negocio integrada:**

- Bitácora completa de operaciones por producto
- Bitácora de movimientos por inventario
- Generación automática de informes
- Estadísticas de ventas y rotación de productos
- Análisis de tendencias y patrones

#### 9. Gestión de Usuarios y Seguridad

**Control de acceso y auditoria:**

- Creación y gestión de perfiles de usuario
- Niveles de acceso diferenciados
- Registro de usuarios en todas las operaciones
- Trazabilidad completa de acciones
- Sistema de autenticación seguro

#### 10. Interfaz de Usuario

**Experiencia de usuario optimizada:**

- Diseño intuitivo y amigable
- Navegación simplificada
- Responsive design para múltiples dispositivos
- Accesibilidad y usabilidad mejorada

## Stack Tecnológico

Para el desarrollo del sistema de gestión de inventario, se han seleccionado cuidadosamente las siguientes tecnologías, basándose en criterios de escalabilidad, mantenibilidad y conocimientos adquiridos:

### Base de Datos

**`SQLite`** - Sistema de gestión de base de datos

- Almacenamiento ligero y eficiente de datos
- Capacidad de crear backups rápidos (archivo local)
- Ideal para aplicaciones de tamaño medio
- Sin necesidad de servidor de base de datos dedicado

### Backend

**`.NET Core Minimal APIs`** - Framework de desarrollo

- Creación de API RESTful robusta y escalable
- Aprovechamiento de conocimientos de la carrera
- Facilidad de uso y desarrollo ágil
- Excelente rendimiento y escalabilidad
- Amplio soporte de la comunidad

### Frontend

**`Blazor Server Pages`** - Framework de interfaz de usuario

- Interfaz dinámica y responsiva
- Manejo eficiente de estados globales
- Componentes reutilizables y modulares
- Desarrollo en C# end-to-end
- Integración nativa con .NET

### Control de Versiones y Colaboración

**`Git`** y **`GitHub`** - Gestión de código fuente

- Seguimiento completo del desarrollo
- Colaboración en equipo
- Historial de cambios detallado
- Integración con CI/CD

### Infraestructura y Despliegue

**`Microsoft Azure`** - Plataforma en la nube

- **Azure App Service** para hosting de aplicaciones
- Escalabilidad automática
- Alta disponibilidad y confiabilidad
- Integración con herramientas de desarrollo

### Documentación de API

**`Swagger/OpenAPI`** - Documentación interactiva

- Documentación automática de endpoints
- Interfaz de pruebas integrada
- Estándares de la industria
- Facilita la integración y mantenimiento

## Arquitectura del Sistema

> **Patrón Arquitectónico:** El sistema implementa una arquitectura de capas con separación clara de responsabilidades, siguiendo principios SOLID y buenas prácticas de desarrollo.

### Componentes Principales

1. **Capa de Presentación** - Blazor Server Pages
2. **Capa de API** - .NET Core Minimal APIs
3. **Capa de Lógica de Negocio** - Servicios y reglas de negocio
4. **Capa de Acceso a Datos** - Entity Framework Core con SQLite
5. **Capa de Seguridad** - Autenticación y autorización

### Flujo de Datos

```
Usuario → Blazor UI → API Controller → Business Logic → Data Access → SQLite
```

## Metodología de Desarrollo

El proyecto sigue una metodología ágil con las siguientes características:

- **Desarrollo iterativo** con sprints cortos
- **Integración continua** mediante GitHub Actions
- **Pruebas automatizadas** para asegurar calidad
- **Documentación continua** del código y APIs
- **Revisión de código** colaborativa

---

**Fecha de última actualización:** Agosto 2025  
**Versión del documento:** 2.0  
**Estado del proyecto:** En desarrollo activo
