using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
   public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public async Task<int> Create(CheckoutDto checkoutDto)
        {
            try
            {
                decimal total = 0;
                var orderinfo = new Orders
                {
                    InvoiceNumber = _unitOfWork.Orders.InvoiceGenerator(),
                    PurchaseDate = DateTime.Now,
                    Email = checkoutDto.EmailId,
                    TotalCost = total,
                    OrderDetails = new List<OrderDetails>()
                };

                foreach (var order in checkoutDto.BookPurchaeList)
                {
                    orderinfo.OrderDetails.Add(new OrderDetails
                    {
                        OrderDetailsId = orderinfo.OrdersId,
                        Quantity = order.Quantity,
                        Title = order.BookTitle,
                        ThumbnailPath = order.ThumbnailPath,
                        Price = order.Price,
                        SubTotal = order.SubTotal
                        
                    });

                    total += order.SubTotal;
                }

                orderinfo.TotalCost = total;

                await _unitOfWork.Orders.Add(orderinfo);
                var result = _unitOfWork.Complete();
                return result;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Orders>> GetByEmail(string email)
        {
            return await _unitOfWork.Orders.Find(x => x.Email.Equals(email.ToLower()));
        }

        public async Task<Orders> GetByOrderId(int orderId)
        {
            var orders =  await _unitOfWork.Orders.GetById(orderId);
            var orderDetails = await _unitOfWork.OrderDetails.Find(x => x.OrdersId.Equals(orderId));
            orders.OrderDetails = new List<OrderDetails>();
            foreach (var order in orderDetails)
            {               
                orders.OrderDetails.Add(order);
            }
            return orders;
        }

        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await _unitOfWork.Orders.GetAll();
        }
    }
}
