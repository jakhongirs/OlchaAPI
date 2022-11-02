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
                    Price="353000",
                },

                new Product {
                    Id = 2,
                    Name="Смартфон Samsung Galaxy A32 6 GB 128GB Черный",
                    Description="Single SIM (Micro-SIM) or Dual SIM (Micro-SIM, dual stand-by)",
                    Price="2825000",
                },
            };


        /*ALL PRODUCTS*/
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(products);
        }

        /*SINGLE PRODUCT*/
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = products.Find(x => x.Id == id);
            if(product == null)
            {
                return BadRequest("Product Not Found!");
            }
            return Ok(product);
        }

        /*CREATE PRODUCT*/
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        /*UPDATE PRODUCT*/
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var product = products.Find(x => x.Id == request.Id);

            if (product == null)
            {
                return BadRequest("Product Not Found!");
            } 
            
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            return Ok(products);
        }

        /*DELETE PRODUCT*/
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> Delete(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return BadRequest("Product Not Found!");
            }

            products.Remove(product);
            return Ok(products);
        }
    }
}

