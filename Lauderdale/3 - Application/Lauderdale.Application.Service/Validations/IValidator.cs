namespace Lauderdale.Application.Service.Interface
{
    public interface IValidator<T>
    {
        void Validate(T validable);
    }
}
