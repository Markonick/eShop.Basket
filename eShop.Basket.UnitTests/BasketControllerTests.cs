using System;
using System.Net;
using System.Threading.Tasks;
using eShop.Basket.API;
using eShop.Basket.Domain;
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

        public BasketControllerTests()
        {
            var logger = new Mock<ILogger>();
            _repository = new Mock<IBasketRepository>();
            _basketController = new BasketController(_repository.Object, logger.Object);
        }

        [Fact]
        public async Task GetBasket_should_return_ok()
        {
            const string customerId = "somecustomerid";
            _repository.Setup(b => b.GetBasketAsync(customerId)).Returns(Task.FromResult((new CustomerBasket(customerId))));

            var result = await _basketController.Get(customerId) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetBasket_should_return_notFound_when_id_not_found()
        {
            const string customerId = "somecustomerid";
            _repository.Setup(b => b.GetBasketAsync(customerId)).Returns(Task.FromResult((CustomerBasket)null));

            var result = await _basketController.Get(customerId) as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task PostBasket_should_update_basket_and_return_ok()
        {
            var item = new BasketItem()
            {

            };
            const string customerId = "somecustomerid";
            _repository.Setup(b => b.AddItemToBasketAsync(item, customerId)).Returns(Task.FromResult(new CustomerBasket(customerId)));

            var result = await _basketController.Post(item, customerId) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostBasket_should_return_notFound_when_id_not_found()
        {
            var item = new BasketItem()
            {

            };
            const string customerId = "somecustomerid";
            _repository.Setup(b => b.AddItemToBasketAsync(item, customerId)).Returns(Task.FromResult((CustomerBasket)null));

            var result = await _basketController.Post(item, customerId) as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task DeleteBasket_should_return_noContent()
        {
            const string id = "1";
            _repository.Setup(b => b.DeleteBasketAsync(id)).Returns(Task.FromResult(new object()));

            var result = await _basketController.Delete(id) as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.NoContent);
        }
    }
}
