import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { elementAt } from 'rxjs/operators';
import { user } from '../models/user';
import { AuthenticationService } from '../service/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: user = new user();
  validLogin = true;

  constructor(private authentication: AuthenticationService, private router: Router) { }

  ngOnInit(): void {

    localStorage.setItem('isLoggedIn', "false");
  }

  onLogin(){

    this.authentication.login(this.user).subscribe(
      (data)=> {  console.log(data);
        if(data.token == null)
        this.validLogin = false;
         else
         {
          localStorage.setItem('isLoggedIn', "true");
            this.router.navigate(["viewbooks"]);
         }
      },
      error=> { if( String(error).includes("500"))
              this.validLogin = false }

    )
  }
  
}
