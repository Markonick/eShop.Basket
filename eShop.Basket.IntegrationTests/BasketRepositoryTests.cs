using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using eShop.Basket.Domain;
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

        public BasketRepositoryTests()
        {
            var redis = ConnectionMultiplexer.Connect("127.0.0.1");
            var logger = new Mock<ILogger>();
            _repository = new BasketRepository(redis, logger.Object);
        }

        [Fact]
        public async Task GetBasket_should_return_basket_successfuly()
        {
            var item = new BasketItem { };
            const string customerId = "customerId";
            await _repository.AddItemToBasketAsync(item, customerId);

            const string id = "one";
            var basket = await _repository.GetBasketAsync(id);

            Assert.NotNull(basket);
            Assert.Single(basket.Items);
        }

        [Fact]
        public async Task AddItem_should_add_item_successfully_and_return_basket()
        {
            var item = new BasketItem { };
            const string customerId = "customerId";
            var basket = await _repository.AddItemToBasketAsync(item, customerId);

            Assert.NotNull(basket);
            Assert.Single(basket.Items);
        }
    }
}
