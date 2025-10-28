using CodeFirstApproach_EFCORE.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirstApproach_EFCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductOperations _operations;
        public ProductsController(IProductOperations operations)
        {
            _operations = operations; 
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _operations.GetAllProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product GetAll(int id)
        {
            return _operations.GetProductByID(id);
        }
        [HttpGet("GetProductsByCatID/{id}")]
        public List<Product> GetById(int id)
        { 
            return _operations.GetAllProductByCategoryID(id);   
        }


        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _operations.InsertProduct(value);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            _operations.UpdateProduct(id, value);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _operations.DeleteProduct(id);
        }
    }
}
