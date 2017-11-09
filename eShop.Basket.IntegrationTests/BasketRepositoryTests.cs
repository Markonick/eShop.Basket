using System;
using System.Collections.Generic;
using System.Text;
using eShop.Basket.Infrastructure;
using StackExchange.Redis;
using Xunit;

namespace eShop.Basket.IntegrationTests
{
    public class BasketRepositoryTests
    {
        private readonly BasketRepository _repository;
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public BasketRepositoryTests()
        {
            var redis = ConnectionMultiplexer.Connect("127.0.0.1");
            _repository = new BasketRepository(redis);
        }

        [Fact]
        public void GetBasket_should_return_basket_successfuly()
        {
            const int id = 1;
            var result = _repository.GetBasketAsync(id);


        }
    }
}
