using MongoDB.Bson;

namespace Security.Design.Api.Events
{
    public interface IEvent
    {
        ObjectId? _id { get; }
        string TypeEvent { get; }
        Guid Guid { get; }
        DateTime Insert { get; }
        string HashEvent { get; }
        Guid CorrelationID { get; }
    }
}
