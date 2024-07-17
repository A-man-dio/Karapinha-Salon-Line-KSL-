import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarcarComponent } from './marcar.component';

describe('MarcarComponent', () => {
  let component: MarcarComponent;
  let fixture: ComponentFixture<MarcarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarcarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MarcarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
