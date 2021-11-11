using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class Role : IdentityRole
    {
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
