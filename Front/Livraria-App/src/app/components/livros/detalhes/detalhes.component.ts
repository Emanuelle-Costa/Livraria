import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Livro } from 'src/app/models/Livro';
import { LivroService } from 'src/app/services/livro.service';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.scss']
})
export class DetalhesComponent {

  constructor(
    private fb: FormBuilder,
    private router: ActivatedRoute,
    private livroService: LivroService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private localeService: BsLocaleService)
    {
      this.localeService.use('pt-br');
    }

    ngOnInit(): void {
      this.carregarLivro();
      this.validacao();

    }

  livro = {} as Livro;
  form =  {} as FormGroup;
  estadoSalvar ='adicionar';

  get f(): any {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-orange',
      showWeekNumbers: false,
    };
  }

  public carregarLivro(): void {
    const livroIdParam = this.router.snapshot.paramMap.get('id');

    if (livroIdParam !== null){
      this.spinner.show();

      this.estadoSalvar = 'atualizar';

      this.livroService.pegarLivroPorId(+livroIdParam).subscribe(
        (livro: Livro) => {
          this.livro = {...livro};
          this.form.patchValue(this.livro);
        },
        (error: any) => {
          console.error(error);
          this.toastr.error('Erro ao tentar carregar Livro.', 'Erro!');
          this.spinner.hide();
        },
        () => this.spinner.hide(),
        );
      }
  }

  public resetForm(): void{
    this.form.reset();
  }

  public cssValidar(campoForm: FormControl): any {
    return {'is-invalid': campoForm.errors && campoForm.touched};
  }

  public validacao(): void{

    this.form = this.fb.group({

      titulo: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      subtitulo: ['', [Validators.minLength(3), Validators.maxLength(100)]],
      qntPaginas : ['', [Validators.required, Validators.min(10), Validators.max(10000)]],
      autor: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      resumo: ['', [Validators.minLength(3), Validators.maxLength(500)]],
      editora: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      dataPublicacao: ['', Validators.required],
      edicao: ['', [Validators.min(1), Validators.max(20)]],
      preco : ['', [Validators.required,]],
      qntLivroEmEstoque: ['', [Validators.required, Validators.min(1)]],
      imagemURL:['', [Validators.required]]
    });
  }

  public salvarAlteracao(): void{
    this.spinner.show();
    if (this.form.valid){

      if(this.estadoSalvar === 'adicionar'){
        this.livro = {...this.form.value};
        this.livroService['adicionar'](this.livro).subscribe(
          () => this.toastr.success('livro salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar livro!', 'Erro');
          },
          () => this.spinner.hide()
          );
        } else{
          this.livro = {id: this.livro.id, ...this.form.value};
          this.livroService['atualizar'](this.livro).subscribe(
            () => this.toastr.success('livro salvo com sucesso!', 'Sucesso'),
            (error: any) => {
              console.error(error);
              this.spinner.hide();
              this.toastr.error('Erro ao salvar livro!', 'Erro');
            },
            () => this.spinner.hide()
            );

          }
        }
      }

}


