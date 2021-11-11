using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Service.Identity
{
    public class MyUserManager :UserManager<User>
    {
        #region constructors and destructors

        public MyUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        #endregion

        #region methods
        //public static MyUserManager Create()
        //{
        //    UserValidator<User> oUserValidator = new UserValidator<User>();


        //    return new MyUserManager(new UserStore<User>(), new IdentityOptions(), new PasswordHasher<User>(), oUserValidator, new PasswordValidator<User>());
        //}

        #endregion
    }
}
