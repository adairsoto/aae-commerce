import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { CarrinhoService } from 'src/app/carrinho/carrinho.service';
import { ICarrinho } from 'src/app/shared/models/carrinho';
import { IUser } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  carrinho$: Observable<ICarrinho>;
  currentUser$: Observable<IUser>;

  constructor(private carrinhoService: CarrinhoService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.carrinho$ = this.carrinhoService.carrinho$;
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout() {
    this.accountService.logout();
  }

}
