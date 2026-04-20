import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-body',
  imports: [],
  templateUrl: './body.html',
  styleUrl: './body.css',
})
export class Body {
  @Output() _color = new EventEmitter<string>();

  public chooseColor(color:string):void {
    this._color.emit(color);
  }
}
