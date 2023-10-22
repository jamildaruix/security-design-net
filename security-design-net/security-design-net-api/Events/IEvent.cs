using MongoDB.Driver;

namespace Security.Design.Net.Api.Events
{
    public interface IEvent
    {
        string TypeEvent { get; }
        Guid Guid { get; }
        int Id { get; }
    }

    public record BuyTicketAirfaceVersionOneEvent : IEvent
    {
        public BuyTicketAirfaceVersionOneEvent(int id, string destino, decimal valor)
        {
            Id = id;
            Destino = destino;
            Valor = valor;
        }

        public string TypeEvent => nameof(BuyTicketAirfaceVersionOneEvent);

        public Guid Guid => Guid.NewGuid();

        public int Id { get; }
        public string Destino { get; }
        public decimal Valor { get; }
    }

    public record BuyTicketAirfaceVersionTwoEvent : IEvent
    {
        public BuyTicketAirfaceVersionTwoEvent(int id, string origem, string destino, decimal valor, DateTime validade)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
            ValidadeBilhere = validade;
        }

        public string TypeEvent => nameof(BuyTicketAirfaceVersionTwoEvent);

        public Guid Guid => Guid.NewGuid();

        public int Id { get; }
        public string Origem { get; set; }
        public string Destino { get; }
        public decimal Valor { get; }
        public DateTime ValidadeBilhere { get; set; }
    }

    public interface IEventStore
    {
        void AdicionarEvento<T>(T evento) where T : IEvent;
        void ProcessarEventos<T>(Action<T> processador) where T : IEvent;
    }

    public class BuyTicketAirfaceVersionEvent : IEventStore
    {
        private readonly IMongoCollection<IEvent> _events;

        public BuyTicketAirfaceVersionEvent()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("example-tdc");
            _events = database.GetCollection<IEvent>("pyament-airfare");
        }

        public void AdicionarEvento<T>(T evento) where T : IEvent
        {
            _events.InsertOne(evento);
        }

        public void ProcessarEventos<T>(Action<T> processador) where T : IEvent
        {
            var eventos = _events.Find(Builders<IEvent>.Filter.Empty).ToList();
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
