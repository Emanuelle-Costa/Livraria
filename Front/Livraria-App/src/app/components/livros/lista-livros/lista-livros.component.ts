import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Livro } from 'src/app/models/Livro';
import { LivroService } from 'src/app/services/livro.service';

@Component({
  selector: 'app-lista-livros',
  templateUrl: './lista-livros.component.html',
  styleUrls: ['./lista-livros.component.scss']
})
export class ListaLivrosComponent {
  constructor(private livroService: LivroService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
    ){ }


    modalRef = {} as BsModalRef;
    livroTitulo = '';
    public livros: Livro[] = [];
    public livrosFiltrados: Livro[] = [];

    private _filtroLista: string = '';

    public get filtroLista(){
      return this._filtroLista
    }

    public set filtroLista(value: string){
      this._filtroLista = value;
      this.livrosFiltrados = this.filtroLista ? this.filtrarLivros(this.filtroLista) : this.livros;
    }

    public filtrarLivros(filtrarPorTitulo : string): Livro[] {
      filtrarPorTitulo = filtrarPorTitulo.toLocaleLowerCase();
      return this.livros.filter(
        (livro : any) => livro.titulo.toLocaleLowerCase().indexOf(filtrarPorTitulo) !== -1
        )
      }


      public ngOnInit(): void {
        this.spinner.show();
        this.getLivros();

      }

      public getLivros(): void{
        this.livroService.getLivros().subscribe({
          next: (livros: Livro[]) => {
            this.livros = livros;
            this.livrosFiltrados = this.livros;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao Carregar os Livros', 'Error!');
          },
          complete: () => this.spinner.hide()
        });

      }

      openModal(template: TemplateRef<any>): void{
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      confirmar(): void {
        this.modalRef.hide();
        this.toastr.success("Livro deletado com sucesso!","Deletado", );
      }

      cancelar(): void {
        this.modalRef.hide();
      }

      editarLivro(id: number): void{
        this.router.navigate([`livros/detalhe/${id}`]);
      }



    }
