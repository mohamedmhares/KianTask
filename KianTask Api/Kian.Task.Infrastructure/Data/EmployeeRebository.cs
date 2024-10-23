using Kian.task.Core.Entities;
using Kian.task.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Kian.Task.Infrastructure.Data;


namespace KianTask.Infrastructure.Data
{
    public class EmployeeRebository : IEmployeeRebository
    {
        private readonly EmpDbContext _empDbContext;

        public EmployeeRebository(EmpDbContext empDbContext)
        {
            _empDbContext = empDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _empDbContext.employees.AddAsync(employee);
            await _empDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
             _empDbContext.employees.Remove(employee);
            await _empDbContext.SaveChangesAsync();

        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _empDbContext.employees.FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeesAsync()
        {
            return await _empDbContext.employees.ToListAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
                   _empDbContext.Update(employee);
            await  _empDbContext.SaveChangesAsync();
        }
    }
}
