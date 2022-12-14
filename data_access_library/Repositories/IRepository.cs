using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace data_access_library.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity,
           bool>> filter,
           Func<IQueryable<TEntity>,
           IOrderedQueryable<TEntity>> orderBy,
           string includeProperties);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Save();
    }
}
