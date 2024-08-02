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
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;

        public ClientController (MongoDBService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
        }

        [HttpGet]

        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var client = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            try
            {
                await _client.InsertOneAsync(client);
                return StatusCode(201, client);
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
                var filter = Builders<Client>.Filter.Eq(p => p.Id, id);
                var result = await _client.DeleteOneAsync(filter);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Client clientToUpdate)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq("Id", ObjectId.Parse(id));
                var update = Builders<Client>.Update
                    .Set(p => p.UserID, clientToUpdate.UserID)
                    .Set(p => p.Cpf, clientToUpdate.Cpf)
                    .Set(p => p.Phone, clientToUpdate.Phone)
                    .Set(p => p.Address, clientToUpdate.Address);

                var result = await _client.UpdateOneAsync(filter, update);

                return Ok($"Produto atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]

        public async Task<Client> GetById(string id)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq("Id", ObjectId.Parse(id));
                var client = await _client.Find(filter).FirstOrDefaultAsync();

                if (client == null)
                {
                    throw new Exception($"Produto com ID {id} não encontrado.");
                }

                return client;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
