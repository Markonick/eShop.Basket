using System.Threading.Tasks;
using eShop.Basket.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Basket.Domain
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);
        Task<CustomerBasket> AddItemToBasketAsync(BasketItem item, string customerId);
        Task<CustomerBasket> DeleteItemToBasketAsync(BasketItem item, string customerId);
        Task<object> DeleteBasketAsync(string customerId);
    }
}