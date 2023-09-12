using System.ComponentModel.DataAnnotations;

namespace BlogEngineApi.Domain.Dtos.Set
{
    public class SetPostDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
    }
}