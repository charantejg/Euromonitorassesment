import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyordersComponent } from './myorders.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';

describe('MyordersComponent', () => {
  let component: MyordersComponent;
  let fixture: ComponentFixture<MyordersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyordersComponent ],
      imports: [
        HttpClientTestingModule,
        HttpClientModule
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyordersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
