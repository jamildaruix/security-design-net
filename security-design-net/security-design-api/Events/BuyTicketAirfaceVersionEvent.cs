using Microsoft.Extensions.WebEncoders.Testing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Text.Json;

namespace Security.Design.Api.Events
{
    public class BuyTicketAirfaceVersionEvent : IEventStore
    {
        private readonly IMongoDatabase database;
        private IMongoCollection<BsonDocument> _events;
        private const string collectionName = "example-tdc";

        public BuyTicketAirfaceVersionEvent()
        {
            var client = new MongoClient("mongodb://root:password@localhost:27017");
            database = client.GetDatabase("test");
        }

        private IMongoCollection<BsonDocument> ObterColecao() => database.GetCollection<BsonDocument>(collectionName);

        public void AdicionarEvento<T>(T evento) where T : IEvent
        {
            _events = ObterColecao();
            _events.InsertOne(evento.ToBsonDocument());
        }

        public T ObterEventoPorIdModel<T>(int idModel) where T : IEvent
        {
            _events = ObterColecao();
            var filter = Builders<BsonDocument>.Filter.Eq("IdModel", idModel);

            var bsonDocument = _events.Find(filter).FirstOrDefault();
            return BsonSerializer.Deserialize<T>(bsonDocument);
        }

    }
}
