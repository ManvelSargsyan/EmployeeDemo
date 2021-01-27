using AutoMapper;
using Employee.DataAccess;
using Employee.DataAccess.Enums;
using Employee.Entities;
using Employee.ServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IMapper _mapper;
        public EmployeeService
            (
                EmployeeDbContext employeeDbContext,
                IMapper mapper
            ) : base(employeeDbContext)
        {
            _mapper = mapper;
        }

        public async Task<EmployeeServiceModel> CreateAsync(EmployeeServiceModel model, CancellationToken cancellation = default)
        {
            try
            {
                var entity = _mapper.Map<EmployeeEntity>(model);

                await employeeDbContext.Employees.AddAsync(entity);

                await SaveChangesAsync(entity, DataAccess.Enums.EntityState.Create);

                return _mapper.Map<EmployeeServiceModel>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int employeeId, CancellationToken cancellation = default)
        {
            try
            {
                var entity = await employeeDbContext.Employees.SingleOrDefaultAsync(x => x.Id == employeeId);

                return await SaveChangesAsync(entity, DataAccess.Enums.EntityState.Delete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<EmployeeServiceModel>> GetAllAsync(CancellationToken cancellation = default)
        {
            var employees = await employeeDbContext.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeServiceModel>>(employees);
        }

        public async Task<EmployeeServiceModel> GetByIdAsync(int id, CancellationToken cancellation = default)
        {
            var employee = await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<EmployeeServiceModel>(employee);
        }

        public async Task<EmployeeServiceModel> UpdateAsync(EmployeeServiceModel model, CancellationToken cancellation = default)
        {
            try
            {
                var employee = await employeeDbContext.Employees.SingleOrDefaultAsync(item => item.Id == model.Id);

                _mapper.Map<EmployeeServiceModel, EmployeeEntity>(model, employee);

                await SaveChangesAsync(employee, DataAccess.Enums.EntityState.Upadet);

                return _mapper.Map<EmployeeServiceModel>(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<EmployeeServiceModel>> WhereAsync(Expression<Func<EmployeeEntity, bool>> predicate, CancellationToken cancellation = default)
        {
            var employees = await employeeDbContext.Employees.Where(predicate).ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeServiceModel>>(employees);
        }
    }
}
