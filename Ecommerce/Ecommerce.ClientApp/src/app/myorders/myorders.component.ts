import { Component, OnInit } from '@angular/core';
import { orders } from '../models/orders';
import { DataService } from '../service/data.service';

@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.css']
})
export class MyordersComponent implements OnInit {

  orders: orders[];
  email = localStorage.getItem("email");

  constructor(private dataService: DataService) { }

  ngOnInit(): void {

   this.dataService.getOrders(this.email).subscribe((data)=>{console.log(data),
    this.orders = data});

  }

}

