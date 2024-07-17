import { Component, OnInit } from '@angular/core';
import { ProdutosSugeridos } from 'src/app/models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  produtosSugeridos : ProdutosSugeridos []=[
    {
      imagem: '../../../assets/kfc.jpeg',
      categoria: {
        id:0,
        categoria: 'cabelo'
      }
    },
    {
      imagem: '../../../assets/pizza peperonni.jpg',
      categoria: {
        id:1,
        categoria: 'unha'
      }
    },
    {
      imagem: '../../../assets/food 0.jpeg',
      categoria: {
        id:2,
        categoria: 'pele'
      }
    }
  ];

  constructor( ){
  }
  ngOnInit(): void {
    
  }
}
