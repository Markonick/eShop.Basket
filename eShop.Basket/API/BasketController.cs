using System;
using System.Net;
using System.Threading.Tasks;
using eShop.Basket.Domain;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace eShop.Basket.API
{
    [Route("api/v1/[controller]")]
    public class BasketController : Controller
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger _logger;

        public BasketController(IBasketRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/v1/basket/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var basket = await _repository.GetBasketAsync(id);
            if (basket == null) return NotFound();

            return Ok(basket);
        }

        // POST api/v1/basket/value
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string basket)
        {
            try
            {
                var result = await _repository.UpdateBasketAsync(basket);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Debug(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE /v1/basket/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteBasketAsync(id);
            if (result == null) return NotFound();

            return NoContent();
        }
    }
}
