import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoComponent } from './carrinho.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component: CarrinhoComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class CarrinhoRoutingModule { }
