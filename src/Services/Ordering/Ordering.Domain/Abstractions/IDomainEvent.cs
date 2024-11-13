using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent:INotification //to alert MediatR event dispatch
    {
        Guid EventId => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName!;
    }
}
