using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.Entities.DTO.User
{
    public class AddClaimsDto
    {
        public Identity.User User { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
