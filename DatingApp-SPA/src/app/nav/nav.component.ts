import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public authService: AuthService, private alertifyService: AlertifyService,
              private router: Router) { }

  model: any = {};
  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => { this.alertifyService.success('logged in Successfuly'); },
      error => { this.alertifyService.error(error); },
      () => { this.router.navigate(['/members']); });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
  logout() {
    localStorage.removeItem('token');
    this.alertifyService.message('Logged out');
    this.router.navigate(['/home']);
  }

}
