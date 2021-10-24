import { Component, OnInit } from '@angular/core';
import { DataService } from '../service/data.service';
import { book } from '../models/book';
import { environment } from 'src/environments/environment';
import { addCart } from '../models/addCart';


@Component({
  selector: 'app-viewbooks',
  templateUrl: './viewbooks.component.html',
  styleUrls: ['./viewbooks.component.css']
})
export class ViewbooksComponent implements OnInit {


  books:book[];
  cart: addCart = new addCart;
  cartCount: number;
  apiPath = environment.baseUrl;
  isItemAdded = false;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.isItemAdded = false;
    this.dataService.getBooks().subscribe(
      (data)=> {
        this.books = data;
      }

    );

  }

  addToCart(bookId: number)
  {
     this.cart.bookId = bookId;
     this.cart.userId = Number(localStorage.getItem("userId"));
     this.dataService.AddtoCart(this.cart).subscribe((data)=>{
      this.cartCount = data, this.isItemAdded = true; });

  }

  onClose()
  {
    this.ngOnInit();
  }

}


