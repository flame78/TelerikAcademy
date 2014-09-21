using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Album> albums;

     //   public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            this.albums = new HashSet<Album>();
            return userIdentity;
        }

       // public virtual Artist Artist { get; set; }
    }
}
