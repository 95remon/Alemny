import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { TokenParam } from 'src/Interfaces/token-param';
import { IAccount } from 'src/Interfaces/iaccount';


@Injectable({
  providedIn: 'root'
})
export class AuthuserService {

  constructor(private httpClient: HttpClient) { }

  registerUser(user:IAccount)
  {
    const httpOptions =  new HttpHeaders({
      'Content-Type': 'application/json',
       'Accept': ' /'
        });
    return this.httpClient.post(`${environment.ApiURl}/Account`, user, { headers: httpOptions });
  }

  /*registerUser(user: User,roles : string[]) {
    const body = {
      Name: user.Name,
      Email: user.Email,
      Password: user.Password,
      ConfirmPassword: user.ConfirmPassword,
      MobileNumber: user.MobileNumber,
      Address : user.Address, 
      Roles : roles
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    //return this.HttpClient.post(this.rootUrl + '/api/User/Register', body,{headers : reqHeader});
  }*/

  login(username: string, password: string): Observable<TokenParam> {
    var headerForTokenApi = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    });
  
    var data = `grant_type=password&username=${username}&password=${password}`;
  
    return this.httpClient.post<TokenParam>(environment.ApiLogin, data, {
      headers: headerForTokenApi,
    });
  }


  getRole():Observable<string>{
    var headerForTokenApi = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
      'Authorization': `bearer ${localStorage.getItem('userToken')}`
      
    });
  
    return this.httpClient.get<string>(`${environment.ApiURl}/Role`, {headers: headerForTokenApi})
  }


}








