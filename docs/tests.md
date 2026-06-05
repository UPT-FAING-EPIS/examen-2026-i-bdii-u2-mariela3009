# 14. Pruebas

## Unitarias
Se utilizan:
- `xUnit`
- `Moq`

Áreas cubiertas:
- Servicios de `Courses`.
- Servicios de `Enrollments`.
- Autenticación y generación de JWT.

### Ejemplo de test unitario
- `backend/tests/OnlineCourses.UnitTests/CourseServiceTests.cs`
- Valida que `GetCourseById` devuelve detalle correcto.
- Valida que `CreateCourse` falla con datos nulos.

## Integración
Se utilizan:
- `TestContainers` para MongoDB.
- Pruebas con datos reales en contenedor.
- Verificación de repositorios y API.

### Cobertura mínima
- Controladores de cursos.
- Controladores de matrículas.
- Endpoints de autenticación.

## Estrategia
1. Unit tests en cada push.
2. Integration tests en pipeline de merge.
3. Validar que no hay regresiones de seguridad.
4. Ejecutar `dotnet test` y reportar resultados.
