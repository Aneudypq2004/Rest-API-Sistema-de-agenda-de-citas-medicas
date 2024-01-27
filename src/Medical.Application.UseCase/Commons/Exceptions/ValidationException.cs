using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.Commons.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<BaseError>? Errors { get; }

        public ValidationException()
        {

            Errors = new List<BaseError>();
        }

        public ValidationException(IEnumerable<BaseError>? errors)
        {
           Errors = errors;
            
        }
    }

    
}
