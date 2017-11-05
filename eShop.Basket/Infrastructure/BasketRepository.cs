using System.Threading.Tasks;
using eShop.Basket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Basket.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        public Task<string> GetBasketAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<object> UpdateBasketAsync(string value)
        {
            throw new System.NotImplementedException();
        }

        public Task<object> DeleteBasketAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}