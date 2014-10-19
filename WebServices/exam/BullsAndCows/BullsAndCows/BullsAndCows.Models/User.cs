namespace BullsAndCows.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {

        private ICollection<Notifaction> notifactions;
 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            this.notifactions = new HashSet<Notifaction>();
            return userIdentity;
        }

        public int Wons { get; set; }

        public int Loses { get; set; }

        public virtual ICollection<Notifaction> Notifications { get; set; }

    }
}
