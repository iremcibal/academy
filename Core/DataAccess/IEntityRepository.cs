using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null,
                              Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        T? Get(Expression<Func<T, bool>> predicate,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               bool enableTracking = true);
    }
}