using System;
using System.Linq;
using System.Linq.Expressions;

namespace CourseSignUp.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
