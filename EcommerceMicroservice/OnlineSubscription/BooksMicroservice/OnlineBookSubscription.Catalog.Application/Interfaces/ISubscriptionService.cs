using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Application.Interfaces
{
    public interface ISubscriptionService
    {
        Task<bool> AddSubscription(Subscription subscribeObj);

        Task<IEnumerable<Subscription>> GetSubscriptions(string email);

        Task<bool> RemoveSubscription(UnsubscribeDto unsubscribeDto);


    }
}