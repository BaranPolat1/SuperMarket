using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAL.Repository.BaseRepository.Abstract
{
    public interface IEntityRepository<T>
    {
        bool Any(Expression<Func<T, bool>> exp);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int Id);
        void RemoveAll(List<T> data);
        void AddRange(List<T> data);
        void UpdateAll(List<T> data);
        T Get(Expression<Func<T, bool>> exp);
        List<T> GetList(Expression<Func<T, bool>> exp = null);
       
    }
}
