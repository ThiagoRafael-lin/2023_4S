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
    public class UsersController : ControllerBase
    {
        private readonly IMongoCollection<Users> _users;

        public UsersController(MongoDBService mongoDbService)
        {
            _users = mongoDbService.GetDatabase.GetCollection<Users>("users");
        }

        [HttpGet]

        public async Task<ActionResult<List<Users>>> Get()
        {
            try
            {
                var users = await _users.Find(FilterDefinition<Users>.Empty).ToListAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users users)
        {
            try
            {
                await _users.InsertOneAsync(users);
                return StatusCode(201, users);
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
                var filter = Builders<Users>.Filter.Eq(p => p.Id, id);
                var result = await _users.DeleteOneAsync(filter);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Users usersToUpdate)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq("Id", ObjectId.Parse(id));
                var update = Builders<Users>.Update
                    .Set(p => p.Name, usersToUpdate.Name)
                    .Set(p => p.Email, usersToUpdate.Email)
                    .Set(p => p.Senha, usersToUpdate.Senha);

                var result = await _users.UpdateOneAsync(filter, update);

                return Ok($"Produto atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]

        public async Task<Users> GetById(string id)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq("Id", ObjectId.Parse(id));
                var users = await _users.Find(filter).FirstOrDefaultAsync();

                if (users == null)
                {
                    throw new Exception($"Produto com ID {id} não encontrado.");
                }

                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
