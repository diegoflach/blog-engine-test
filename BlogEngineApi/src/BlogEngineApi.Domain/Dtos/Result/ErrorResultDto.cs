namespace BlogEngineApi.Domain.Dtos.Result
{
    public class ErrorResultDto
    {
        public int StatusCode { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }

        public ErrorResultDto(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessages = new List<string> { errorMessage };
        }

        public ErrorResultDto(int statusCode, IEnumerable<string> errorMessages)
        {
            StatusCode = statusCode;
            ErrorMessages = errorMessages;
        }
    }
}