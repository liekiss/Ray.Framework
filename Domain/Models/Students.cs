using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Students : IModel
    {
        public int Id { get; set; }

        public string StuName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
    }
}
