using MongoDB.Bson;
using MongoDB.Driver;
using ProjetoGraacc.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoGraacc.Services
{
    public class EditalMongoService
    {
        private readonly IMongoCollection<EditalMongo> _editaisMongo;

        public EditalMongoService(IEditalstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _editaisMongo = database.GetCollection<EditalMongo>(settings.EditaisCollectionName);
        }

        public List<EditalMongo> Get() => 
            _editaisMongo.Find(new BsonDocument()).ToList();
    }
}