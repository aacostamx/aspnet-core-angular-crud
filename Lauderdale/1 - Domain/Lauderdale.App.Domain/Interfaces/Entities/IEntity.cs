using Lauderdale.Domain.Operator;

namespace Lauderdale.Domain.Interfaces.Entities
{
    public interface IEntity
    {
        bool IsNew { get; }
        string Id { get; }
        OperationResult Validate();
    }
}
