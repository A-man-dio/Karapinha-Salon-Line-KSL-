import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';



@Component({
  selector: 'app-marcar',
  templateUrl: './marcar.component.html',
  styleUrls: ['./marcar.component.css'],
})
export class MarcarComponent implements OnInit {
  minDate: Date = new Date();
  selectedDate: Date = new Date(); // Inicializa com a data atual
  profissionalSelected = new FormControl('0');
  horaSelected = new FormControl('0');
  
  confirmP:boolean =false;
  confirmH:boolean =false;
  profissional: string ='';
  hora: string ='';

  constructor() { }

  ngOnInit(): void {
    
    this.profissionalSelected.valueChanges.subscribe((res: any) => {
      if(res === '0'){
        this.profissional ='';
        this.confirmP=false;
      }
      else{
        this.profissional = res.toString();
        this.confirmP=true;
      }
    });

    this.horaSelected.valueChanges.subscribe((res: any) => {
      if(res === '0'){
        this.hora ='';
        this.confirmH=false;
      }
      else{
        this.hora = res.toString();
        this.confirmH=true;
      }
    });
    
  }

  onSelectDate(event: any): void {
    const dateTime = event.value;
    const currentDate = new Date();

    if (dateTime.setHours(0, 0, 0, 0) < currentDate.setHours(0, 0, 0, 0)) {
      alert('Selecione uma data válida.');
      return;
    }

    this.selectedDate = dateTime;
    console.log('Data selecionada:', this.selectedDate.toLocaleDateString());
  }

}