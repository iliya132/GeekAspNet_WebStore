using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.DTO.User
{
    public class SetLockoutDto
    {
        public Identity.User User { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
