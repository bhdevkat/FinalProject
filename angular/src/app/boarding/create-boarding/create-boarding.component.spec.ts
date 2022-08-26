import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBoardingComponent } from './create-boarding.component';

describe('CreateBoardingComponent', () => {
  let component: CreateBoardingComponent;
  let fixture: ComponentFixture<CreateBoardingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateBoardingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBoardingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
