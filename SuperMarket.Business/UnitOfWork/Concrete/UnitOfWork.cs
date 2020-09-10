using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SuperMarket.Associate.ClientInfo;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.Core.Entity;
using SuperMarket.DAL.Context;
using SuperMarket.DAL.Repository.Abstract;
using SuperMarket.DAL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace SuperMarket.Business.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext db;
        public UnitOfWork(MyDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException("db can not be null");
        }
        private IAppUserRepo _user;
        public IAppUserRepo AppUsers
        {
            get { return _user ?? (_user = new AppUserRepoEF(db)); }
        }

        private ICategoryRepo _category;
        public ICategoryRepo Categories
        {
            get { return _category ?? (_category = new CategoryRepoEF(db)); }
        }

        private IProductRepo _product;
        public IProductRepo Products
        {
            get { return _product ?? (_product = new ProductRepoEF(db)); }
        }

        private ICartRepo _cart;
        public ICartRepo Carts
        {
            get { return _cart ?? (_cart = new CartRepoEF(db)); }
        }

        private ICartItemRepo _cartItem;
        public ICartItemRepo CartItems
        {
            get { return _cartItem ?? (_cartItem = new CartItemRepoEF(db)); }
        }

        private IOrderRepo _order;
        public IOrderRepo Orders
        {
            get { return _order ?? (_order = new OrderRepoEF(db)); }
        }

        private IOrderDetailRepo _orderDetail;
        public IOrderDetailRepo OrderDetails
        {
            get { return _orderDetail ?? (_orderDetail = new OrderDetailRepoEF(db)); }
        }




        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        public void SaveChange()
        {

            try
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        string path = Directory.GetCurrentDirectory() + @"\\Logs\\Log.txt";
                        System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
                        file.Write("Date:" + DateTime.Now.ToString() + " - " + "Error:" + ex.Message + "\n");
                        file.Close();
                        transaction.Rollback();
                        throw;

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
