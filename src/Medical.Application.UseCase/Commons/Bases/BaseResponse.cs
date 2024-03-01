namespace Medical.Application.UseCase.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        
        public T? Data { get; set; }

        public string? Message { get; set; }

        public ICollection<BaseError>? Errors { get; set; }
    }
}
