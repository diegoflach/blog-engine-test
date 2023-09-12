using BlogEngineApi.Domain.Statics;
using BlogEngineApi.Infra.Cc.Identity.Models;

namespace BlogEngineApi.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public string Status { get; private set; }
        public bool Locked { get; private set; }
        public string RejectReason { get; private set; }
        public Guid ApprovedById { get; private set; }
        public Guid AuthorId { get; private set; }

        public virtual ApplicationUser ApprovedBy { get; private set; }
        public virtual ApplicationUser Author { get; private set; }

        public virtual ICollection<Comment> Comments { get; private set; }


        public Post()
        {
            
        }

        public Post(string title, string content, Guid authorId )
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
            Status = PostStatus.PendingSubmit;
        }

        //TODO: Use Specification Pattern to all validations
        //TODO: Use Domain Notification Pattern instead of throwing exceptions
        public void Submit(Guid writerId)
        {
            if (AuthorId != writerId)
            {
                throw new Exception(Message.InvalidPostAuthor);
            }

            if (Status != PostStatus.PendingSubmit && Status != PostStatus.Rejected)
            {
                throw new Exception(Message.InvalidPostStatus);
            }

            Status = PostStatus.PendingApproval;
            Locked = true;
        }

        public void Approve(Guid editorId)
        {
            if(Status != PostStatus.PendingApproval)
            {
                throw new Exception(Message.InvalidPostStatus);
            }

            //if(approver.Roles.Any(r => r.))

            ApprovedById = editorId;
            PublishedDate = DateTime.Now;
            Status = PostStatus.Published;
            Locked = true;
        }

        
        public void Reject(string reason)
        {
            if (Status != PostStatus.PendingApproval)
            {
                throw new Exception(Message.InvalidPostStatus);
            }

            //if(approver.Roles.Any(r => r.))

            RejectReason = reason;
            Status = PostStatus.Rejected;
            Locked = false;
        }

        public void Edit(Guid writerId, string title, string content)
        {
            if (AuthorId != writerId)
            {
                throw new Exception(Message.InvalidPostAuthor);
            }

            if (Locked)
            {
                throw new Exception(Message.InvalidPostStatus);
            }

            Title = title;
            Content = content;
        }
    }
}
