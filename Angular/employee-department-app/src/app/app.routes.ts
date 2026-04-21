import { Routes } from '@angular/router';
import { Employee } from './employee/employee';
import { Department } from './department/department';

export const routes: Routes = [
    {path:'employee', component: Employee},
    {path: 'department', component: Department},
];
