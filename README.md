# Plataforma de Matrícula de Cursos Online

## Visión General
Este repositorio contiene el diseño, la arquitectura y la implementación inicial de una plataforma moderna para la matrícula de cursos online.

La solución combina un backend en **ASP.NET Core Web API**, un frontend en **Angular**, una base de datos **MongoDB Atlas** y despliegue en **AWS** con automatización CI/CD y Terraform.

## Contenido del Repositorio

- `backend/` - Código fuente y pruebas del API .NET.
- `frontend/` - Aplicación Angular con módulos y servicios.
- `terraform/` - Infraestructura como código para AWS.
- `.github/workflows/` - GitHub Actions para CI/CD, documentación y diagramas.
- `docs/` - Documentación técnica del sistema.
- `migrations/` - Scripts y migraciones de datos iniciales.
- `diagrams/` - Diagramas Mermaid del diseño arquitectónico.

## Arquitectura
La plataforma utiliza una arquitectura basada en:

- Clean Architecture
- Domain-Driven Design (DDD)
- Repository Pattern
- Unit of Work
- JWT + Refresh Tokens
- MongoDB para datos flexibles y escalables

## Cómo comenzar

1. Instale .NET SDK 8+ y Node.js 20+.
2. Configure las variables de entorno en `backend/OnlineCourses.Api/appsettings.Development.json`.
3. Desde `backend/OnlineCourses.Api`, ejecute:
   ```bash
   dotnet restore
   dotnet build
   dotnet run
   ```
4. Desde `frontend`, ejecute:
   ```bash
   npm install
   npm start
   ```

## Estructura general

- `backend/OnlineCourses.Api` - Proyecto API.
- `backend/OnlineCourses.Core` - Dominio y contratos.
- `backend/OnlineCourses.Infrastructure` - Implementaciones MongoDB.
- `backend/OnlineCourses.MongoMigration` - Librería de migraciones.
- `frontend/src/app` - Módulos y componentes Angular.
- `terraform/` - VPC, subredes, ALB, ECS, seguridad.

## Recursos principales

- `docs/analisis.md` - Análisis del sistema y requerimientos.
- `docs/arquitectura.md` - Diagramas y decisiones arquitectónicas.
- `docs/db-design.md` - Diseño de colecciones MongoDB.
- `docs/api-spec.md` - API RESTful detallada.
- `docs/security.md` - Seguridad y control de accesos.
- `docs/frontend.md` - Diseño del frontend Angular.
- `docs/terraform.md` - Descripción de la infraestructura Terraform.
- `docs/mongomigration.md` - Diseño de la librería MongoMigration.
- `docs/tests.md` - Estrategia de pruebas.
- `docs/structure.md` - Árbol de carpetas final.

## URL sugerida del repositorio
https://github.com/UPT-FAING-EPIS/examen-2026-i-bdii-u2-mariela3009

---

Para más detalles utilice los documentos en `docs/` y los archivos de implementación en `backend/` y `frontend/`.
