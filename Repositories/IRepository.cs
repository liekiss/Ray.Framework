using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    public interface IRepository<TEntity> where TEntity : class,IModel
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        TEntity FindById(int id);

        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindAll(Func<TEntity, bool> expression);
    }
}
