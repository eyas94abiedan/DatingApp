import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancel = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  toggele() {
    this.cancel.emit();
  }
  register() {
    this.authService.register(this.model).subscribe(
      success => { console.log('User Registered'); }
      , error => { console.log(error); });
  }
}
