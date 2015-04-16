using Domain.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TestApplication : IApplication
    {
        TestServices _service;
        public TestApplication(TestServices service)
        {
            _service = service;
        }

        public int AddStudent(Students entity)
        {
            return _service.AddStudents(entity);
        }

        public IList<Students> GetAllStudents()
        {
            return _service.GetAllStudents();
        }
    }
}
