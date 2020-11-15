using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApi2.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _db;
        public ProductsController(ApiContext db)
        {
            _db = db;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _db.Products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _db.Products.SingleOrDefault(a => a.Id == id);
        }
        [HttpGet("GetCategoryByProduct")]
        public Product GetCategoryByProduct(int id)
        {
            var item = from p in _db.Products
                       join c in _db.Categories
                       on p.CategoryId equals c.Id
                       where p.Id == id
                       select new
                       {
                           Name = c.Name,
                           Price = p.Price
                       };
            return (Product)item;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _db.Products.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _db.Products.Remove(item);
                _db.SaveChanges();
            }
            
        }
    }
}
