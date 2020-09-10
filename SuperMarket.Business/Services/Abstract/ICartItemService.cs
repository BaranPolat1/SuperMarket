using SuperMarket.Associate.DTO;
using SuperMarket.Associate.VM;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Abstract
{
    public interface ICartItemService
    {
        JsonCartItemVM AddCartItem(int cartId, int productId, string price);
        JsonCartItemVM DeleteCartItem(int cartId, int productId, int quantity,string type);
        IList<CartItemDTO> GetCartItems(int cartId);
        decimal GetTotalAmount(int cartId);

    }
}
