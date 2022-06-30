import { v4 as uuidv4} from 'uuid';

export interface ICarrinhoItem {
    id: number;
    produtoNome: string;
    preco: number;
    quantidade: number;
    imagemUrl: string;
    marca: string;
    categoria: string;
}

export interface ICarrinho {
    id: string;
    itens: ICarrinhoItem[];
}

export class Carrinho implements ICarrinho {
    id = uuidv4();
    itens: ICarrinhoItem[] = [];
}

export interface ICarrinhoTotal {
    entrega: number 
    subtotal: number
    total: number
}

