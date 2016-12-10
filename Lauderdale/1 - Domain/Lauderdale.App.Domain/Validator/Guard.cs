using Lauderdale.Domain.Operator;

namespace Lauderdale.App.Domain.Validator
{
    public class Guard
    {
        public static void AssertIsSuccess(OperationResult result)
        {
            if (!result.IsSuccess)
                throw new OperationResultException(result);
        }

        public static void AssertIsNotEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new OperationResultException(OperationResult.Alert("Ops!", message, NoteType.warning));
        }
    }
}
