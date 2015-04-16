using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using Repositories;
using Domain.Models;
using Repositories.EFRepositories;

namespace InsertTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRepository<Students> repository = new EFRepository<Students>();
            IRepository<Students> _stuRepository = new EFRepository<Students>();
        }
    }
}
