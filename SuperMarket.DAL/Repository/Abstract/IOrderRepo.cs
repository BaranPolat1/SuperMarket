using SuperMarket.DAL.Repository.BaseRepository.Abstract;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.DAL.Repository.Abstract
{
    public interface IOrderRepo: IEntityRepository<Order>
    {
        IList<Order> GetOrdersWithOrderDetails(int userId);
        Order GetOrderWithOrderDetails(int Id);
        Order GetLastOrder(int userId);
    }
}
