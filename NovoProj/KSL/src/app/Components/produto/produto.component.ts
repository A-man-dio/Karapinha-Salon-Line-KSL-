import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit{
//
view: 'grid' | 'list' = 'grid';
ordenar: 'padrao' | 'htl' | 'lth' = 'padrao';
constructor(){

}
ngOnInit(): void {
  
}
}
