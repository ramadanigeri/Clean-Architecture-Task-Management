using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
namespace TaskManagement.Application.Services
{
    public interface IMyTaskService
    {
        Task<List<MyTask>> GetAllTasks();
        Task<MyTask> GetTaskById(int id);
        Task<MyTask> CreateTask(MyTask task);
        Task<int> UpdateTask(int id, MyTask task);

        Task<int?> DeleteTask(int id);
    }
}
