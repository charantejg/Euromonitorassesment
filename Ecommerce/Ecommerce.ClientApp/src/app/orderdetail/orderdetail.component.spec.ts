import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderdetailComponent } from './orderdetail.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';
describe('OrderdetailComponent', () => {
  let component: OrderdetailComponent;
  let fixture: ComponentFixture<OrderdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderdetailComponent ],
      imports: [
        HttpClientTestingModule,
        HttpClientModule,
        RouterModule.forRoot([])
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
