import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onLogout()
  {

    localStorage.setItem("isLoggedIn", "false");
    //alert(localStorage.getItem("isLoggedIn"));
    this.router.navigate(["login"]).then(() => {
      window.location.reload();
    });

  }
}
