# 6. Frontend Angular

## Estructura de carpetas

- `frontend/src/app/auth` - Login y registro.
- `frontend/src/app/courses` - Listado de cursos, detalles, formulario.
- `frontend/src/app/enrollments` - Matriculas y progreso.
- `frontend/src/app/dashboard` - Panel principal.
- `frontend/src/app/notifications` - Alertas y mensajes.
- `frontend/src/app/shared` - Componentes reutilizables, modelos e interfaces.

## Routing
El routing se organiza en rutas protegidas y públicas.

- `/login`
- `/register`
- `/courses`
- `/courses/:id`
- `/enrollments`
- `/dashboard`
- `/notifications`

## Servicios
- `AuthService` - login, register, refreshToken.
- `CourseService` - CRUD de cursos.
- `EnrollmentService` - matrículas.
- `NotificationService` - notificaciones.
- `ApiService` - client HTTP base y token interceptor.

## Guards
- `AuthGuard` - protege rutas autenticadas.
- `RoleGuard` - protege por rol específico.

## Componentes
- `LoginComponent`
- `RegisterComponent`
- `CourseListComponent`
- `CourseDetailComponent`
- `CourseFormComponent`
- `EnrollmentListComponent`
- `DashboardComponent`
- `NotificationsComponent`

## Interfaces TypeScript
Ejemplo:
```ts
export interface Course {
  id: string;
  titulo: string;
  descripcion: string;
  categoria: string;
  nivel: string;
  duracion: number;
  instructor: string;
  precio: number;
  temario: string[];
  fechaCreacion: string;
}
```

## Consumo de API
Ejemplo `CourseService`:
```ts
getCourses(params?: any) {
  return this.http.get<Course[]>(`${this.baseUrl}/courses`, { params });
}
```

## Buenas prácticas
- Uso de `HttpInterceptor` para autorización.
- Módulos con lazy loading.
- Servicios inyectables en root.
- Manejo de errores centralizado.
