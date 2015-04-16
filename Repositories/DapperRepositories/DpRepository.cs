using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DapperRepositories
{
    public class DpRepository<TEntity> : IRepository<TEntity> where TEntity : class,IModel
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TEntity> FindAll(Func<TEntity, bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}
