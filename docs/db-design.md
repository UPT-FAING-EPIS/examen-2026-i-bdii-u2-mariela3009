# 3. Diseño de la Base de Datos

## Colecciones MongoDB

### Usuarios

```json
{
  "_id": "ObjectId",
  "Nombre": "string",
  "Correo": "string",
  "ContraseñaHash": "string",
  "Rol": "string",
  "FechaRegistro": "date"
}
```

### Cursos

```json
{
  "_id": "ObjectId",
  "Titulo": "string",
  "Descripcion": "string",
  "Categoria": "string",
  "Nivel": "string",
  "Duracion": "int",
  "Instructor": "string",
  "Precio": "decimal",
  "Temario": ["string"],
  "FechaCreacion": "date"
}
```

### Matriculas

```json
{
  "_id": "ObjectId",
  "UsuarioId": "ObjectId",
  "CursoId": "ObjectId",
  "FechaMatricula": "date",
  "Estado": "string",
  "Progreso": "int"
}
```

### Notificaciones

```json
{
  "_id": "ObjectId",
  "UsuarioId": "ObjectId",
  "Tipo": "string",
  "Mensaje": "string",
  "Fecha": "date"
}
```

## Relaciones
- `Matriculas.UsuarioId` referencia a `Usuarios._id`.
- `Matriculas.CursoId` referencia a `Cursos._id`.
- `Notificaciones.UsuarioId` referencia a `Usuarios._id`.

## Índices recomendados
- `Usuarios.Correo` único para login y búsqueda.
- `Cursos.Categoria`, `Cursos.Nivel` para filtros.
- `Matriculas.UsuarioId`, `Matriculas.CursoId` para consultas.
- `Notificaciones.UsuarioId` y `Notificaciones.Fecha`.

## Estrategias de particionamiento
- Uso de MongoDB Atlas con shard key en colecciones de alto tráfico.
- `Matriculas.UsuarioId` como candidate shard key para escalado por usuario.
- `Notificaciones.UsuarioId` para consultas por usuario.

## Estrategias de optimización
- Lecturas comunes con índices compuestos: `{UsuarioId:1, Estado:1}`.
- Datos de curso `Temario` embebido cuando el temario es pequeño.
- Usar agregaciones en MongoDB para dashboard y reportes.
- Reservar `ObjectId` pre-generados cuando se necesita auditabilidad.
