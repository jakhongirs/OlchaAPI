using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OlchaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }


        /*ALL PRODUCTS*/
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        /*SINGLE PRODUCT*/
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
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
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        /*UPDATE PRODUCT*/
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return BadRequest("Product Not Found!");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        /*DELETE PRODUCT*/
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return BadRequest("Product Not Found!");
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }
    }
}

