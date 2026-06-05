import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path: '',
    loadComponent: () => import('./features/courses/course-list.component').then(m => m.CourseListComponent)
  },
  {
    path: '**',
    redirectTo: ''
  }
];
