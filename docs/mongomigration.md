# 10. Automatización de Base de Datos

## Librería `OnlineCourses.MongoMigration`
Objetivo: ejecutar migraciones, crear colecciones, índices y datos iniciales de MongoDB.

## Arquitectura
- `MongoMigrationService` - punto central.
- `IMigrationStep` - contrato de cada paso.
- `MongoMigrationOptions` - configuración de conexión.
- `SeedData` - datos iniciales de usuarios y cursos.

## Funcionalidades
- Crear colecciones si no existen.
- Crear índices únicos y compuestos.
- Aplicar migraciones incrementales.
- Sembrar datos de prueba.
- Registrar actividad en logs.

## Ejemplo de uso

```csharp
var migration = new MongoMigrationService(settings, logger);
migration.ApplyMigrations();
```

## Estructura de carpetas
- `OnlineCourses.MongoMigration/` - proyecto de librería.
- `Migrations/` - clases de migración.
- `Seed/` - datos iniciales.
- `Interfaces/` - contratos.

## Beneficios
- Centraliza cambios de esquema.
- Evita cambios manuales en MongoDB Atlas.
- Permite despliegues repetibles.
