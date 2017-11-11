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

        public async Task<CustomerBasket> AddItemToBasketAsync(BasketItem item, string customerId)
        {
            try
            {
                //Get the basket for this customer
                var basket = await _db.StringGetAsync(customerId);
                if (basket.IsNullOrEmpty) return null;
                var result = JsonConvert.DeserializeObject<CustomerBasket>(basket);

                //Now add item to basket
                result.Items.Add(item);

                //Update basket
                var updated = await _db.StringSetAsync(key: customerId, value: JsonConvert.SerializeObject(result));
                if (updated.Equals(false))
                {
                    _logger.Debug("Basket wasn't updated into Redis");
                    return null;
                }

                return await GetBasketAsync(customerId);
            }
            catch (Exception ex)
            {
                _logger.Debug(ex.Message);
                throw;
            }
        }

        public Task<CustomerBasket> DeleteItemToBasketAsync(BasketItem item, string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeleteBasketAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}