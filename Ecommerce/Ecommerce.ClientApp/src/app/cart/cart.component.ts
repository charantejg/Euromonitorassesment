import { ThrowStmt } from '@angular/compiler';
import { CoreEnvironment } from '@angular/compiler/src/compiler_facade_interface';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { addCart } from '../models/addCart';
import { cartDisplay } from '../models/cartDisplay';
import { DataService } from '../service/data.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: cartDisplay = new cartDisplay();
  apiPath = environment.baseUrl;
  addtocart: addCart = new addCart;
  removefromCart: addCart = new addCart;
  cartCount: number;
  totalSum: number;
  cartsTobeRemoved: addCart[];


  quantity:number=1;
  constructor(private dataService: DataService, private router: Router ) { }

  ngOnInit(): void {

    this.totalSum = 0;

    this.dataService.getCartById().subscribe((data)=>{
        this.cart = data,
        this.totalSum = this.cart.bookPurchaeList.reduce((sum,current)=> sum+current.subTotal,0)

      });


  }



  toggleLess(bookId: number, itemQuantity: number){

    if(itemQuantity>1)
    {
      this.reloadCart(bookId,false);
      this.ngOnInit();
    }


  }

  toggleMore(bookId: number, itemQuantity: number){
    if(itemQuantity<25)
    {
      this.reloadCart(bookId,true);
      this.ngOnInit();
    }

  }

  placeOrder(cart: cartDisplay)
  {

    this.dataService.createOrder(cart).subscribe((data)=>{console.log(data),
    this.removeTemporaryCart(cart),
    this.router.navigate(["myorders"])
     });


  }

  removeTemporaryCart(cart: cartDisplay)
  {
      //remove temporary cart
       this.dataService.getCartItems(cart.userId).subscribe((data)=>{
        this.cartsTobeRemoved = data, console.log(data +'total cart items'),
        this.dataService.removeCartItems( this.cartsTobeRemoved).subscribe((data)=>{console.log(data)})

      });
  }

  reloadCart(bookId: number, increment: Boolean )
  {

    this.addtocart.bookId = bookId;
    this.removefromCart.bookId = bookId;
    this.addtocart.userId = Number(localStorage.getItem("userId"));
    this.removefromCart.userId =  Number(localStorage.getItem("userId"));


    if(increment)
     {
      this.dataService.AddtoCart(this.addtocart).subscribe((data)=>{console.log(data +': add count'),
      this.ngOnInit()});
     }
     else
     {

      this.dataService.getMaxCartCount(this.removefromCart).subscribe((data)=>{
          this.cartCount = data,
          this.removefromCart.cartId = this.cartCount,
          this.dataService.RemoveFromCart(this.removefromCart).subscribe((data)=>{console.log(data +': remove count')}),
          this.ngOnInit()
        });

     }
   }

}
