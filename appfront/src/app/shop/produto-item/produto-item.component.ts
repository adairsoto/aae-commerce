import { Component, Input, OnInit } from '@angular/core';
import { CarrinhoService } from 'src/app/carrinho/carrinho.service';
import { IProduto } from 'src/app/shared/models/produto';

@Component({
  selector: 'app-produto-item',
  templateUrl: './produto-item.component.html',
  styleUrls: ['./produto-item.component.scss']
})
export class ProdutoItemComponent implements OnInit {
  @Input() produto: IProduto;

  constructor(private carrinhoService: CarrinhoService) { }

  ngOnInit(): void {
  }

  addItemCarrinho() {
    this.carrinhoService.addItemCarrinho(this.produto);
  }

}
