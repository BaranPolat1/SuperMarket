using Microsoft.EntityFrameworkCore;
using SuperMarket.DAL.Context;
using SuperMarket.DAL.Repository.Abstract;
using SuperMarket.DAL.Repository.BaseRepository.Concrete;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarket.DAL.Repository.Concrete
{
    public class OrderRepoEF : EntityRepositoryEF<Order>, IOrderRepo
    {
        public OrderRepoEF(MyDbContext db) : base(db)
        {

        }
        public MyDbContext context_
        {
            get { return context as MyDbContext; }
        }

        public Order GetLastOrder(int userId)
        {
          
            List<Order> orderList = context_.Orders.Where(x => x.AppUserId == userId).OrderByDescending(x=>x.CreatedDate).ToList();
            Order order = orderList[0];
            return order;
        }

        public IList<Order> GetOrdersWithOrderDetails(int userId)
        {
            IList<Order> orders = context_.Orders.AsNoTracking().Include(x => x.OrderDetails).Where(x => x.AppUserId == userId).ToList();
            return orders;
        }

        public Order GetOrderWithOrderDetails(int Id)
        {
            Order order = context_.Orders.AsNoTracking().Include(x => x.OrderDetails).ThenInclude(x=>x.Product).FirstOrDefault(x => x.Id == Id) ;
            return order;
        }
    }
}
