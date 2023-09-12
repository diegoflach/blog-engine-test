using BlogEngineApi.Domain.Dtos;

using System.ComponentModel.DataAnnotations;

namespace BlogEngineApi.Domain.Dto
{
    public class PostDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

        public string AuthorUsername { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
    }
}