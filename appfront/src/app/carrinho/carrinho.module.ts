import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoComponent } from './carrinho.component';
import { CarrinhoRoutingModule } from './carrinho-routing.module';



@NgModule({
  declarations: [
    CarrinhoComponent
  ],
  imports: [
    CommonModule,
    CarrinhoRoutingModule
  ]
})
export class CarrinhoModule { }
