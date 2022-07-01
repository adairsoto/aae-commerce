import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { CarrinhoService } from './carrinho/carrinho.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'A&A e-commerce';

  constructor(private carrinhoService: CarrinhoService, private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log('loaded user');
    }, error => {
      console.log(error);
    })
  }

  loadBasket() {
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


