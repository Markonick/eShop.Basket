using System.Collections.Generic;

namespace eShop.Basket.Domain
{
    public class CustomerBasket
    {
        public string CustomerId { get; set; }
        public List<BasketItem> Items { get; set; }

        public CustomerBasket(string customerId)
        {
            CustomerId = customerId;
            Items = new List<BasketItem>();
        }
    }
}