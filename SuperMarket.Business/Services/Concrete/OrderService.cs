using AutoMapper;
using Omu.ValueInjecter;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.ObjectMapping.ValueInjecter;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarket.Business.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork uow;
        private IMapper map;
        public OrderService(IUnitOfWork uow, IMapper map)
        {
            this.uow = uow;
            this.map = map;
        }


        public bool AddOrder(OrderDTO model, int userId)
        {
            bool lastOrderAdded = false;
            try
            {
                List<CartItem> cartItems = uow.CartItems.GetList(x => x.CartId == userId);
                Order order = map.Map<Order>(model);
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                order.AppUserId = userId;
                uow.Orders.Add(order);
                if (order.Id == 0)
                {
                    uow.SaveChange();
                    lastOrderAdded = true;
                }

                foreach (var item in cartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.Id;
                    orderDetail.ProductId = item.ProductId;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.UnitPrice = item.TotalAmount;
                    orderDetails.Add(orderDetail);
                }
                uow.OrderDetails.AddRange(orderDetails);
                uow.CartItems.RemoveAll(cartItems);
                uow.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                if (lastOrderAdded)
                {
                    Order order = uow.Orders.GetLastOrder(userId);
                    uow.Orders.Delete(order);
                    uow.SaveChange();
                }
                return false;
            }





        }

        public OrderDTO GetOrder(int Id)
        {
            try
            {
                Order order = uow.Orders.GetOrderWithOrderDetails(Id);
                OrderDTO model = map.Map<OrderDTO>(order);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IList<OrderDTO> GetOrders(int userId)
        {
            try
            {
                IList<Order> orders = uow.Orders.GetOrdersWithOrderDetails(userId);
                IList<OrderDTO> model = map.Map<IList<OrderDTO>>(orders);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
