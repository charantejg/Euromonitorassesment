import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { book } from '../models/book';
import { DataService } from '../service/data.service';
import { environment } from 'src/environments/environment';
import { addCart } from '../models/addCart';

@Component({
  selector: 'app-bookdetail',
  templateUrl: './bookdetail.component.html',
  styleUrls: ['./bookdetail.component.css']
})
export class BookdetailComponent implements OnInit {

  book:book = new book;
  apiPath = environment.baseUrl;
  cart: addCart = new addCart;
  cartCount: number;


  constructor(private dataService : DataService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    var id = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    this.dataService.getBooksById(id).subscribe(
      (data) => { this.book = data, this.book.thumbnailPath = this.apiPath + this.book.thumbnailPath });

  }

  addToCart(bookId: number)
  {
     this.cart.bookId = bookId;
     this.cart.userId = Number(localStorage.getItem("userId"));

     this.dataService.AddtoCart(this.cart).subscribe((data)=>{
      this.cartCount = data });
  }

}


