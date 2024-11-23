using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
    }
}