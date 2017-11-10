using System.Collections.Generic;

namespace eShop.Basket.Domain
{
    public class CustomerBasket
    {
        private readonly string _customerId;
        public string CustomerId { get; set; }
        public List<BasketItem> Items { get; set; }

        public CustomerBasket(string customerId)
        {
            _customerId = customerId;
            Items = new List<BasketItem>();
        }
    }
}