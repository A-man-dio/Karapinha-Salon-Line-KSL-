import { Component, ElementRef, OnInit, Type, ViewChild, ViewContainerRef } from '@angular/core';
import { Navegacao } from 'src/app/models/models';
import { LoginComponent } from '../login/login.component';
import { RegistoComponent } from '../registo/registo.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  @ViewChild('modalTitle') modalTitle !: ElementRef;
  @ViewChild('container',{read: ViewContainerRef,static:true}) container !: ViewContainerRef;
  listaNav: Navegacao[] = [
    {
      categoria:'pele'
    },
    {
      categoria:'cabelo'
    }
  ];
  constructor(){

  }
  ngOnInit(): void {
    
  }

  openModal(name:string){
    this.container.clear();

    let tipoComponente !: Type<any>;
    if(name === 'login')
    { 
      tipoComponente = LoginComponent; 
      this.modalTitle.nativeElement.textContent = 'Insira as informações de login';
    }
    if(name === 'registar') 
    {
      tipoComponente = RegistoComponent;
      this.modalTitle.nativeElement.textContent = 'Insira as informações de registo';
    }
    this.container.createComponent(tipoComponente);
  }
  
}
