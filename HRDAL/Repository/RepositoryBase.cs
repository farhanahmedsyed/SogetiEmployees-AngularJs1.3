using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HRDAL
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected SogetiEmployeesDBContext Context
        {
            get { return (SogetiEmployeesDBContext)this.UnitOfWork; }
        }

        protected DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            this.UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<TEntity> DataSet()
        {
            return DbSet;
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public virtual IQueryable<TEntity> FindWhere(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DataSet().Where(predicate).AsNoTracking();
        }

        public virtual TEntity FindById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(TEntity newEntity)
        {
            DbSet.Add(newEntity);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? take = null, string includeProperties = "", bool tracking = true)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (take.HasValue)
            {
                query = query.Take((int)take);
                //return query.Take((int)take).AsNoTracking().ToList();
            }

            if (!tracking)
            {
                return query.AsNoTracking().ToList();
            }
            return query.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            //If not found, null is returned
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return DbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual void SetEntityState(TEntity entity, System.Data.Entity.EntityState entityState)
        {
            Context.Entry(entity).State = entityState;
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
