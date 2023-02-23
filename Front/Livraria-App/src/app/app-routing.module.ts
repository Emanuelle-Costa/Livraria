import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalhesComponent } from './components/livros/detalhes/detalhes.component';
import { ListaLivrosComponent } from './components/livros/lista-livros/lista-livros.component';
import { LivrosComponent } from './components/livros/livros.component';

const routes: Routes = [
  { path: 'livros', redirectTo: 'livros/lista'},

  {
    path: 'livros', component: LivrosComponent,
    children: [
      { path: 'detalhe', component: DetalhesComponent },
      { path: 'detalhe/:id', component: DetalhesComponent },
      { path: 'lista', component: ListaLivrosComponent },
    ]
  },

  { path: '', redirectTo: 'livros/lista', pathMatch: 'full' },
  { path: '**', redirectTo: 'livros/lista', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
