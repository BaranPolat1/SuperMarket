using Microsoft.EntityFrameworkCore;
using SuperMarket.DAL.Context;
using SuperMarket.DAL.Repository.BaseRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAL.Repository.BaseRepository.Concrete
{
    public class EntityRepositoryEF<T> : IEntityRepository<T> where T : class
    {
        protected readonly DbSet<T> table;
        protected readonly MyDbContext context;

        public EntityRepositoryEF(MyDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public void Add(T item)
        {
            var addedItem = context.Entry(item);
            addedItem.State = EntityState.Added;

        }

        public void AddRange(List<T> data)
        {
            table.AddRange(data);

        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public void Delete(T item)
        {
            var deletedEntity = context.Entry(item);
            deletedEntity.State = EntityState.Deleted;
        }

        public void Delete(int Id)
        {
            var item = table.Find(Id);
            var deletedEntity = context.Entry(item);
            deletedEntity.State = EntityState.Deleted;

        }

        public T Get(Expression<Func<T, bool>> exp)
        {
            return table.FirstOrDefault(exp);
        }

        public List<T> GetList(Expression<Func<T, bool>> exp = null)
        {
            return exp == null ? table.ToList() : table.Where(exp).ToList();
        }

        public void RemoveAll(List<T> data)
        {

            table.RemoveRange(data);

        }

        public void Update(T item)
        {
            var updateItem = context.Entry(item);
            updateItem.State = EntityState.Modified;
        }

        public void UpdateAll(List<T> data)
        {
            foreach (var item in data)
            {
                var updateItem = context.Entry(item);
                updateItem.State = EntityState.Modified;
            }
        }
    }
}
