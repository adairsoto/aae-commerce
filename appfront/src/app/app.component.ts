import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduto } from './models/produto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'A&A e-commerce';
  produtos: IProduto[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/produtos?pageSize=20').subscribe((response: IPagination) => {
      this.produtos = response.data;
    }, error => {
      console.log(error);
    });
  }
}
