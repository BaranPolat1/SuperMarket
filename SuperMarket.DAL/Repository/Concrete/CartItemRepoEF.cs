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
    public class CartItemRepoEF: EntityRepositoryEF<CartItem>, ICartItemRepo
    {
        public CartItemRepoEF(MyDbContext db) : base(db)
        {

        }
        public MyDbContext context_
        {
            get { return context as MyDbContext; }
        }

        public IList<CartItem> GetCartItemsWithProduct(int cartId)
        {
            IList<CartItem> cartItems = context_.CartItems.Include(x => x.Product).Where(x => x.CartId == cartId).ToList();
            return cartItems;
        }
    }
}
