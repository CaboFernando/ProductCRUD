using System.Web.Http;
using System.Web.Http.Cors;
using ProductCRUD.API.Models;
using ProductCRUD.API.Services;

namespace ProductCRUD.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController()
        {
            _service = new ProductService();
        }

        // GET api/products
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        // GET api/products/5
        [HttpGet]
        [Route("{id:int}", Name = "GetProductById")]
        public IHttpActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _service.Create(dto);
            return CreatedAtRoute("GetProductById", new { id = created.Id }, created);
        }

        // PUT api/products/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] ProductUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _service.Update(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE api/products/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result)
                return NotFound();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var disposable = _service as System.IDisposable;
                if (disposable != null) disposable.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}