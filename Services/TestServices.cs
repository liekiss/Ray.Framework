using Domain.Models;
using Infrastructure;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TestServices : IService
    {
        IUnitOfWork _unitOfWork;
        IRepository<Students> _stuRepository;
        public TestServices(IUnitOfWork unitOfWork, IRepository<Students> stuRepository)
        {
            _unitOfWork = unitOfWork;
            _stuRepository = stuRepository;
        }

        public IList<Students> GetAllStudents()
        {
            return _stuRepository.FindAll().ToList();
        }

        public int AddStudents(Students stu)
        {
            _stuRepository.Add(stu);
            return _unitOfWork.Commit();
        }
    }
}
