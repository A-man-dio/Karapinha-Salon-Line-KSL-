import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-detalhe-produto',
  templateUrl: './detalhe-produto.component.html',
  styleUrls: ['./detalhe-produto.component.css']
})
export class DetalheProdutoComponent implements OnInit{

  descricao:string = 'Corte esconvinho';
  imagem: number=1;
  constructor(){

  }

  ngOnInit(): void {
  
  }
}
