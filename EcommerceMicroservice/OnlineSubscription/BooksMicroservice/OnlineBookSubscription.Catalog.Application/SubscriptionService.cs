using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IdentityServer4.Models;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Data.UnitOfWork.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Application
{
    public class SubscriptionService: ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddSubscription(Subscription subscription)
        {
            await _unitOfWork.Subscription.Add(subscription);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
            return true;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions(string email)
        {
            return await _unitOfWork.Subscription.Find(x => x.Email.Equals(email));
        }

        public async Task<bool> RemoveSubscription(UnsubscribeDto unsubscribeDto)
        {
            var result = await _unitOfWork.Subscription.Find(x => 
                x.Email.Equals(unsubscribeDto.Email) && x.Title.Equals(unsubscribeDto.Title));

            if (result == null)
                return false;

            var obj = result.FirstOrDefault();
            _unitOfWork.Subscription.Remove(obj);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
            return true;
        }
    }
}