using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OlchaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
            {
                new Product {
                    Id = 1,
                    Name="Xiaomi Mi Band 6",
                    Description="Fitnes braslet, 32 MB, 125 mAh, Bluetooth v 5.0",
                    Price=353000,
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }
    }
}

