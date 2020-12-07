import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuarios } from '../models/Usuarios'

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  baseUrl = `${environment.baseUrl}api/usuario`;

constructor(private http: HttpClient) { }

getAll(): Observable<Usuarios[]>
{
  return this.http.get<Usuarios[]>(`${this.baseUrl}`);

}

getById(id: number): Observable<Usuarios>
{
  return this.http.get<Usuarios>(`${this.baseUrl}/${id}`);
}

}
