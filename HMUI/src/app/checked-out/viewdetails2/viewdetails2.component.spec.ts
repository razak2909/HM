import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Viewdetails2Component } from './viewdetails2.component';

describe('Viewdetails2Component', () => {
  let component: Viewdetails2Component;
  let fixture: ComponentFixture<Viewdetails2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Viewdetails2Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Viewdetails2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
