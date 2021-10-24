using OnlineBookSubscription.Catalog.Data.Repository.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Data.Repository
{
    public class SubscriptionRepository: GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}