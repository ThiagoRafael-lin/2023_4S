using API_MongoDB.Domains;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDBService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);
                return StatusCode(201, product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
                var result = await _product.DeleteOneAsync(filter);
                return Ok(result);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> Update(string id, Product productToUpdate)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq("Id", ObjectId.Parse(id));
                var update = Builders<Product>.Update
                    .Set(p => p.Name, productToUpdate.Name)
                    .Set(p => p.Price, productToUpdate.Price);

                var result = await _product.UpdateOneAsync(filter, update);

                return Ok($"Produto atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]

        public async Task<Product> GetById(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq("Id", ObjectId.Parse(id));
                var product = await _product.Find(filter).FirstOrDefaultAsync();

                if (product == null)
                {
                    throw new Exception($"Produto com ID {id} não encontrado.");
                }

                return product;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
