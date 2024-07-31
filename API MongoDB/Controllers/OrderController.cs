using API_MongoDB.Domains;
using API_MongoDB.Services;
using API_MongoDB.ViewModel;
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
        private readonly IMongoCollection<Order>? _order;
        private readonly IMongoCollection<Client>? _client;
        private readonly IMongoCollection<Product>? _product;

        public OrderController(MongoDBService mongoDbService)
        {
            _order = mongoDbService.GetDatabase?.GetCollection<Order>("order");
            _client = mongoDbService.GetDatabase?.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase?.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                
                foreach (var order in orders)
                {
                    if (order.ProductId != null)
                    {
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        order.Products = await _product.Find(filter).ToListAsync();

                    }
                    if (order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                    }

                }
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new();
                order.Id = orderViewModel.Id;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                //var filter = Builders<Product>.Filter.In(p => p.Id, productIds.Select(id => ObjectId.Parse(id)));

                // Realizar a busca na coleção de produtos com o filtro aplicado
                //List<Product> products = await _product.Find(filter).ToListAsync();

                if (client == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                //order.Client = client;

                await _order!.InsertOneAsync(order);

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
                //var filter = Builders<Order>.Filter.Eq("Id", ObjectId.Parse(id));
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();
                
                    if (order.ProductId != null)
                    {
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        order.Products = await _product.Find(filter).ToListAsync();

                    }
                    if (order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
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
