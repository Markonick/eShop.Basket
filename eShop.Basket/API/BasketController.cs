using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Post([FromBody]string value)
        {
            var basket = await _repository.UpdateBasketAsync(value);
            if (basket == null) return NotFound();

            return Ok(basket);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public interface IBasketRepository
    {
        Task<string> GetBasketAsync(int id);
        Task<object> UpdateBasketAsync(string value);
    }
}
