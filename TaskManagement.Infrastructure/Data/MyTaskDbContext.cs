using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    public class MyTaskDbContext : DbContext
    {
        public MyTaskDbContext(DbContextOptions<MyTaskDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<MyTask> MyTasks { get; set;}
    }
}
