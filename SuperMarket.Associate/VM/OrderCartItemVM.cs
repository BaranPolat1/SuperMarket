using SuperMarket.Associate.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Associate.VM
{
    public class OrderCartItemVM
    {
        public OrderDTO Order { get; set; }
        public IList<CartItemDTO> CartItems { get; set; }
    }
}
