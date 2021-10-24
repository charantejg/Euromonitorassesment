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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public async Task<CheckoutDto> Get(int userId)
        {

            var cartItems = await _unitOfWork.Cart.Find(x => x.UserId.Equals(userId));

            var booksQuantity = cartItems.GroupBy(x => x.BookId)
                                  .Select(y => new { BookId = y.Key, Total = y.Count() });


            var cartInfo = new CheckoutDto
            {
                UserId = userId,
                EmailId = _unitOfWork.Users.GetById(userId).Result.Email,
                BookPurchaeList = new List<BookPurchaseDto>()
            };

            foreach (var items in booksQuantity)
            {
                var book = _unitOfWork.Books.GetById(items.BookId).Result;
                cartInfo.BookPurchaeList.Add(new BookPurchaseDto
                {
                    BookId = items.BookId,
                    BookTitle = book.BookTitle,
                    Quantity = items.Total,
                    ThumbnailPath = book.ThumbnailPath,
                    Price = book.Price
                });
            }

            return cartInfo;
        }

        public async Task<int> Post(Cart cart)
        {
            try
            {
                var userCart = _unitOfWork.Cart.Add(cart);
                _unitOfWork.Complete();
                
                return _unitOfWork.Cart.Find(x => x.UserId.Equals(cart.UserId)).Result.Count();
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }

        public async Task<int> Remove(Cart cart)
        {
            try
            {
             _unitOfWork.Cart.Remove(cart);
              return _unitOfWork.Complete();
            }
            catch
            {
                return 0;
            }

        }


        public async Task<int> GetMaxCartId(Cart cart)
        {
            try
            {
                var count =  await _unitOfWork.Cart.MaxItemFromCart(cart);
                _unitOfWork.Dispose();
                return count;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Cart>> GetCartItems(int userId)
        {
            return await _unitOfWork.Cart.Find(x => x.UserId == userId);

        }

        public void RemoveCartItems(IEnumerable<Cart> carts)
        {
            
           _unitOfWork.Cart.RemoveRange(carts);
           _unitOfWork.Complete();
                
        }

    }

}
