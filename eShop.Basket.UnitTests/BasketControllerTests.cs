using System;
using System.Net;
using System.Threading.Tasks;
using eShop.Basket.API;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using Xunit;

namespace eShop.Basket.UnitTests
{
    public class BasketControllerTests
    {
        private readonly BasketController _basketController;
        private readonly Mock<IBasketRepository> _repository;
        private readonly Mock<ILogger> _logger;

        public BasketControllerTests(Mock<ILogger> logger)
        {
            _logger = logger;
            _repository = new Mock<IBasketRepository>();
            _basketController = new BasketController(_repository.Object, _logger.Object);
        }

        [Fact]
        public async Task GetBasket_should_return_ok()
        {
            const int id = 1;
            var result = await _basketController.Get(id) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetBasket_should_return_notFound_when_id_not_found()
        {
            const int id = 1;
            var result = await _basketController.Get(id) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task PostBasket_should_update_basket_and_return_ok()
        {
            var value = "";
            var result = await _basketController.Post(value) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostBasket_should_return_notFound_when_id_not_found()
        {
            var value = "";
            var result = await _basketController.Post(value) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.NotFound);
        }
    }
}
