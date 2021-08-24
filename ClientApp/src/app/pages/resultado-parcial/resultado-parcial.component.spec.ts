import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoParcialComponent } from './resultado-parcial.component';

describe('ResultadoParcialComponent', () => {
  let component: ResultadoParcialComponent;
  let fixture: ComponentFixture<ResultadoParcialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultadoParcialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultadoParcialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
