using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.Domain.Entities.DTO.User
{
    public class ReplaceClaimsDto
    {
        public Identity.User User { get; set; }
        public Claim Claim { get; set; }
        public Claim NewClaim { get; set; }
    }
}
