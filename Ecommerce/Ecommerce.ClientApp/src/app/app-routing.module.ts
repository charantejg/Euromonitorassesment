import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookdetailComponent } from './bookdetail/bookdetail.component';
import { CartComponent } from './cart/cart.component';
import { AuthenticationGuard } from './Guards/AuthenticationGuard';
import { LoginComponent } from './login/login.component';
import { MyordersComponent } from './myorders/myorders.component';
import { OrderdetailComponent } from './orderdetail/orderdetail.component';
import { ViewbooksComponent } from './viewbooks/viewbooks.component';

const routes: Routes = [
  {path:"", redirectTo:"login", pathMatch:"full"},
  {path:"login", component:LoginComponent},
  {path:"viewbooks", component:ViewbooksComponent, canActivate: [AuthenticationGuard]},
  {path:"bookdetail/:id", component:BookdetailComponent, canActivate: [AuthenticationGuard]},
  {path:"cart", component:CartComponent, canActivate: [AuthenticationGuard]},
  {path:"myorders", component:MyordersComponent, canActivate: [AuthenticationGuard]},
  {path:"orderdetail/:id", component:OrderdetailComponent, canActivate: [AuthenticationGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
