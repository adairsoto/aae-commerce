import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduto } from 'src/app/shared/models/produto';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  produto: IProduto;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.loadProduto();
  }

  loadProduto() {
    this.shopService.getProduto(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(produto => {
      this.produto = produto;
    }, error => {
      console.log(error);
    });
  }
}
