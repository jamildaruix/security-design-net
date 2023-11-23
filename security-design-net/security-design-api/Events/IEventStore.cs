namespace Security.Design.Api.Events
{
    public interface IEventStore
    {
        void AdicionarEvento<T>(T evento) where T : IEvent;
        T ObterEventoPorIdModel<T>(int idModel) where T : IEvent;
    }
}
