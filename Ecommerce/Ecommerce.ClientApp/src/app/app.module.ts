import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ViewbooksComponent } from './viewbooks/viewbooks.component';
import { BookdetailComponent } from './bookdetail/bookdetail.component';
import { CartComponent } from './cart/cart.component';
import { MyordersComponent } from './myorders/myorders.component';
import { FormsModule } from '@angular/forms';
import { OrderdetailComponent } from './orderdetail/orderdetail.component';
import { HttpClientModule } from '@angular/common/http';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AuthenticationGuard } from './Guards/AuthenticationGuard';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ViewbooksComponent,
    BookdetailComponent,
    CartComponent,
    MyordersComponent,
    OrderdetailComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    AuthenticationGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
