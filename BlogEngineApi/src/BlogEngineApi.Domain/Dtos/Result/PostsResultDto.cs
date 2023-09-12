using BlogEngineApi.Domain.Dto;

namespace BlogEngineApi.Domain.Dtos.Result
{
    public class PostsResultDto
    {
        public IEnumerable<PostDto> Posts { get; set; }
    }
}
