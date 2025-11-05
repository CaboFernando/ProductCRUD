using System.Web.Http;
using System.Web.Http.Cors;
using ProductCRUD.Domain.Entities;
using ProductCRUD.Data.Repositories;

namespace ProductCRUD.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly ProductRepository _repository;

        public ProductsController()
        {
            _repository = new ProductRepository();
        }

        // GET api/products
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var products = _repository.GetAll();
            return Ok(products);
        }

        // GET api/products/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _repository.Create(product);
            return Created($"api/products/{created.Id}", created);
        }

        // PUT api/products/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            product.Id = id;
            var updated = _repository.Update(product);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE api/products/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (!result)
                return NotFound();

            return Ok();
        }
    }
}