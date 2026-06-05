# 4. API RESTful

## Autenticación

### POST /auth/register
- Descripción: Registra un nuevo usuario en el sistema.
- Request:
```json
{
  "nombre": "Ana Pérez",
  "correo": "ana@ejemplo.com",
  "password": "P@ssw0rd2026",
  "rol": "Estudiante"
}
```
- Response 201:
```json
{
  "id": "64f...",
  "nombre": "Ana Pérez",
  "correo": "ana@ejemplo.com",
  "rol": "Estudiante"
}
```
- Validaciones:
  - `correo` único y formato válido.
  - `password` mínimo 8 caracteres.
- Códigos HTTP:
  - `201 Created` registro exitoso.
  - `400 Bad Request` datos inválidos.
  - `409 Conflict` usuario ya existe.

### POST /auth/login
- Descripción: Autentica usuario y genera tokens.
- Request:
```json
{
  "correo": "ana@ejemplo.com",
  "password": "P@ssw0rd2026"
}
```
- Response 200:
```json
{
  "accessToken": "eyJhb...",
  "refreshToken": "abcd...",
  "expiresIn": 3600
}
```
- Códigos HTTP:
  - `200 OK` si credenciales correctas.
  - `401 Unauthorized` si credenciales incorrectas.

### POST /auth/refresh-token
- Descripción: Renueva el token de acceso.
- Request:
```json
{
  "refreshToken": "abcd..."
}
```
- Response 200:
```json
{
  "accessToken": "eyJhb...",
  "expiresIn": 3600
}
```
- Códigos HTTP:
  - `200 OK` token renovado.
  - `401 Unauthorized` refresh token inválido.

## Cursos

### GET /courses
- Descripción: Lista cursos disponibles.
- Request: `GET /courses?categoria=Programacion&nivel=Intermedio`
- Response 200:
```json
[
  {
    "id": "61a...",
    "titulo": "Desarrollo Web con .NET",
    "categoria": "Programación",
    "nivel": "Intermedio",
    "duracion": 40,
    "instructor": "María López",
    "precio": 199.90,
    "fechaCreacion": "2026-06-01T12:00:00Z"
  }
]
```
- Códigos HTTP:
  - `200 OK` ok.
  - `400 Bad Request` parámetros inválidos.

### GET /courses/{id}
- Descripción: Recupera detalles de un curso.
- Response 200:
```json
{
  "id": "61a...",
  "titulo": "Desarrollo Web con .NET",
  "descripcion": "Crea aplicaciones modernas...",
  "categoria": "Programación",
  "nivel": "Intermedio",
  "duracion": 40,
  "instructor": "María López",
  "precio": 199.90,
  "temario": ["Introducción", "API REST"],
  "fechaCreacion": "2026-06-01T12:00:00Z"
}
```
- Códigos HTTP:
  - `200 OK` curso encontrado.
  - `404 Not Found` curso no encontrado.

### POST /courses
- Descripción: Crea un nuevo curso (rol Admin/Instructor).
- Request:
```json
{
  "titulo": "Introducción a MongoDB",
  "descripcion": "Aprende consultas NoSQL.",
  "categoria": "Bases de Datos",
  "nivel": "Principiante",
  "duracion": 30,
  "instructor": "José Ramírez",
  "precio": 149.90,
  "temario": ["Modelado", "Consultas"]
}
```
- Response 201:
```json
{
  "id": "62b...",
  "titulo": "Introducción a MongoDB"
}
```
- Códigos HTTP:
  - `201 Created` curso creado.
  - `400 Bad Request` datos incompletos.
  - `401 Unauthorized` sin token.
  - `403 Forbidden` rol insuficiente.

### PUT /courses/{id}
- Descripción: Actualiza un curso existente.
- Request: como POST, con campos actualizables.
- Response 200:
```json
{
  "id": "62b...",
  "titulo": "MongoDB Avanzado"
}
```
- Códigos HTTP:
  - `200 OK`
  - `400 Bad Request`
  - `401 Unauthorized`
  - `403 Forbidden`
  - `404 Not Found`

### DELETE /courses/{id}
- Descripción: Elimina un curso.
- Response 204 No Content.
- Códigos HTTP:
  - `204 No Content`
  - `401 Unauthorized`
  - `403 Forbidden`
  - `404 Not Found`

## Matrículas

### POST /enrollments
- Descripción: Crea una matrícula para un usuario.
- Request:
```json
{
  "usuarioId": "63c...",
  "cursoId": "61a..."
}
```
- Response 201:
```json
{
  "id": "70d...",
  "usuarioId": "63c...",
  "cursoId": "61a...",
  "estado": "Activo",
  "progreso": 0
}
```
- Validaciones:
  - Usuario y curso existen.
  - No duplicar matrícula.
- Códigos HTTP:
  - `201 Created`
  - `400 Bad Request`
  - `401 Unauthorized`
  - `404 Not Found`

### GET /enrollments/{userId}
- Descripción: Lista matrículas activas de un estudiante.
- Response 200:
```json
[
  {
    "id": "70d...",
    "cursoId": "61a...",
    "usuarioId": "63c...",
    "fechaMatricula": "2026-06-05T09:00:00Z",
    "estado": "Activo",
    "progreso": 12
  }
]
```
- Códigos HTTP:
  - `200 OK`
  - `401 Unauthorized`
  - `403 Forbidden`
  - `404 Not Found`
