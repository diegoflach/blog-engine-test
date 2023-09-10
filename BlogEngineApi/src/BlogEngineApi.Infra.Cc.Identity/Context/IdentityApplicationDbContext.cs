using BlogEngineApi.Infra.Cc.Identity.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogEngineApi.Infra.Cc.Identity.Context
{
    public sealed class IdentityApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfigurationRoot configuration;

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public IdentityApplicationDbContext()
        {
        }

        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options)
        {
        }

        public IdentityApplicationDbContext(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        //Code below is necessary for Entity Framework Core tools usage
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=localhost;database=BlogEngine;trusted_connection=true;");
        //}
    }
}