import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { CourseModel } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private readonly http = inject(HttpClient);
  private readonly _courses = signal<CourseModel[]>([]);
  readonly courses = this._courses.asReadonly();

  private readonly apiUrl = 'http://localhost:5000/api/courses';

  loadCourses(categoria?: string, nivel?: string): void {
    let params = new HttpParams();

    if (categoria) {
      params = params.set('categoria', categoria);
    }

    if (nivel) {
      params = params.set('nivel', nivel);
    }

    this.http
      .get<CourseModel[]>(this.apiUrl, { params })
      .subscribe({
        next: (courses) => this._courses.set(courses ?? []),
        error: () => this._courses.set([])
      });
  }
}
