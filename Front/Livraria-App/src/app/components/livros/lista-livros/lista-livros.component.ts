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
    public livroId = 0;
    public exibirImg: boolean = true;
    public larguraImg: number = 80;
    public margemImg: number = 2;

    private _filtroLista: string = '';

    public alterarImg(): void{
      this.exibirImg = !this.exibirImg;
    }

    public get filtroLista(){
      return this._filtroLista
    }

    public set filtroLista(value: string){
      this._filtroLista = value;
      this.livrosFiltrados = this.filtroLista ? this.filtrarLivros(this.filtroLista) : this.livros;
    }

    public filtrarLivros(filtrarPor : string): Livro[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.livros.filter(
        (livro) =>
        livro.titulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        livro.autor.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        livro.editora.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        )
    }



      public ngOnInit(): void {
        this.spinner.show();
        this.pegarLivros();

      }

      public pegarLivros(): void{
        this.livroService.pegarLivros().subscribe(
          (_livros: Livro[]) => {
            this.livros = _livros;
            this.livrosFiltrados = this.livros;
          },
          (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao Carregar os Livros', 'Error!');
          },
          () => this.spinner.hide()
          );
        }

        openModal(template: TemplateRef<any>, livroId: number): void{
          this.livroId = livroId;
          this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
        }

        confirmar(): void {
          this.modalRef.hide();
          this.spinner.show();

          this.livroService.deletar(this.livroId).subscribe(
            (resultado: any) => {
              console.log(resultado);
              this.toastr.success('O Livro foi deletado com sucesso!', 'Deletado!');
              this.spinner.hide();
              this.pegarLivros();
          },
          (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar deletar o livro!', 'Erro ao Deletar!');
            this.spinner.hide();
          },
          () => this.spinner.hide(),
          );

        }

        cancelar(): void {
          this.modalRef.hide();
        }

        editarLivro(id: number): void{
          this.router.navigate([`livros/detalhe/${id}`]);
        }



      }
