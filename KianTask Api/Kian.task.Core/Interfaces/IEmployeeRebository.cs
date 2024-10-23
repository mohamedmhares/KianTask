using Kian.task.Core.Entities;

namespace Kian.task.Core.Interfaces
{
    public interface IEmployeeRebository
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IReadOnlyList<Employee>> GetEmployeesAsync();
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);

    }
}
