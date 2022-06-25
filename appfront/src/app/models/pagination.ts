import { IProduto } from "./produto";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduto[];
}
