import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { orders } from '../models/orders';
import { DataService } from '../service/data.service';

@Component({
  selector: 'app-orderdetail',
  templateUrl: './orderdetail.component.html',
  styleUrls: ['./orderdetail.component.css']
})
export class OrderdetailComponent implements OnInit {

  orderinfo: orders = new orders;
  apiPath = environment.baseUrl;

  constructor(private dataService: DataService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit():void {

    var id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
     console.log(id);
     this.dataService.getOrdersById(id).subscribe((data)=>{
     this.orderinfo = data, console.log(this.orderinfo)});

  }

}

