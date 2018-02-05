using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Simple.Cqrs.Context;

namespace Simple.Cqrs.Repository
{
    public class BaseRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
    {
        private readonly BaseDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }


        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();//.AsNoTracking() bunu kullanırsak performans artışı sağlayabiliriz
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbSet.Add(entity);

        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return;

            Delete(entity);
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

        }
        public void DetectUpdate(T entity)
        {
            _dbSet.Attach(entity);
            /* Now the entity framework will start tracking this object, 
any update to the values will be tracked and persisted on commit*/
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
