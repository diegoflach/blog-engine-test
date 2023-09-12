using BlogEngineApi.Domain.Dto;
using BlogEngineApi.Domain.Dtos;
using BlogEngineApi.Domain.Dtos.Result;
using BlogEngineApi.Domain.Dtos.Set;

namespace BlogEngineApi.Application.Interfaces
{
    public interface IPostAppService
    {
        PostsResultDto GetAll(Guid? author = null);
        PostDto Set(SetPostDto postDto);
        void Submit(Guid postId);
        void Approve(Guid postId);
        void Reject(PostDto postDto);
        PostDto Comment(CommentDto commentDto);
    }
}
