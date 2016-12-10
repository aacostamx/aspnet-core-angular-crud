using System;
using Lauderdale.Domain.Interfaces.Entities;
using Lauderdale.Domain.Operator;

namespace Lauderdale.Domain.Entities
{
    public class City : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public bool IsNew => String.IsNullOrWhiteSpace(Id);
        public OperationResult Validate()
        {
            var result = new OperationResult();

            if (String.IsNullOrWhiteSpace(Name))
                result.Warn("The city name is required.");

            if (Population <= 0)
                result.Warn("The city population must be bigger than 0.");

            return result;
        }
    }
}
