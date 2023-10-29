import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SumValidTransactionComponent } from './sum-valid-transaction.component';

describe('SumValidTransactionComponent', () => {
  let component: SumValidTransactionComponent;
  let fixture: ComponentFixture<SumValidTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SumValidTransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SumValidTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
