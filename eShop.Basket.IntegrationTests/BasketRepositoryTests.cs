using System;
using System.Collections.Generic;
using System.Text;
using eShop.Basket.Infrastructure;
using Moq;
using Serilog;
using Serilog.Core;
using StackExchange.Redis;
using Xunit;

namespace eShop.Basket.IntegrationTests
{
    public class BasketRepositoryTests
    {
        private readonly BasketRepository _repository;
        private IDatabase _db;

        public BasketRepositoryTests()
        {
            var redis = ConnectionMultiplexer.Connect("127.0.0.1");
            var logger = new Mock<ILogger>();
            _repository = new BasketRepository(redis, logger.Object);
        }

        [Fact]
        public void GetBasket_should_return_basket_successfuly()
        {
            const string id = "one";
            var result = _repository.GetBasketAsync(id);


        }
    }
}
