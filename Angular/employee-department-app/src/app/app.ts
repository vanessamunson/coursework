import { Component, signal } from '@angular/core';
import { Employee } from './employee/employee';
import { Department } from './department/department';

@Component({
  selector: 'app-root',
  imports: [Employee, Department],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('assignment2');
}
