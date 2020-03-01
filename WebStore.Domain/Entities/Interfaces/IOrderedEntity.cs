using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Interfaces
{
    public interface IOrderedEntity
    {
        public int Order { get; set; }
    }
}
