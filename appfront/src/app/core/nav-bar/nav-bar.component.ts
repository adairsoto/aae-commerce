import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CarrinhoService } from 'src/app/carrinho/carrinho.service';
import { ICarrinho } from 'src/app/shared/models/carrinho';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  carrinho$: Observable<ICarrinho>;

  constructor(private carrinhoService: CarrinhoService) { }

  ngOnInit(): void {
    this.carrinho$ = this.carrinhoService.carrinho$;
  }

}
