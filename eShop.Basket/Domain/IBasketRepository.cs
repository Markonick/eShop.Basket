using System.Threading.Tasks;
using eShop.Basket.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Basket.Domain
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<CustomerBasket> DeleteItemToBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string customerId);
    }
}