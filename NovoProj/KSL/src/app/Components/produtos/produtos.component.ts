import { Component, OnInit, Input } from '@angular/core';
import { SessaoService } from 'src/app/Serviços/sessao.service';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  @Input() view: 'grid' | 'list' | 'marcar' = 'grid';
  @Input() historico: 'sim'| 'nao' = 'nao';
  logado: boolean | null = null;

  constructor(private sessaoServiceo: SessaoService) { }

  ngOnInit(): void {
    console.log('ProdutosComponent foi inicializado com view:', this.view);
    const logado = this.sessaoServiceo.getItem('logado');
    if (logado !== null) {
      this.logado = Boolean(logado);
    }

  }

}
