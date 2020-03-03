using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.DTO
{
    public class AddLoginDto
    {
        public Identity.User User { get; set; }
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
