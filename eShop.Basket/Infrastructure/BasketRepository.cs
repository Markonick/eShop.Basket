using System;
using System.Threading.Tasks;
using eShop.Basket.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;

namespace eShop.Basket.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ILogger _logger;
        private readonly IDatabase _db;

        public BasketRepository(ConnectionMultiplexer redis, ILogger logger)
        {
            _logger = logger;
            _db = redis.GetDatabase();
        }

        public async Task<CustomerBasket> GetBasketAsync(string customerId)
        {
            try
            {
                var basket = await _db.StringGetAsync(customerId);

                if (basket.IsNullOrEmpty) return null;

                return JsonConvert.DeserializeObject<CustomerBasket>(basket);
            }
            catch (Exception ex)
            {
                _logger.Debug(ex.Message);
                throw;
            }
        }

        public Task<object> UpdateBasketAsync(string value)
        {
            throw new System.NotImplementedException();
        }

        public Task<object> DeleteBasketAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}