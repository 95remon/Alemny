import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthuserService } from 'src/Services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Iuser } from 'src/Interfaces/iuser';

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

        this.authSer.GetUserInfo(userName, password).subscribe(
          (data) => {
            this.authSer.userInfo = data as Iuser;
            console.log('User Info ' + this.authSer.userInfo)
            localStorage.setItem('userId' , data.Id);
            console.log('User ID : ' +  localStorage.getItem('userId'))
            localStorage.setItem('userType' , data.Type);

            localStorage.setItem('user' , JSON.stringify(data));
            let s: Iuser=JSON.parse(localStorage.getItem('user'));
            console.log(s);

            this.router.navigate(['/courses']);
          },
          
          (err) => {
            alert(err);
          }
        );

        
      },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
      }
    );
  }
}
