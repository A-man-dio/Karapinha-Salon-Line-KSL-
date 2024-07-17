import { Component,OnInit, Input } from '@angular/core';
import { Categoria } from 'src/app/models/models';

@Component({
  selector: 'app-produtos-sugeridos',
  templateUrl: './produtos-sugeridos.component.html',
  styleUrls: ['./produtos-sugeridos.component.css']
})
export class ProdutosSugeridosComponent implements OnInit {
  @Input() categoria: Categoria={
    id :0,
    categoria:''
  }
  @Input() qtd = 3;
  constructor( ) { }
  ngOnInit(): void{ }

}
