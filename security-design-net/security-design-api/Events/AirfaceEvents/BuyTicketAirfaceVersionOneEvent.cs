using AutoMapper.Internal.Mappers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Security.Cryptography;
using System.Text;

namespace Security.Design.Api.Events.AirfaceEvents
{
    public record BuyTicketAirfaceVersionOneEvent : IEvent
    {
        public BuyTicketAirfaceVersionOneEvent(int idModel, string destino, decimal valor, Guid correlationID)
        {
            IdModel = idModel;
            _id = ObjectId.GenerateNewId();
            Destino = destino;
            Valor = valor;
            CorrelationID = correlationID;
        }

        [BsonElement("IdModel")]
        public int IdModel { get; init; }

        [BsonElement("TypeEvent")]
        public string TypeEvent => nameof(BuyTicketAirfaceVersionOneEvent);

        [BsonElement("Guid")]
        public Guid Guid => Guid.NewGuid();

        [BsonElement("Destino")]
        public string Destino { get; init; }

        [BsonElement("Valor")]
        public decimal Valor { get; init; }

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId? _id { get; init; }

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
                string dataToHash = $"{CorrelationID}-{IdModel}-{Destino}-{Valor}";
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
