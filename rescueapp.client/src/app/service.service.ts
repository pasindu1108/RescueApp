import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  baseUrl: string = "https://localhost:7137";
  readonly APIUrl = this.baseUrl + "/api";
  constructor(private http: HttpClient) { }

  Insertuser(val: any) {
    return this.http.post(this.APIUrl + '/insertuser', val);
  }
}
