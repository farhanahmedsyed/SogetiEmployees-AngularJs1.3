using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDAL
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity newEntity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<System.Linq.IQueryable<TEntity>,
            System.Linq.IOrderedQueryable<TEntity>> orderBy = null, int? take = null, string includeProperties = "", bool tracking = true);
        TEntity GetByID(object id);
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        void Insert(TEntity entity);
        void SetEntityState(TEntity entity, System.Data.Entity.EntityState entityState);
        void Update(TEntity entityToUpdate);
        IQueryable<TEntity> DataSet();
        TEntity FindById(int id);
        IQueryable<TEntity> FindWhere(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll();

    }
}
