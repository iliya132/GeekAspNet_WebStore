using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.DTO.User
{
    public class PasswordHashDto
    {
        public Identity.User User { get; set; }
        public string Hash { get; set; }
    }

}
