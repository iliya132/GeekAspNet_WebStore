﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Interfaces
{
    interface INamedEntity :IBaseEntity
    {
        public string Name { get; set; }
    }
}
