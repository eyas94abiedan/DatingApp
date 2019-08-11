import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerToggeler = false;

  constructor() { }

  ngOnInit() {
  }

  toggleRegister() {
    this.registerToggeler = !this.registerToggeler;
  }

}
