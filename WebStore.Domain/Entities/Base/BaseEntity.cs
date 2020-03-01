using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    public abstract class BaseEntity :IBaseEntity
    {
        public int Id { get; set; }
    }
}
