import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProdutoItemComponent } from './produto-item/produto-item.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProdutoItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
