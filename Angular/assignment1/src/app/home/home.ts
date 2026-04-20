import { Component, OnChanges, OnInit, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { Body } from '../body/body';

@Component({
  selector: 'app-home',
  imports: [Body],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit, OnChanges{

  @Output() _mixedColor = new EventEmitter<string>();
  _color: string = '';
  _bodyColor: string = '';

  public chooseColor(color:string):void {
    this._color = color;
    console.log(`Home chose color: ${color}`);
    this.mixColors();
  }

  public onBodyColorChange(color:string):void {
    this._bodyColor = color;
    console.log(`Body chose color: ${color}`);
    this.mixColors();
  }

  public mixColors():void {
    if (this._color === this._bodyColor) {
      this._mixedColor.emit(this._color);
    }
    if (this._color == 'red') {
      if (this._bodyColor == 'yellow') {
        this._mixedColor.emit('orange');
      } else if (this._bodyColor == 'blue') {
        this._mixedColor.emit('purple');
      }
    } else if (this._color == 'yellow') {
      if (this._bodyColor == 'red') {
        this._mixedColor.emit('orange');
      } else if (this._bodyColor == 'blue') {
        this._mixedColor.emit('green');
      }
    } else if (this._color == 'blue') {
      if (this._bodyColor == 'red') {
        this._mixedColor.emit('purple');
      } else if (this._bodyColor == 'yellow') {
        this._mixedColor.emit('green'); 
      }
    } else {
      this._mixedColor.emit('white');
    }
  }

  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges): void {}
}
