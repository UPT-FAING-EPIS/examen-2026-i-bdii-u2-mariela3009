# 16. Estructura Final del Repositorio

```text
/examen-2026-i-bdii-u2-mariela3009
├── backend
│   ├── OnlineCourses.Api
│   │   ├── Controllers
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   └── OnlineCourses.Api.csproj
│   ├── OnlineCourses.Core
│   │   ├── Entities
│   │   ├── Interfaces
│   │   └── OnlineCourses.Core.csproj
│   ├── OnlineCourses.Infrastructure
│   │   ├── Repositories
│   │   ├── Services
│   │   └── OnlineCourses.Infrastructure.csproj
│   ├── OnlineCourses.MongoMigration
│   │   ├── Migrations
│   │   ├── Seed
│   │   └── OnlineCourses.MongoMigration.csproj
│   └── tests
│       ├── OnlineCourses.UnitTests
│       └── OnlineCourses.IntegrationTests
├── frontend
│   ├── src
│   │   ├── app
│   │   │   ├── auth
│   │   │   ├── courses
│   │   │   ├── dashboard
│   │   │   ├── enrollments
│   │   │   ├── notifications
│   │   │   └── shared
│   │   ├── index.html
│   │   └── main.ts
│   ├── angular.json
│   └── package.json
├── terraform
│   ├── provider.tf
│   ├── variables.tf
│   ├── main.tf
│   ├── networking.tf
│   ├── compute.tf
│   ├── security.tf
│   └── outputs.tf
├── docs
│   ├── analisis.md
│   ├── arquitectura.md
│   ├── api-spec.md
│   ├── cloud-infra.md
│   ├── db-design.md
│   ├── frontend.md
│   ├── mongomigration.md
│   ├── tests.md
│   ├── terraform.md
│   └── structure.md
├── migrations
│   ├── seed-data.json
│   └── README.md
├── diagrams
│   └── architecture.mmd
├── .github
│   └── workflows
│       ├── backend-ci.yml
│       ├── frontend-ci.yml
│       ├── terraform.yml
│       ├── generate-diagrams.yml
│       └── generate-docs.yml
├── Dockerfile.backend
├── Dockerfile.frontend
├── docker-compose.yml
└── README.md
```
