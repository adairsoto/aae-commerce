import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { ICateg } from '../shared/models/categ';
import { IMarca } from '../shared/models/marca';
import { IPagination } from '../shared/models/pagination';
import { IProduto } from '../shared/models/produto';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProdutos(shopParams: ShopParams)
  {
    let params = new HttpParams();

    if (shopParams.marcaId !== 0) {
      params = params.append('marcaId', shopParams.marcaId.toString());
    }

    if (shopParams.categId !== 0) {
      params = params.append('categId', shopParams.categId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }
    
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageIndex', shopParams.pageSize.toString());
    
    return this.http.get<IPagination>(this.baseUrl + 'produtos', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getProduto(id: number) {
    return this.http.get<IProduto>(this.baseUrl + 'produtos/' + id);
  }

  getMarcas(){
    return this.http.get<IMarca[]>(this.baseUrl + 'produtos/marcas')
  }

  getCateg(){
    return this.http.get<ICateg[]>(this.baseUrl + 'produtos/categ')
  }
}
