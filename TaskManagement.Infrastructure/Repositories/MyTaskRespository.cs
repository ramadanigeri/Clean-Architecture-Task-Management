using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class MyTaskRespository : IMyTaskRepository
    {
        private readonly MyTaskDbContext _taskDbContext;

        public MyTaskRespository(MyTaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public async Task<MyTask> CreateTask(MyTask myTask)
        {
            await _taskDbContext.MyTasks.AddAsync(myTask);
            await _taskDbContext.SaveChangesAsync();
            return myTask;
        }

        public async Task<int> DeleteTask(int id)
        {
            return await _taskDbContext.MyTasks
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<MyTask>> GetAllTasks()
        {
            return await _taskDbContext.MyTasks.ToListAsync();
        }

        public async Task<MyTask> GetTaskById(int id)
        {
            return await _taskDbContext.MyTasks.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateTask(int id, MyTask myTask)
        {
            return await _taskDbContext.MyTasks
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, myTask.Id)
                    .SetProperty(m => m.Name, myTask.Name)
                    .SetProperty(m => m.Description, myTask.Description)
                    .SetProperty(m => m.Category, myTask.Category)
                    .SetProperty(m => m.CreatedBy, myTask.CreatedBy)
                    .SetProperty(m => m.CreatedAt, myTask.CreatedAt)
        );
        }
    }
}
