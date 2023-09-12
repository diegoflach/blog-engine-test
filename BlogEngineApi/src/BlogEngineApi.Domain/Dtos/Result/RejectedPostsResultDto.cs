namespace BlogEngineApi.Domain.Dtos.Result
{
    public class RejectedPostsResultDto
    {
        public IEnumerable<RejectPostDto> Posts { get; set; }
    }
}
