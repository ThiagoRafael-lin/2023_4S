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
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;

        public OrderController(MongoDBService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var order = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                await _order.InsertOneAsync(order);
                return StatusCode(201, order);
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
                var filter = Builders<Order>.Filter.Eq(p => p.Id, id);
                var result = await _order.DeleteOneAsync(filter);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> Update(string id, Order orderToUpdate)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq("Id", ObjectId.Parse(id));
                var update = Builders<Order>.Update
                    .Set(p => p.Date, orderToUpdate.Date)
                    .Set(p => p.Status, orderToUpdate.Status)
                    .Set(p => p.Products, orderToUpdate.Products)
                    .Set(p => p.Client, orderToUpdate.Client);
                    
                var result = await _order.UpdateOneAsync(filter, update);

                return Ok($"Produto atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]

        public async Task<Order> GetById(string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq("Id", ObjectId.Parse(id));
                var order = await _order.Find(filter).FirstOrDefaultAsync();

                if (order == null)
                {
                    throw new Exception($"Produto com ID {id} não encontrado.");
                }

                return order;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
