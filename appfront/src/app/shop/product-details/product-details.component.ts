import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService) { 
    this.bcService.set('@productDetails', ' ');
  }

  ngOnInit() {
    this.loadProduto();
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
