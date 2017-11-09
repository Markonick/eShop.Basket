using System.Threading.Tasks;
using eShop.Basket.Domain;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace eShop.Basket.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        private IDatabase _db;

        public BasketRepository(ConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task<string> GetBasketAsync(string customerId)
        {
            var basket = await _db.StringGetAsync(customerId);
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