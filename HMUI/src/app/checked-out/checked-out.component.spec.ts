import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckedOutComponent } from './checked-out.component';

describe('CheckedOutComponent', () => {
  let component: CheckedOutComponent;
  let fixture: ComponentFixture<CheckedOutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheckedOutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CheckedOutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
