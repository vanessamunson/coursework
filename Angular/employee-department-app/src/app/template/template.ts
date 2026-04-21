import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-template',
  imports: [FormsModule, CommonModule],
  templateUrl: './template.html',
  styleUrl: './template.css',
})
export class Template {
  userName: string = 'Arkyn Wolfsen'
}
