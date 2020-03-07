using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.Entities.DTO
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

}
