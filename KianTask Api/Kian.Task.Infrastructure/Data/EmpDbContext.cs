
using Kian.task.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kian.Task.Infrastructure.Data
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) :base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }
    }
}
