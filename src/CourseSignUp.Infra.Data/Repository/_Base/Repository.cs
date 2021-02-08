using System;
using System.Linq;
using CourseSignUp.Domain.Interface.Repository;
using CourseSignUp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseSignUp.Infra.Data.Repository._Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CourseSignUpContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(CourseSignUpContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var dbSet = DbSet.Add(obj);
            return dbSet.Entity;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Update(TEntity obj)
        {
            Db.ChangeTracker.AutoDetectChangesEnabled = false;
            var dbset = DbSet.Update(obj);
            return dbset.Entity;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
