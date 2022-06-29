import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICarrinho } from '../shared/models/carrinho';
import { CarrinhoService } from './carrinho.service';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.scss']
})
export class CarrinhoComponent implements OnInit {
  carrinho$: Observable<ICarrinho>;

  constructor(private carrinhoService: CarrinhoService) { }

  ngOnInit(): void {
    this.carrinho$ = this.carrinhoService.carrinho$;
  }

}
