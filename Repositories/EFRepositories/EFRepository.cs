using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFRepositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class,IModel
    {
        IRepositoryContext _efContext;
        public EFRepository(IRepositoryContext efContext)
        {
            this._efContext = efContext;
        }

        public void Add(TEntity entity)
        {
            _efContext.RegisterNew<TEntity>(entity);
        }

        public void Remove(TEntity entity)
        {
            _efContext.RegisterDeleted<TEntity>(entity);
        }

        public void Update(TEntity entity)
        {
            _efContext.RegisterModified<TEntity>(entity);
        }

        public TEntity FindById(int id)
        {
            return _efContext.Query<TEntity>().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _efContext.Query<TEntity>();
        }

        public IEnumerable<TEntity> FindAll(Func<TEntity, bool> expression)
        {
            return _efContext.Query<TEntity>().Where(expression);
        }
    }
}
