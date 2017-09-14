using Fluxy.Core.Common;
using Fluxy.Data.ExtentedDTO;
using Fluxy.Data.Initializers;
using Fluxy.Data.Mappings;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Fluxy.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual PrivateMessagesExtend PrivateMessagesExtend { get; set; }
        public virtual UserProfileExtend UserProfileExtend { get; set; }
        public virtual PrivateVideoExtend PrivateVideoExtend { get; set; }
        public virtual VideoAttributesExtend VideoAttributesExtend { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class FluxyContext : IdentityDbContext<ApplicationUser>
    {

        public FluxyContext()
            : base("Name=FluxyContext")
        {
            Database.SetInitializer(new FluxyDBInitializer());
        }

        public static FluxyContext Create()
        {
            return new FluxyContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                      .Where(type => !String.IsNullOrEmpty(type.Namespace))
                      .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                          type.BaseType.GetGenericTypeDefinition() == typeof(FluxyEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                        .Where(x => x.Entity is IAuditableEntity
                            && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    IAuditableEntity auditableEntity = entry.Entity as IAuditableEntity;
                    IEntity<string> Entity = entry.Entity as IEntity<string>;
                    if (auditableEntity != null)
                    {
                        string identityName = Thread.CurrentPrincipal.Identity.Name;
                        DateTime now = DateTime.UtcNow;

                        if (entry.State == System.Data.Entity.EntityState.Added)
                        {
                            Entity.Id = Guid.NewGuid().ToString();
                            auditableEntity.CreatedBy = identityName;
                            auditableEntity.CreatedDate = now;
                        }
                        else
                        {
                            base.Entry(auditableEntity).Property(x => x.CreatedBy).IsModified = false;
                            base.Entry(auditableEntity).Property(x => x.CreatedDate).IsModified = false;
                        }

                        auditableEntity.UpdatedBy = identityName;
                        auditableEntity.UpdatedDate = now;
                    }
                }

                return base.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
