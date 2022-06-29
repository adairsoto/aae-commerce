import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject} from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Carrinho, ICarrinho, ICarrinhoItem, ICarrinhoTotal } from '../shared/models/carrinho';
import { IProduto } from '../shared/models/produto';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  baseUrl = environment.apiUrl;
  private carrinhoSource = new BehaviorSubject<ICarrinho>(null);
  carrinho$ = this.carrinhoSource.asObservable();
  private carrinhoTotalSource = new BehaviorSubject<ICarrinhoTotal>(null);
  carrinhoTotal$ = this.carrinhoTotalSource.asObservable();

  constructor(private http: HttpClient) { }

  getCarrinho(id: string) {
    return this,this.http.get(this.baseUrl + 'carrinho?id=' + id)
    .pipe(
      map((carrinho: ICarrinho) => {
        this.carrinhoSource.next(carrinho);
        this.calculateTotals();
      })
    );
  }

  setCarrinho(carrinho: ICarrinho) {
    return this.http.post(this.baseUrl + 'carrinho', carrinho).subscribe((response: ICarrinho) => {
      this.carrinhoSource.next(response);
      this.calculateTotals();
    }, error => {
      console.log(error);
    });
  }

  getCurrentCarrinhoValue() {
    return this.carrinhoSource.value;
  }

  addItemCarrinho(item: IProduto, quantidade = 1) {
    const itemToAdd: ICarrinhoItem = this.mapProdutoItemToCarrinhoItem(item, quantidade);
    const carrinho = this.getCurrentCarrinhoValue() ?? this.createCarrinho();
    carrinho.itens = this.addOrUpdateItem(carrinho.itens, itemToAdd, quantidade);
    this.setCarrinho(carrinho);
  }

  private calculateTotals() {
    const carrinho = this.getCurrentCarrinhoValue();
    const entrega = 0;
    const subtotal = carrinho.itens.reduce((a, b) => (b.preco * b.quantidade) + a, 0);
    const total = subtotal + entrega;
    this.carrinhoTotalSource.next({entrega, total, subtotal});
  }

  private addOrUpdateItem(itens: ICarrinhoItem[], itemToAdd: ICarrinhoItem, quantidade: number): ICarrinhoItem[] {
    const index = itens.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantidade = quantidade;
      itens.push(itemToAdd);
    } else {
      itens[index].quantidade += quantidade;
    }
    return itens;
  }

  createCarrinho(): ICarrinho {
    const carrinho = new Carrinho();
    localStorage.setItem('carrinho_id', carrinho.id);
    return carrinho;
  }

  private mapProdutoItemToCarrinhoItem(item: IProduto, quantidade: number): ICarrinhoItem {
    return {
      id: item.id,
      produtoNome: item.nome,
      preco: item.preco,
      imagemUrl: item.imagemUrl,
      quantidade,
      marca: item.produtoMarca,
      categoria: item.produtoCategoria
    };
  }
}
