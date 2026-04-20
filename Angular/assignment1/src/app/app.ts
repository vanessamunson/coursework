import { Component, OnInit, ViewChild } from '@angular/core';
import { Home } from './home/home';

@Component({
  selector: 'app-root',
  imports: [Home],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  public message:string = '';
  backgroundColor:string = 'white';

  onMixChange(color:string):void {
    this.backgroundColor = color;
  }  

  ngOnInit(): void {
      this.message = 'I am from the App Component.'
  }
}
