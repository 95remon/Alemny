import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthuserService } from 'src/Services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  validatingForm: FormGroup;
  isLoginError: boolean = false;

  constructor(private authSer: AuthuserService, private router: Router) {}

  ngOnInit(): void {}

  checkAccount(content, userName, password) {
    this.authSer.login(userName, password).subscribe(
      (data: any) => {
        localStorage.setItem('userToken', data.access_token);

        document.getElementById('close').click();

        this.isLoginError = true;

        console.log(localStorage.getItem('userToken'));

        this.authSer.GetUserInfo(userName, password).subscribe(
          (data) => {
            this.authSer.userInfo = data;
          },
          (err) => {
            alert(err);
          }
        );

        this.router.navigate(['/courses']);
      },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
      }
    );
  }
}
