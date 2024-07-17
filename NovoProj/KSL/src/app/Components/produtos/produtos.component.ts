import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  @Input() view: 'grid' | 'list' | 'marcar' = 'grid';
  @Input() historico: 'sim'| 'nao' = 'nao';

  constructor() { }

  ngOnInit(): void {
    console.log('ProdutosComponent foi inicializado com view:', this.view);
  }

}
