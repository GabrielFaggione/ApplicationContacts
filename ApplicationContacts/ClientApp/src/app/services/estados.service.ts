import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Cidade } from '../models/cidade';
import { Estado } from '../models/estado';

@Injectable({
  providedIn: 'root'
})
export class EstadosService {

  baseUrl = `${environment.mainUrlAPI}/Estado`

  constructor(private http : HttpClient) { }
  
  getAll() : Observable<Estado[]> {
    return this.http.get<Estado[]>(`${this.baseUrl}`);
  }

  getCidades() : Observable<Cidade[]> {
    return this.http.get<Cidade[]>(`${this.baseUrl}/Cidades`);
  }
  
}
