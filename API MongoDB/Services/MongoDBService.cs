using Microsoft.AspNetCore.Http.Connections;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class MongoDBService
    {
        /// <summary>
        /// Armazenar a configuração da aplicação
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Armazena uma refêrencia ao MongoDB 
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Cont[em a configuração necessária para acesso ao MongoDb
        /// </summary>
        /// <param name="configuration">Objeto contendo toda a configuração da aplicação</param>
        public MongoDBService(IConfiguration configuration)
        {
            //atribui a configuração recebida em _configuration
            _configuration = configuration;

            //Acessa a string de conexão
            var connectionString = "mongodb://localhost:27017/ProductDatabase_Tarde";
            //var connectionString = _configuration.GetConnectionString("DbConnection");

            //Transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um client
            var mongoClient = new MongoClient(mongoUrl);

            //Obtém a refêrencia ao MongoDB
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Propriedade para acessa o bd => retorna os dados em _database
        /// </summary>
        public IMongoDatabase GetDatabase => _database;

    }
}
