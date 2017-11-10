using System.Threading.Tasks;
using eShop.Basket.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Basket.Domain
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);
        Task<object> UpdateBasketAsync(string value);
        Task<object> DeleteBasketAsync(string customerId);
    }
}