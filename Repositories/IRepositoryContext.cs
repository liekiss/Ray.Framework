using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepositoryContext : IUnitOfWork
    {
        IEnumerable<TEntity> Query<TEntity>() where TEntity : class, IModel;

        void RegisterNew<TEntity>(TEntity entity) where TEntity : class,IModel;

        void RegisterModified<TEntity>(TEntity entity) where TEntity : class,IModel;

        void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class,IModel;
    }
}
