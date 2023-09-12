using Microsoft.AspNetCore.Identity;

namespace BlogEngineApi.Infra.Cc.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<IdentityUserRole<Guid>> Roles { get; } = new List<IdentityUserRole<Guid>>();
    }
}