# 1. Análisis del Sistema

## Descripción general del sistema
La Plataforma de Matrícula de Cursos Online es una solución empresarial para la gestión integral de cursos, usuarios y matrículas.
Permite a estudiantes inscribirse en cursos, revisar su progreso y recibir notificaciones, mientras que administradores e instructores gestionan catálogos, usuarios y reportes.

## Problema que resuelve
- Elimina procesos manuales de inscripción.
- Centraliza el catálogo de cursos y el seguimiento de progreso.
- Facilita la administración de instructores, estudiantes y matrículas.
- Brinda seguridad, trazabilidad e historial de actividades.

## Objetivos generales
- Desarrollar una plataforma escalable para cursos online.
- Garantizar una experiencia segura y responsiva.
- Automatizar despliegues y provisión de infraestructura.
- Integrar control de acceso y monitoreo en la nube.

## Objetivos específicos
- Implementar autenticación y autorización JWT.
- Desarrollar API RESTful para cursos, matrículas y usuarios.
- Diseñar frontend Angular modular.
- Utilizar MongoDB Atlas como base de datos NoSQL.
- Desplegar infraestructura en AWS con Terraform.
- Configurar pipelines CI/CD en GitHub Actions.

## Alcance
- Registro y login de usuarios.
- Gestión de cursos y temarios.
- Inscripción y seguimiento de matrículas.
- Notificaciones y administración de roles.
- Entorno de despliegue cloud en AWS.
- Documentación técnica y pruebas automatizadas.

## Restricciones
- Base de datos NoSQL (MongoDB) obligatoria.
- Frontend construido con Angular.
- Backend construido con ASP.NET Core Web API.
- Señalado uso de AWS y Terraform.

## Supuestos
- Los usuarios pueden ser estudiante, instructor o administrador.
- MongoDB Atlas se utiliza como servicio administrado.
- AWS se usa para la capa de aplicación y balanceo.
- No se incluye pasarela de pago real en esta versión.

## Stakeholders
- Estudiantes.
- Instructores.
- Administradores de plataforma.
- Equipo DevOps.
- Equipo de QA.

## Requerimientos funcionales
1. RF001 - Registro de nuevos usuarios.
2. RF002 - Login con JWT.
3. RF003 - CRUD de cursos.
4. RF004 - Inscripción en cursos.
5. RF005 - Consulta de matrículas por usuario.
6. RF006 - Notificaciones a estudiantes.
7. RF007 - Gestión de roles y permisos.
8. RF008 - Seed inicial de datos.

## Requerimientos no funcionales
1. RNF001 - Alta disponibilidad.
2. RNF002 - Escalabilidad horizontal de API.
3. RNF003 - Seguridad en transport layer (HTTPS).
4. RNF004 - DevOps con CI/CD.
5. RNF005 - Despliegue automatizado con IaC.
6. RNF006 - Tolerancia a fallos y monitoreo.

## Casos de uso
1. UC001 - Estudiante se registra y visualiza cursos.
2. UC002 - Administrador crea un curso.
3. UC003 - Estudiante se matricula en un curso.
4. UC004 - Instructor revisa progreso de estudiantes.
5. UC005 - Usuario recibe notificación de avance.

## Historias de usuario
- Como estudiante, quiero registrarme para ver cursos disponibles.
- Como estudiante, quiero matricularme en un curso para comenzar mi aprendizaje.
- Como administrador, quiero crear y actualizar cursos.
- Como instructor, quiero revisar los estudiantes inscritos.
- Como administrador, quiero auditar acceso y matrículas.

## Criterios de aceptación
- El registro se realiza con correo único.
- El login devuelve JWT y refresh token.
- Un curso nuevo puede ser creado con título, descripción y categoría.
- Un estudiante puede consultar sus matrículas por `userId`.
- La API rechaza accesos no autorizados con 401/403.
