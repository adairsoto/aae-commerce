import { Component, OnInit } from '@angular/core';
import { ICateg } from '../shared/models/categ';
import { IMarca } from '../shared/models/marca';
import { IProduto } from '../shared/models/produto';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  produtos: IProduto[];
  marcas: IMarca[];
  categ: ICateg[];
  marcaIdSelec = 0;
  categIdSelec = 0;
  sortSelected = 'nome';
  sortOptions = [
    {nome: 'Ordem alfabética', value: 'nome'},
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
    this.shopService.getProdutos(this.marcaIdSelec, this.categIdSelec, this.sortSelected).subscribe(response => {
      this.produtos = response.data;
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
    this.marcaIdSelec = marcaId;
    this.getProdutos();
  }

  categSelec(categId: number){
    this.categIdSelec = categId;
    this.getProdutos();
  }

  sortSelec(sort: string){
    this.sortSelected = sort;
    this.getProdutos();
  }
}
