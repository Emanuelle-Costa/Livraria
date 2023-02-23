import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent {


  constructor(private router: Router){

  }

  ngOnInit() : void {

  }


  listar(): void{
    this.router.navigate(['livros/lista']);
  }
}
