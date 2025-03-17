import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  basePath = environment.apiUrl;
    apiVersion = environment.version;

    password : string = 'dev@Full$pqrs';
    userName : string = 'Developer123';
  
  constructor(private httpClient: HttpClient) { }

  public getUserLogin() {
    return this.httpClient.get(this.basePath + this.apiVersion + `User/UserLogin?userName=${this.userName}&password=${this.password}`);
  }
}
