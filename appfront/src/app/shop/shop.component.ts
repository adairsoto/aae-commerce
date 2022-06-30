import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ICateg } from '../shared/models/categ';
import { IMarca } from '../shared/models/marca';
import { IProduto } from '../shared/models/produto';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  produtos: IProduto[];
  marcas: IMarca[];
  categ: ICateg[];
  shopParams = new ShopParams();
  totalCount: number;

  sortOptions = [
    {nome: 'A - Z', value: 'nome'},
    {nome: 'Preço: menor a maior', value: 'precoAsc'},
    {nome: 'Preço: maior a menor', value: 'precoDesc'},
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProdutos();
    this.getCateg();
    this.getMarcas();
  }
 
  getProdutos() {
    this.shopService.getProdutos(this.shopParams).subscribe(response => {
      this.produtos = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getMarcas(){
    this.shopService.getMarcas().subscribe(response => {
      this.marcas = [{id: 0, nome: 'Todas'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  getCateg(){
    this.shopService.getCateg().subscribe(response => {
      this.categ = [{id: 0, nome: 'Todas'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  marcaSelec(marcaId: number){
    this.shopParams.marcaId = marcaId;
    this.shopParams.pageNumber = 1;
    this.getProdutos();
  }

  categSelec(categId: number){
    this.shopParams.categId = categId;
    this.shopParams.pageNumber = 1;
    this.getProdutos();
  }

  sortSelec(sort: string){
    this.shopParams.sort = sort;
    this.getProdutos();
  }

  pageChanged(event: any){
    if (this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProdutos();
    }
    
  }

  Search() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProdutos();
  }

  Reset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProdutos();
  }
}
