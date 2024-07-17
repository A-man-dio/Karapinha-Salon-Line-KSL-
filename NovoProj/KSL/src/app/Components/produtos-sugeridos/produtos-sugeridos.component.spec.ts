import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutosSugeridosComponent } from './produtos-sugeridos.component';

describe('ProdutosSugeridosComponent', () => {
  let component: ProdutosSugeridosComponent;
  let fixture: ComponentFixture<ProdutosSugeridosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProdutosSugeridosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProdutosSugeridosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
