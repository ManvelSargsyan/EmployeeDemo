using Employee.Entities;
using Employee.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Services
{
    public interface IEmployeeService : IBaseService
    {
        Task<IEnumerable<EmployeeServiceModel>> WhereAsync(Expression<Func<EmployeeEntity, bool>> predicate, CancellationToken cancellation = default);
        Task<EmployeeServiceModel> CreateAsync(EmployeeServiceModel model, CancellationToken cancellation = default);
        Task<EmployeeServiceModel> UpdateAsync(EmployeeServiceModel model, CancellationToken cancellation = default);
        Task<IEnumerable<EmployeeServiceModel>> GetAllAsync(CancellationToken cancellation = default);
        Task<EmployeeServiceModel> GetByIdAsync(int id, CancellationToken cancellation = default);
        Task<bool> DeleteAsync(int employeeId, CancellationToken cancellation = default);
    }
}
