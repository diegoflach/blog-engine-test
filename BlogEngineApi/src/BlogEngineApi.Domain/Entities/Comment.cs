using BlogEngineApi.Infra.Cc.Identity.Models;

namespace BlogEngineApi.Domain.Entities
{
    public class Comment : Entity
    {
        public string Message { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid PostId { get; private set; }

        public virtual ApplicationUser Author { get; private set; }
        public virtual Post Post { get; private set; }

        public Comment()
        {
            
        }

        public Comment(string message, Guid authorId, Guid postId)
        {
            Message = message;
            AuthorId = authorId;
            PostId = postId;
        }
    }
}
