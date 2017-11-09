using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Basket.Domain
{
    public interface IBasketRepository
    {
        Task<string> GetBasketAsync(string customerId);
        Task<object> UpdateBasketAsync(string value);
        Task<object> DeleteBasketAsync(int id);
    }
}