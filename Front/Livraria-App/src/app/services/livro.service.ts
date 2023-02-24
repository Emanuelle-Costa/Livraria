import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Livro } from '../models/Livro';

@Injectable({
  providedIn: 'root'
})
export class LivroService {
  baseURL = 'https://localhost:7163/api/Livros';

  constructor(private http: HttpClient) { }

  public pegarLivroPorId(id: number): Observable<Livro>{
    return this.http.get<Livro>(`${this.baseURL}/${id}`);
  }

  public pegarLivros(): Observable<Livro[]>{
    return this.http.get<Livro[]>(this.baseURL);
  }

  public pegarLivrosPorTitulo(titulo: string): Observable<Livro[]>{
    return this.http.get<Livro[]>(`${this.baseURL}/${titulo}/titulo`);
  }

  public pegarLivrosPorAutor(autor: string): Observable<Livro[]>{
    return this.http.get<Livro[]>(`${this.baseURL}/${autor}/autor`);
  }

  public pegarLivrosPorEditora(editora: string): Observable<Livro[]>{
    return this.http.get<Livro[]>(`${this.baseURL}/${editora}/editora`);
  }

  public pegarLivrosPorEdicao(edicao: number): Observable<Livro[]>{
    return this.http.get<Livro[]>(`${this.baseURL}/${edicao}/edicao`);
  }

  public adicionar(livro: Livro): Observable<Livro>{
    return this.http.post<Livro>(this.baseURL, livro);
  }

  public atualizar(livro: Livro): Observable<Livro>{
    return this.http.put<Livro>(`${this.baseURL}/${livro.id}`, livro);
  }

  public deletar(id: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
