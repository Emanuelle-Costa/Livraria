import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.scss']
})
export class LivrosComponent implements OnInit {

  public livros: any = [];
  filtroLista: string = '';

  constructor(private http: HttpClient){ }

  ngOnInit(): void {
    this.getLivros();
  }

  public getLivros(): void{
    this.http.get('https://localhost:7163/api/Livros').subscribe(
      response => this.livros = response,
      error => console.log(error)
    );

  }
}
