import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { CompanyModel } from '../Models/company-model.model';
import { GetListModel } from '../Models/get-list-model.model';



@Injectable({
  providedIn: 'root'
})
export class CompanyDataService {
  getList: GetListModel = new GetListModel();
  basePath = environment.apiUrl;
  apiVersion = environment.version;
  userString: any;

  constructor(private httpClient: HttpClient) { }


  public getAllcompanyList() {
    let httpOptions = this.getHeaders();
    return this.httpClient.post(this.basePath + this.apiVersion + `Company/GetAllCompaniesList`,  this.getList, httpOptions);
  }

  public getCompanyById(id: number){
    let httpOptions = this.getHeaders();
    return this.httpClient.get(this.basePath + this.apiVersion + `Company/GetCompanyById/${id}`, httpOptions);
  }

  public getCompanyByIsIn(isin: string){
    let httpOptions = this.getHeaders();
    return this.httpClient.get(this.basePath + this.apiVersion + `Company/GetCompanyByIsin/${isin}`, httpOptions);
  }

  
  public updateCompany(Company: CompanyModel) {
    let httpOptions = this.getHeaders();
    return this.httpClient.put(this.basePath + this.apiVersion + `Company/UpdateCompany`,  Company, httpOptions);
  }

  public deleteCompanyById(id: number){
    let httpOptions = this.getHeaders();
    return this.httpClient.delete(this.basePath + this.apiVersion + `Company/DeleteCompany/${id}`, httpOptions);
  }


  getHeaders(withoutType = false) {
    const token = this.getToken();
    const headersConfig: { [key: string]: string } = {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT',
    };

    if (token) {
      headersConfig['Authorization'] = `Bearer ${token}`;
    }

    const httpOptions = {
      headers: new HttpHeaders(headersConfig)
    };
    
    return httpOptions;
  }

  getToken() {  
    this.userString = JSON.parse(localStorage.getItem('userLoginDetails'));
    if (this.userString) {
      const user = this.userString;
      if (user.accessToken) {
        return user.accessToken;
      }
    }
    return '';
  }


}
