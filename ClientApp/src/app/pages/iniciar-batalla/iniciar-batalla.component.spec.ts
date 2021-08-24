import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IniciarBatallaComponent } from './iniciar-batalla.component';

describe('IniciarBatallaComponent', () => {
  let component: IniciarBatallaComponent;
  let fixture: ComponentFixture<IniciarBatallaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IniciarBatallaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IniciarBatallaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
