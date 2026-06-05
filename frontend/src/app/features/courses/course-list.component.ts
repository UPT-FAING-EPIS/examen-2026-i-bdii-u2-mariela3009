import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../core/services/course.service';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {
  readonly courses = this.courseService.courses;

  constructor(private readonly courseService: CourseService) {}

  ngOnInit(): void {
    this.courseService.loadCourses();
  }
}
