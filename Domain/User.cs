using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class User : IdentityUser<string>
    {
        #region Core
        //public string Name { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion

        #region Audit
        //public int? CreatedBy { get; set; }
        //[Column(TypeName = "datetime2(0)")]
        //public DateTime? CreatedOn { get; set; }
        ////public int? UpdatedBy { get; set; }
        //[Column(TypeName = "datetime2(0)")]
        //public DateTime? UpdatedOn { get; set; }
        //[DefaultValue("true")]
        //public bool Enabled { get; set; }
        #endregion

        #region NotMapped
        #endregion
    }
}
