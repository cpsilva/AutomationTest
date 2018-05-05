import { Component, OnInit } from '@angular/core';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-item05',
  templateUrl: './item05.component.html'
})
export class Item05Component implements AfterViewInit {

  constructor() { }

  ngAfterViewInit(): void {
    this.callAlerts();
  }

  callAlerts() {
    alert("Hello! I am an alert box!");
    alert("Hello! I am an alert box!");
    alert("Hello! I am an alert box!");
    alert("Hello! I am an alert box!");
    alert("Hello! I am an alert box!");
  }
}
