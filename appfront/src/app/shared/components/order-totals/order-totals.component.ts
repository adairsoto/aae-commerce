import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CarrinhoService } from 'src/app/carrinho/carrinho.service';
import { ICarrinhoTotal } from '../../models/carrinho';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent implements OnInit {
  carrinhoTotal$: Observable<ICarrinhoTotal>;

  constructor(private carrinhoService: CarrinhoService ) { }

  ngOnInit(): void {
    this.carrinhoTotal$ = this.carrinhoService.carrinhoTotal$;
  }

}
