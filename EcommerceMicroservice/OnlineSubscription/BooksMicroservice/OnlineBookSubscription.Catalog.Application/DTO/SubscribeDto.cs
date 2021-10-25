using System;

namespace OnlineBookSubscription.Catalog.Application.DTO
{
    public class SubscribeDto
    {
        public string Email{ get; set; }
        public string Title { get; set; }
        public DateTime SubscriptionDateTime { get; set; }

    }
}