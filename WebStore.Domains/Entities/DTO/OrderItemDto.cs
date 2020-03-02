﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities.DTO
{
    public class OrderItemDto : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}
