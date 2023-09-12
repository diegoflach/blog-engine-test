using System.ComponentModel.DataAnnotations;

namespace BlogEngineApi.Domain.Dtos
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
    }
}