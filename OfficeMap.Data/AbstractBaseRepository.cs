using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OfficeMap.Data
{
    public abstract class AbstractBaseRepository<TEntity, TIdentity> where TEntity : class
    {
        internal DbContextOptions Options { get; }

        protected AbstractBaseRepository(DbContextOptions options)
        {
            Options = options;
        }

        public virtual TEntity GetById(TIdentity id)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public virtual IList<TEntity> Get()
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public virtual void Add(TEntity entity)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public virtual void Remove(TEntity entity)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }

        public virtual void Remove(int id)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                db.Set<TEntity>().Remove(db.Set<TEntity>().Find(id));
                db.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                db.Set<TEntity>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
