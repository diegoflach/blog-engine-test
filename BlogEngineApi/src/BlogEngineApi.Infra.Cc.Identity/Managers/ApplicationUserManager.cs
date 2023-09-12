using BlogEngineApi.Infra.Cc.Identity.Context;
using BlogEngineApi.Infra.Cc.Identity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlogEngineApi.Infra.Cc.Identity.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly IdentityApplicationDbContext dbContext;

        public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger, 
            IdentityApplicationDbContext dbContext): base(store, optionsAccessor,passwordHasher,
            userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        { 
            this.dbContext = dbContext;
        }

        public ApplicationUser GetByEmail(string email)
        {
            return dbContext.ApplicationUsers.Include(u => u.Roles).FirstOrDefault(u => u.Email == email);
        }
    }
}