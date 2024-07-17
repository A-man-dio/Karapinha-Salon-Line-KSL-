import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaPedComponent } from './lista-ped.component';

describe('ListaPedComponent', () => {
  let component: ListaPedComponent;
  let fixture: ComponentFixture<ListaPedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaPedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaPedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
