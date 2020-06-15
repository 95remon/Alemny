import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import { AuthuserService } from 'src/Services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';



@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  

  validatingForm: FormGroup;
  isLoginError :boolean = false

  constructor(private  authSer : AuthuserService) { }

  ngOnInit(): void {
  }

  checkAccount(content ,userName,password){

    this.authSer.login(userName,password).subscribe((data : any)=>{

      localStorage.setItem('userToken',data.access_token);

      document.getElementById("close").click();

      this.isLoginError = true;

      console.log( localStorage.getItem('userToken'));

    },
    (err : HttpErrorResponse)=>{
      this.isLoginError = true;
    });

  }


}
