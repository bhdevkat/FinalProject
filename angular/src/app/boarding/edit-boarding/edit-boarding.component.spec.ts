import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBoardingComponent } from './edit-boarding.component';

describe('EditBoardingComponent', () => {
  let component: EditBoardingComponent;
  let fixture: ComponentFixture<EditBoardingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditBoardingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBoardingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
