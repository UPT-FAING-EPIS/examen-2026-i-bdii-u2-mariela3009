# 5. Seguridad

## Autenticación JWT
La API utiliza JWT para asegurar endpoints. El token se firma con una clave secreta en `appsettings.json`.

### Flujo
1. Usuario hace POST `/auth/login`.
2. Se valida correo y contraseña.
3. Se genera `accessToken` JWT con claims.
4. Se devuelve `refreshToken` para renovar sesión.

## Refresh Tokens
- El refresh token es un valor almacenado en la base de datos o caché.
- Se valida su vigencia antes de emitir un nuevo JWT.
- Permite revocación de sesiones.

## Role-Based Authorization
Roles definidos:
- `Admin`
- `Instructor`
- `Estudiante`

Ejemplo de política:
- `Admin` puede crear y eliminar cursos.
- `Instructor` puede editar sus cursos.
- `Estudiante` puede ver cursos y matricularse.

## Policies
Políticas implementadas:
- `RequireAdminRole`
- `RequireInstructorOrAdmin`
- `RequireOwnerOrAdmin` para recursos de matrícula.

## Password Hashing
Se utiliza BCrypt para proteger contraseñas.

```csharp
var hash = BCrypt.Net.BCrypt.HashPassword(password);
var valid = BCrypt.Net.BCrypt.Verify(password, hash);
```

## Protección CORS
La configuración CORS restringe orígenes al frontend del proyecto:
- `http://localhost:4200`
- `https://onlinecourses.example.com`

## Rate Limiting
La API implementa límites básicos por IP para proteger endpoints críticos.
- 100 requests / 1 minuto por IP.
- Límite más estricto en `/auth/login`.

## Validación de entrada
Se usan `FluentValidation` o validadores manuales en DTOs.
- Campos requeridos.
- Formato de correo.
- Longitudes máximas.

## Manejo global de excepciones
Se utiliza middleware global para retorno estándar:
- `400 Bad Request`
- `401 Unauthorized`
- `403 Forbidden`
- `404 Not Found`
- `500 Internal Server Error`

Ejemplo de respuesta de error:
```json
{
  "timestamp": "2026-06-05T10:00:00Z",
  "status": 401,
  "error": "Unauthorized",
  "message": "Credenciales inválidas",
  "path": "/auth/login"
}
```
