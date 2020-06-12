import { Component, OnInit } from '@angular/core';
import { IAccount } from 'src/Interfaces/iaccount';
import { FormGroup, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import { AuthuserService } from 'src/Services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})

export class SignUpComponent implements OnInit {
  account: IAccount;
  LoginForm: FormGroup;
  constructor(
    private user: AuthuserService,
    private route: Router,
    private FB: FormBuilder
  ) {
    this.account = {
      Name: '',
      UserName:'',
      Email:'',
      Password: '',
      ConfirmPassword: '',
      Address: '',
      PhoneNumber: '',
      Gender: '',

    };
  }
  ngOnInit(): void {
    this.LoginForm = this.FB.group({
      Name: ['', [Validators.required, Validators.minLength(3)]],
      UserName: ['', [Validators.required, Validators.minLength(3)]],
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      ConfirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      Address: ['', [Validators.required, Validators.minLength(3)]],
      PhoneNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      Gender: ['', [Validators.required, Validators.minLength(3)]],
    });
  }

  reg() {
    this.user.registerUser(this.account).subscribe(
      (data: any) => {
        console.log(data);
      },
      (err) => console.log(err)
    );
  }
}
