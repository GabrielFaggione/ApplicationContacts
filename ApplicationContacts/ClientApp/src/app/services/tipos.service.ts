import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';
import { TipoClienteXEndereco } from '../models/tipo-cliente-xendereco';
import { TipoClienteXtelefone } from '../models/tipo-cliente-xtelefone';
import { TipoRedeSocial } from '../models/tipo-rede-social';

@Injectable({
  providedIn: 'root'
})
export class TiposService {

  baseUrl = `${environment.mainUrlAPI}/Tipo`

  constructor(private http : HttpClient) { }
  
  getTipoClienteXEndereco() : Observable<TipoClienteXEndereco[]> {
    return this.http.get<TipoClienteXEndereco[]>(`${this.baseUrl}/clienteXendereco`);
  }

  getTipoClienteXTelefone() : Observable<TipoClienteXtelefone[]> {
    return this.http.get<TipoClienteXtelefone[]>(`${this.baseUrl}/clienteXtelefone`);
  }
  
  getTipoRedeSocial() : Observable<TipoRedeSocial[]> {
    return this.http.get<TipoRedeSocial[]>(`${this.baseUrl}/redes-sociais`);
  }

}
