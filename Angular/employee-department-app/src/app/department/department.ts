import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import {RouterLink} from '@angular/router'
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-department',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './department.html',
  styleUrl: './department.css',
})
export class Department implements OnInit {
  constructor(private fb: FormBuilder) {}

  deptForm!: FormGroup;
  output:string = '';

  ngOnInit(): void {
    this.formInit();
  }

  private formInit():void {
    this.deptForm = this.fb.group({
      deptName: ['', [Validators.required]],
      deptHead: ['', [Validators.required]],
      budget: [null, [Validators.required]],
    })
  }
  public onSubmitFormHandler():void {
    this.output = `
      <span><h1 class="font-bold">Department Name: <h1>${this.deptForm.value.deptName}</span>
      <span><h1 class="font-bold">Department Head: <h1>${this.deptForm.value.deptHead}</span>
      <span><h1 class="font-bold">Budget: <h1>${this.deptForm.value.budget}<span>`
    this.deptForm.reset();
  }
}
