using Kian.task.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kian.task.Core.Interfaces;
using Kian.task.Core.Specifications;


namespace Kian.Task.Infrastructure.Data
{
    public class GenericRebository<T> : IGenericRebository<T> where T : class
    {
        private readonly EmpDbContext _empDbContext;

        public GenericRebository(EmpDbContext empDbContext)
        {
            _empDbContext = empDbContext;
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _empDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _empDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_empDbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
