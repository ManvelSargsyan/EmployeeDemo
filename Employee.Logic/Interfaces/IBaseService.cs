using Employee.DataAccess.Enums;
using Employee.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Services
{
    public interface IBaseService : IDisposable
    {
        Task<bool> SaveChangesAsync(EntityBase entityBase, EntityState modification, CancellationToken cancellation);
    }
}
