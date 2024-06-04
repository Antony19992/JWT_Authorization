using jwt_authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_authorization.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class ProductsController : ControllerBase
        {
            private List<Product> _products;
            public ProductsController()
            {
                _products = new List<Product>
            {
                new Product {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Produto Teste 1",
                    Price = 100.10m
                },
                new Product {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Produto Teste 2",
                    Price = 100.20m
                }
            };
            }

            [HttpGet]
            public IActionResult Get() => Ok(_products);

            [HttpPost]
            public IActionResult Post([FromBody] Product product)
            {
                product.Guid = Guid.NewGuid().ToString();
                _products.Add(product);
                return Ok();
            }

            [HttpDelete]
            [Route("{guid}")]
            public IActionResult Delete(string guid)
            {
                _products = _products.Where(x => !x.Guid.Equals(guid)).ToList();
                return Ok();
            }
        }
}
