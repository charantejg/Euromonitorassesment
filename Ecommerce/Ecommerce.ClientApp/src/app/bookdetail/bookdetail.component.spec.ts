import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookdetailComponent } from './bookdetail.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';

import { RouterTestingModule } from '@angular/router/testing';

describe('BookdetailComponent', () => {
  let component: BookdetailComponent;
  let fixture: ComponentFixture<BookdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookdetailComponent ],
      imports: [
        HttpClientTestingModule,
        HttpClientModule,
        RouterTestingModule
      ]
    })
    .compileComponents();
  });
  

  beforeEach(() => {
    fixture = TestBed.createComponent(BookdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
