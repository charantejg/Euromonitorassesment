import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";

@Injectable()

export class AuthenticationGuard implements CanActivate {
    constructor(private router:Router) {};

    isLoggedIn =  JSON.parse(localStorage.getItem('isLoggedIn'));


    canActivate() {
      console.log("OnlyLoggedInUsers");
      if (this.isLoggedIn) {
        return true;
      }
      else {
        alert("You don't have permission to view this page. Please login again.");
        this.router.navigate(['/login']);
        return false;
      }
    }
  }
