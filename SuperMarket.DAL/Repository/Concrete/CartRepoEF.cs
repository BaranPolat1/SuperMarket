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
    public class CartRepoEF: EntityRepositoryEF<Cart>, ICartRepo
    {
        public CartRepoEF(MyDbContext db) : base(db)
        {

        }
        public MyDbContext context_
        {
            get { return context as MyDbContext; }
        }

        public Cart GetWithCartItems(int Id)
        {
            var cart = context_.Carts.Include(x => x.CartItems).ThenInclude(b=>b.Product).FirstOrDefault(x => x.Id == Id);
            return cart;
        }
    }
}
