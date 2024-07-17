import { Directive, HostListener, Input } from '@angular/core';
import { Categoria } from '../models/models';
import { Router } from '@angular/router';

@Directive({
  selector: '[CatServicos]'
})
export class CatServicosDirective {

  @Input() categoria: Categoria={
    id:0,
    categoria:''
  };

  @HostListener('click') abrirCategoria() {
    this.router.navigate(['/produtos']),{
      queryParams: {
        categoria: this.categoria.categoria,
      },
    }
  }

  constructor(private router:Router) { }
}
