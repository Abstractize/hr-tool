import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Employee } from '../../models/employee'

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  api : string = environment.APIEndpoint;
  controller: string = 'employee';
  url: string;
  constructor(private readonly http: HttpClient) {
    this.url =`${this.api}/${this.controller}`;
  }

  post(value: Employee){
    return this.http.post<Employee>(this.url,value);
  }
  get(id: number){
    return this.http.get<Employee>(`${this.url}/${id}`);
  }
  getAll(){
    return this.http.get<Employee[]>(this.url);
  }
  put(value: Employee){
    return this.http.put<Employee>(this.url,value);
  }
  delete(id: number){
    return this.http.delete<Employee>(`${this.url}/${id}`);
  }
}
