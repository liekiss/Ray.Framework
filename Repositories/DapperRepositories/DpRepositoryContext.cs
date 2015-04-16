using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Dapper;
using Domain;
using Infrastructure;

namespace Repositories.DapperRepositories
{
    public class DpRepositoryContext : IRepositoryContext
    {
        private SpinLock spinlock = new SpinLock(true);

        private Queue<Command> currentQueue;
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class, Domain.IModel
        {
            //using (var cnn = DpDbConnection.GetDbConnection())
            //{
            //    cnn.Execute()
            //}
            currentQueue.Enqueue(new Command()
            {
                Model = entity,
                Operation = DataBaseOperation.Insert,
                SqlName = entity.GetType().Name + DataBaseOperation.Insert.ToString()
            });
        }

        public void RegisterModified<TEntity>(TEntity entity) where TEntity : class, Domain.IModel
        {
            throw new NotImplementedException();
        }

        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, Domain.IModel
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
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

        public IEnumerable<TEntity> Query<TEntity>() where TEntity : class, Domain.IModel
        {
            throw new NotImplementedException();
        }

        private class Command
        {
            public DataBaseOperation Operation { get; set; }

            public string SqlName { get; set; }

            public IModel Model { get; set; }
        }
    }
}
