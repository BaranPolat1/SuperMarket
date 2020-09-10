using SuperMarket.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.UnitOfWork.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IAppUserRepo AppUsers { get; }
        ICategoryRepo Categories { get; }
        IProductRepo Products { get; }
        ICartRepo Carts { get; }
        ICartItemRepo CartItems { get; }
        IOrderRepo Orders { get; }
        IOrderDetailRepo OrderDetails { get; }
      
        void SaveChange();
    }
}
