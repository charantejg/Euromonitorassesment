import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { book } from '../models/book';
import { environment } from 'src/environments/environment';
import { addCart } from '../models/addCart';
import { cartDisplay } from '../models/cartDisplay';
import { orders } from '../models/orders';



@Injectable({
  providedIn: 'root'
})
export class DataService {

  private pathAPI = environment.baseUrl;
  private booksController = 'api/book';
  private cartController = 'api/cart';
  private orderController = 'api/orders';


  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer '+ localStorage.getItem('authToken')
    }),
  };


  constructor(private httpClient: HttpClient) {}

  //#region Books
  getBooks(): Observable<book[]> {
    return this.httpClient
      .get<book[]>(this.pathAPI + this.booksController + '/DisplayBooks', this.httpOptions)
      .pipe(catchError(this.errorHandler));
  }


  getBooksById(id:number):Observable<book>{
    console.log(`${this.pathAPI+ this.booksController}/${id}`);
    return this.httpClient.get<book>(`${this.pathAPI+ this.booksController}/${id}`,this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }
  //#endregion

  //#region ShopingCart
  AddtoCart(addCart: addCart):Observable<number>{
    return this.httpClient.post<number>(this.pathAPI+this.cartController,addCart,this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    );
    }

    getCartById():Observable<cartDisplay>{
     var id = Number(localStorage.getItem("userId"));
      return this.httpClient.get<cartDisplay>(`${this.pathAPI+ this.cartController}/${id}`,this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
    }

    RemoveFromCart(addCart: addCart):Observable<number>{
      return this.httpClient.post<number>(this.pathAPI+this.cartController+"/Remove",addCart,this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
     }

     getMaxCartCount(addCart: addCart):Observable<number> {
      return this.httpClient
        .post<number>(this.pathAPI + this.cartController + "/MaxCartIem", addCart, this.httpOptions)
        .pipe(catchError(this.errorHandler));
    }

    getCartItems(userId: number):Observable<addCart[]>
    {
      return this.httpClient.get<addCart[]>
      (`${this.pathAPI+ this.cartController +"/GetCartItems" }/${userId}`,this.httpOptions)
      .pipe(
        catchError(this.errorHandler));

    }

    removeCartItems(addCartItems: addCart[]):Observable<JSON>
    {

      return this.httpClient.post<JSON>(this.pathAPI+this.cartController+"/RemoveCartItems",addCartItems,this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
    }

    //#endregion


    //#region Orders
    createOrder(cartItems: cartDisplay):Observable<number>
    {
      return this.httpClient.post<number>(this.pathAPI+this.orderController+"/create",cartItems,this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
    }

    getOrders(email:string):Observable<orders[]>
    {
      return this.httpClient.get<orders[]>
      (`${this.pathAPI +this.orderController+"/GetByEmail" }/${email}`,this.httpOptions)
      .pipe(
        catchError(this.errorHandler));

    }

    getOrdersById(id:number):Observable<orders>
    {
      return this.httpClient.get<orders>
      (`${this.pathAPI +this.orderController+"/GetByOrder" }/${id}`,this.httpOptions)
      .pipe(
        catchError(this.errorHandler));

    }

    //#endregion


  errorHandler(error: {
    error: { message: string };
    status: any;
    message: any;
  }) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
