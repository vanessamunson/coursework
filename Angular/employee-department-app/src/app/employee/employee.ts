import { Component, WritableSignal, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {RouterLink} from '@angular/router'

@Component({
  selector: 'app-employee',
  imports: [FormsModule, RouterLink],
  templateUrl: './employee.html',
  styleUrl: './employee.css',
})
export class Employee {
  name:WritableSignal<string> = signal<string>('');
  age:WritableSignal<number|null> = signal<number|null>(null);
  email:WritableSignal<string> = signal<string>('');

  output:string = '';

  submitForm():void {
    this.output = `
      <span><h1 class="font-bold">Name: <h1>${this.name()}</span>
      <span><h1 class="font-bold">Age: <h1>${this.age() ? this.age() : ''}</span>
      <span><h1 class="font-bold">Email: <h1>${this.email()}<span>
    `
    this.name.set('');
    this.age.set(null);
    this.email.set('');
  }
}
