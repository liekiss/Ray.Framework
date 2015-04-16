using Application;
using Autofac;
using Autofac.Integration.Mvc;
using Infrastructure;
using Repositories;
using Repositories.EFRepositories;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Ray.FrameWork.App_Start
{
    public class Bootstartup
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            RegisterControllers(builder);
            RegisterApplication(builder);
            RegisterServices(builder);
            RegisterRepository(builder);
            RegisterDbContext(builder);
            //RegisterUnitOfWork(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var s = container.Resolve<DbContext>();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        private static void RegisterApplication(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IApplication).Assembly).Where(t => typeof(IApplication).IsAssignableFrom(t)).AsSelf().AsImplementedInterfaces();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IService).Assembly).Where(t => typeof(IService).IsAssignableFrom(t)).AsSelf().AsImplementedInterfaces();
        }

        private static void RegisterRepository(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(EFDbContext)).As(typeof(DbContext));
            //builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(EFRepository<>)).AsSelf().AsImplementedInterfaces();
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            //builder.RegisterType(typeof(EFRepositoryContext)).As(typeof(IRepositoryContext));
            builder.RegisterType(typeof(EFRepositoryContext)).AsImplementedInterfaces().AsSelf().SingleInstance();
        }

        //private static void RegisterUnitOfWork(ContainerBuilder builder)
        //{
        //    builder.RegisterType(typeof(EFRepositoryContext)).As(typeof(IUnitOfWork));
        //}
    }
}