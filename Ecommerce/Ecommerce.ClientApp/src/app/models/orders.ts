import { orderDetails } from "./orderDetail";

export class orders{
  ordersId:number;
  invoiceNumber:string;
  purchaseDate:string;
  email: string;
  totalCost:number;
  orderDetails: orderDetails[];

}
