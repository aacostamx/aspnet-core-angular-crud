using System;
using System.Linq;

namespace Lauderdale.Domain.Operator
{
    public class OperationResultException : Exception
    {
        public OperationResult result { get; private set; }

        public OperationResultException(OperationResult result)
            : base(String.Join("; ", result.Notes.Select(x => x.Title + " - " + x.Description)))
        {
            this.result = result;
        }
    }
}