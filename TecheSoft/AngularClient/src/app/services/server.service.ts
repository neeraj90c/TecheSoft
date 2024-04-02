// server.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { LoginRequest } from '../interface/login.interface';

@Injectable({
    providedIn: 'root'
})
export class ServerService {

    constructor(private http: HttpClient) { }


    getGroupCodeDetails(data: { bpCode: string }) : Observable<any> {
        return this.http.post(`${environment.apiUrl}/GetGroupCodeDetails`, data);
    }
    login(loginData: LoginRequest): Observable<any> {
        return this.http.post(`${environment.apiUrl}/ValidateUserLogin`, loginData);
      }


    // Add more methods as required for your application
}
