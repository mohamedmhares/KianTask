using Kian.task.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kian.task.Core.Specifications
{
    public class EmployeeWithSpecifications : BaseSpecification<Employee>
    {
        public EmployeeWithSpecifications(EmployeeSpecParams employeeSpecParams)
            : base(
                  x => (string.IsNullOrEmpty(employeeSpecParams.Search) || x.UserName.ToLower().Contains(employeeSpecParams.Search))&&
                       (string.IsNullOrEmpty(employeeSpecParams.Search) || x.FirstName.ToLower().Contains(employeeSpecParams.Search))&&
                       (string.IsNullOrEmpty(employeeSpecParams.Search) || x.LastName.ToLower().Contains(employeeSpecParams.Search))
                  )
        {
            AddOrderBy(x => x.UserName);
            ApplyPagging(employeeSpecParams.PageSize * (employeeSpecParams.PageIndex - 1), employeeSpecParams.PageSize);


        }
    }
}
