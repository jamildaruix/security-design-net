using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using SharpCompress.Common;

namespace Security.Design.Api.Events
{
    public interface IEvent
    {
        ObjectId? _id { get; }
        string TypeEvent { get; }
        Guid Guid { get; }
    }

    public record BuyTicketAirfaceVersionOneEvent : IEvent
    {
        public BuyTicketAirfaceVersionOneEvent(string destino, decimal valor)
        {
            _id = ObjectId.GenerateNewId();
            Destino = destino;
            Valor = valor;
        }

        [BsonElement("TypeEvent")]
        public string TypeEvent => nameof(BuyTicketAirfaceVersionOneEvent);

        [BsonElement("Guid")]
        public Guid Guid => Guid.NewGuid();

        [BsonElement("Destino")]
        public string Destino { get; init; }

        [BsonElement("Valor")]
        public decimal Valor { get; init; }

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId? _id { get; set; }
    }

    public record BuyTicketAirfaceVersionTwoEvent : IEvent
    {
        public BuyTicketAirfaceVersionTwoEvent(string origem, string destino, decimal valor, DateTime validade)
        {
            _id = ObjectId.GenerateNewId();
            Origem = origem;
            Destino = destino;
            Valor = valor;
            ValidadeBilhere = validade;
        }

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId? _id { get; init; }

        [BsonElement("TypeEvent")]
        public string TypeEvent => nameof(BuyTicketAirfaceVersionTwoEvent);

        [BsonElement("Guid")]
        public Guid Guid => Guid.NewGuid();


        [BsonElement("Origem")]
        public string Origem { get; init; }

        [BsonElement("Destino")]
        public string Destino { get; init; }

        [BsonElement("Destino")]
        public decimal Valor { get; init; }

        [BsonElement("Destino")]
        public DateTime ValidadeBilhere { get; init; }
    }

    public interface IEventStore
    {
        void AdicionarEvento<T>(T evento) where T : IEvent;
        void ProcessarEventos<T>(Action<T> processador) where T : IEvent;
    }

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


        public void AdicionarEvento<T>(T evento) where T : IEvent
        {
            _events = database.GetCollection<BsonDocument>(collectionName);
            _events.InsertOne(evento.ToBsonDocument());
        }


        public void ProcessarEventos<T>(Action<T> processador) where T : IEvent
        {
            var eventos = _events.Find(Builders<BsonDocument>.Filter.Empty).ToList();
            foreach (var evento in eventos)
            {
                if (evento is T eventoT)
                {
                    processador(eventoT);
                }
            }
        }
    }
}
