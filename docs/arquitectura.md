# 2. Arquitectura de Software

## Principios arquitectónicos
La solución está diseñada con:
- Clean Architecture
- Domain Driven Design (DDD)
- Repository Pattern
- Unit of Work
- Dependency Injection
- SOLID
- CQRS cuando se requiera separación lectura/escritura

## Diagrama de Arquitectura General

```mermaid
flowchart LR
  A[Frontend Angular] -->|HTTP/HTTPS| B[API ASP.NET Core]
  B --> C[Servicios de Dominio]
  C --> D[MongoDB Atlas]
  B --> E[Auth JWT / Refresh Tokens]
  B --> F[Azure/CloudWatch Logs]
  B --> G[Redis Cache opcional]
```

## Diagrama de Componentes

```mermaid
flowchart TD
  subgraph API
    APIC[Controllers]
    BIZ[Servicios de Dominio]
    REPO[Repositorios MongoDB]
    MIG[MongoMigration]
  end
  APIC --> BIZ
  BIZ --> REPO
  REPO --> DDB[MongoDB Atlas]
  APIC --> E[Middleware Seguridad]
```

## Diagrama de Capas

```mermaid
flowchart TB
  UI[Presentación Angular]
  API[API ASP.NET Core]
  DOMAIN[Dominio / Entidades]
  INFRA[Infraestructura / MongoDB]

  UI --> API
  API --> DOMAIN
  API --> INFRA
  INFRA --> DB[MongoDB Atlas]
```

## Diagrama de Despliegue

```mermaid
flowchart LR
  user[Usuario] -->|HTTPS| alb[ALB AWS]
  alb -->|HTTP| ecs[ECS Fargate]
  ecs -->|TLS| mongodb[MongoDB Atlas]
  ecs -->|Logs| cloudwatch[CloudWatch]
  ecs -->|DNS| route53[Route53]
```

## Diagrama de Secuencia para matrícula

```mermaid
sequenceDiagram
  actor Estudiante
  participant Frontend
  participant API
  participant Servicio as EnrollmentService
  participant Repositorio as EnrollmentRepository
  participant Mongo as MongoDB

  Estudiante->>Frontend: Solicita inscripción
  Frontend->>API: POST /enrollments
  API->>Servicio: Registrar matrícula
  Servicio->>Repositorio: Crear documento de matrícula
  Repositorio->>Mongo: Insertar registro
  Mongo-->>Repositorio: Confirmación
  Repositorio-->>Servicio: Matrícula creada
  Servicio-->>API: Devuelve estado
  API-->>Frontend: 201 Created
```

## Diagrama ER equivalente para MongoDB

```mermaid
erDiagram
  USERS {
    string Id PK
    string Nombre
    string Correo
    string ContraseñaHash
    string Rol
    date FechaRegistro
  }
  COURSES {
    string Id PK
    string Titulo
    string Descripcion
    string Categoria
    string Nivel
    int Duracion
    string Instructor
    decimal Precio
    array Temario
    date FechaCreacion
  }
  ENROLLMENTS {
    string Id PK
    string UsuarioId FK
    string CursoId FK
    date FechaMatricula
    string Estado
    int Progreso
  }
  NOTIFICATIONS {
    string Id PK
    string UsuarioId FK
    string Tipo
    string Mensaje
    date Fecha
  }
  USERS ||--o{ ENROLLMENTS : "tiene"
  COURSES ||--o{ ENROLLMENTS : "contiene"
  USERS ||--o{ NOTIFICATIONS : "recibe"
```
