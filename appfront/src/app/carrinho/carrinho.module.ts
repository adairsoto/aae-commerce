import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoComponent } from './carrinho.component';
import { CarrinhoRoutingModule } from './carrinho-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    CarrinhoComponent
  ],
  imports: [
    CommonModule,
    CarrinhoRoutingModule,
    SharedModule
  ]
})
export class CarrinhoModule { }
