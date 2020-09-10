using SuperMarket.Associate.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Abstract
{
    public interface IOrderService
    {
        bool AddOrder(OrderDTO model,int userId);
        IList<OrderDTO> GetOrders(int userId);
        OrderDTO GetOrder(int Id);
       
    }
}
