import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarrinhoService } from 'src/app/carrinho/carrinho.service';
import { IProduto } from 'src/app/shared/models/produto';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  produto: IProduto;
  quantidade = 1;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService, private carrinhoService: CarrinhoService) { 
    this.bcService.set('@productDetails', ' ');
  }

  ngOnInit() {
    this.loadProduto();
  }

  addItemCarrinho() {
    this.carrinhoService.addItemCarrinho(this.produto, this.quantidade);
  }

  incrementQuantidade() {
    this.quantidade++;
  }

  decrementQuantidade() {
    if (this.quantidade > 1) {
      this.quantidade--;
    }
  }


  loadProduto() {
    this.shopService.getProduto(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(produto => {
      this.produto = produto;
      this.bcService.set('@productDetails', produto.nome);
    }, error => {
      console.log(error);
    });
  }
}
