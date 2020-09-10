using SuperMarket.DAL.Context;
using SuperMarket.DAL.Repository.Abstract;
using SuperMarket.DAL.Repository.BaseRepository.Concrete;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.DAL.Repository.Concrete
{
   public class CategoryRepoEF: EntityRepositoryEF<Category>, ICategoryRepo
    {
        public CategoryRepoEF(MyDbContext db) : base(db)
        {

        }
        public MyDbContext context_
        {
            get { return context as MyDbContext; }
        }
    }
}
