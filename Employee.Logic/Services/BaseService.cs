using Employee.DataAccess;
using Employee.DataAccess.Enums;
using Employee.Entities;
using Employee.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Services
{
    public class BaseService : IBaseService
    {
        protected EmployeeDbContext employeeDbContext { get; set; }

        private bool _disposedValue;

        public BaseService(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public async Task<bool> SaveChangesAsync(EntityBase entityBase, EntityState modification, CancellationToken cancellation = default)
        {
            switch (modification)
            {
                case EntityState.Create:
                    entityBase.CreateDate = DateTime.UtcNow;
                    break;
                case EntityState.Upadet:
                    entityBase.UpdateDate = DateTime.UtcNow;
                    break;
                case EntityState.Delete:
                    entityBase.Deleted = true;
                    entityBase.UpdateDate = DateTime.UtcNow;
                    break;
            }

            return await employeeDbContext.SaveChangesAsync(cancellation) > 0;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    employeeDbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
