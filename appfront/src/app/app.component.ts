import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from './carrinho/carrinho.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'A&A e-commerce';

  constructor(private carrinhoService: CarrinhoService) {}

  ngOnInit(): void {
    const carrinhoId = localStorage.getItem('carrinho_id');
    if (carrinhoId) {
      this.carrinhoService.getCarrinho(carrinhoId).subscribe(() => {
        console.log('initialised carrinho');
      }, error => {
        console.log(error);
      });
    }
  }
}
