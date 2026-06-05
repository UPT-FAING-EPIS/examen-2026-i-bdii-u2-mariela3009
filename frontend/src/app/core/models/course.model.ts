export interface CourseModel {
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
