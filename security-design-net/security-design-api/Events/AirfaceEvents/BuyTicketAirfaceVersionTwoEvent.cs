using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Security.Cryptography;
using System.Text;

namespace Security.Design.Api.Events
{
    public record BuyTicketAirfaceVersionTwoEvent : IEvent
    {
        private readonly string hashOld;

        public BuyTicketAirfaceVersionTwoEvent(int idModel, string origem, string destino, decimal valor, DateTime validade, Guid correlationID, string hashOld)
        {
            _id = ObjectId.GenerateNewId();
            IdModel = idModel;
            Origem = origem;
            Destino = destino;
            Valor = valor;
            ValidadeBilhere = validade;
            CorrelationID = correlationID;
            this.hashOld = hashOld;
        }

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId? _id { get; init; }

        [BsonElement("IdModel")]
        public int IdModel { get; init; }

        [BsonElement("TypeEvent")]
        public string TypeEvent => nameof(BuyTicketAirfaceVersionTwoEvent);

        [BsonElement("Guid")]
        public Guid Guid => Guid.NewGuid();

        [BsonElement("Origem")]
        public string Origem { get; init; }

        [BsonElement("Destino")]
        public string Destino { get; init; }

        [BsonElement("Valor")]
        public decimal Valor { get; init; }

        [BsonElement("ValidadeBilhere")]
        public DateTime ValidadeBilhere { get; init; }

        [BsonElement("Insert")]
        public DateTime Insert => DateTime.Now;

        [BsonElement("CorrelationID")]
        public Guid CorrelationID { get; init; }


        [BsonElement("HashEvent")]
        public string HashEvent => CalculateHash();

        private string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string dataToHash = $"{CorrelationID}-{IdModel}-{Origem}-{Destino}-{Valor}-{ValidadeBilhere}-{hashOld}";
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
