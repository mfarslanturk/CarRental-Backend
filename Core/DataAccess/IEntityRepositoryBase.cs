using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepositoryBase<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
    }
}
