import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/internal/operators/map';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';
import { PaginatedResult, Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl = `${environment.mainUrlAPI}/Cliente`

  constructor(private http : HttpClient) { }
  
  getAll() : Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.baseUrl}/todos-usuarios`);
  }

  getByPagination(page?: number, itemsPerPage?: number, filtro?: string) : Observable<PaginatedResult<Cliente[]>> {
    const paginatedResult: PaginatedResult<Cliente[]> = new PaginatedResult<Cliente[]>();

    console.log(`page solicitada = ${page}`);

    let params = new HttpParams();
    if (page != null && itemsPerPage != null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
      params = params.append('Filtro', filtro);
    }

    return this.http.get<Cliente[]>(this.baseUrl, { observe: 'response' , params} )
      .pipe(
        map(response => {
          console.log(response);
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }

  getClienteInfo(clienteId:string) : Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}/ById/${clienteId}`);
  }

  post(cliente: Cliente) {
    return this.http.post(this.baseUrl, cliente);
  }

  put(cliente: Cliente) {
    return this.http.put(this.baseUrl, cliente);
  }

}
