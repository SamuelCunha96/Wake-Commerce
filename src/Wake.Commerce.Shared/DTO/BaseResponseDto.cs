namespace Wake.Commerce.Shared.DTO
{
    public class BaseResponseDto<TData> where TData : class
    {
        public BaseResponseDto() { }

        public BaseResponseDto(bool success, int statusCode, IEnumerable<string> messages)
        {
            this.Success = success;
            this.Messages = messages ?? new List<string>();
            this.StatusCode = statusCode;
        }

        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<string>? Messages { get; set; }
    }
}
