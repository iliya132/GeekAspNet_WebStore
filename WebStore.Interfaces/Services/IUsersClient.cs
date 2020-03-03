using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Interfaces.Services
{
    public interface IUsersClient : IUserRoleStore<User>,
    IUserClaimStore<User>,
    IUserPasswordStore<User>,
    IUserTwoFactorStore<User>,
    IUserEmailStore<User>,
    IUserPhoneNumberStore<User>,
    IUserLoginStore<User>,
    IUserLockoutStore<User>
    {
    }
}
