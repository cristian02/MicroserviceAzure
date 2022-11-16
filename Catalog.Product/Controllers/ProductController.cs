using Catalog.Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Product.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly MicroservicesDBContext _db;

        public ProductController(ILogger<ProductController> logger, MicroservicesDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()=> Ok(await _db.Products.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)=> Ok(await _db.Products.FirstOrDefaultAsync(x=>x.Id == id));

        [HttpPost]
        public async Task<ActionResult> Post(Products product) {
             var result = _db.Products.AddAsync(product);
            await _db.SaveChangesAsync(); 
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tempProduct = await _db.Products.FirstOrDefaultAsync(x=>x.Id == id); 
            _db.Remove(tempProduct);
            await _db.SaveChangesAsync();
            return Ok(); 
        }
    }
}