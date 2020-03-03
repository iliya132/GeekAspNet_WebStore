using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.Domain.Entities.DTO.User
{
    public class RemoveClaimsDto
    {
        public Identity.User User { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
