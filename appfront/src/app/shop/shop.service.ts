import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { ICateg } from '../shared/models/categ';
import { IMarca } from '../shared/models/marca';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProdutos(marcaId?: number, categId?: number, sort?: string)
  {
    let params = new HttpParams();

    if (marcaId) {
      params = params.append('marcaId', marcaId.toString());
    }

    if (categId) {
      params = params.append('categId', categId.toString());
    }

    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<IPagination>(this.baseUrl + 'produtos', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getMarcas(){
    return this.http.get<IMarca[]>(this.baseUrl + 'produtos/marcas')
  }

  getCateg(){
    return this.http.get<ICateg[]>(this.baseUrl + 'produtos/categ')
  }
}
