using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;


namespace Repositories.EFRepositories
{
    public class EFRepositoryContext : IRepositoryContext
    {
        DbContext _dbContext;

        public EFRepositoryContext(DbContext db)
        {
            _dbContext = db;
        }


        object sync = new object();

       

        public IEnumerable<TEntity> Query<TEntity>() where TEntity : class, Domain.IModel
        {
            return _dbContext.Set<TEntity>().ToList();
        }


        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class, Domain.IModel
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Added;
            IsCommit = false;
        }

        public void RegisterModified<TEntity>(TEntity entity) where TEntity : class, Domain.IModel
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            IsCommit = false;
        }

        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, Domain.IModel
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
            IsCommit = false;
        }

        public int Commit()
        {
            if (!IsCommit)
            {
                lock (sync)
                {
                    try
                    {
                        IsCommit = true;
                        return _dbContext.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var eve in ex.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }
            }
            return 0;
        }

        public void Rollback()
        {
            IsCommit = false;
        }

        public bool IsCommit
        {
            get;
            set;
        }


    }
}
