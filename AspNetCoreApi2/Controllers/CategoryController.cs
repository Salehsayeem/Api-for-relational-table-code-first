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
    public class CategoryController : ControllerBase
    {
        private readonly ApiContext _db;
        public CategoryController(ApiContext db)
        {
            _db = db;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _db.Categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _db.Categories.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            
        }
    }
}
