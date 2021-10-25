using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineSubscription.Catalog.UnitTest
{
    public class SubscribeServiceFake : ISubscriptionService
    {
        private readonly List<Subscription> _subscriptions;
        public SubscribeServiceFake()
        {
            _subscriptions = new List<Subscription>
            {
                new Subscription
                {
                    Id = 1,
                    Title = "Let us C",
                    Email = "tej@test.com"
                   
                },
                new Subscription
                {
                    Id = 2,
                    Title = "Python",
                    Email = "test1@test.com"

                }
            };
        }

        
        public Task<bool> AddSubscription(Subscription subscribeObj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Subscription>> GetSubscriptions(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveSubscription(UnsubscribeDto unsubscribeDto)
        {
            throw new System.NotImplementedException();
        }
    }
}