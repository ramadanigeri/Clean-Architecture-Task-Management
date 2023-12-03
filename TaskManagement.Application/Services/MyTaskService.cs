using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class MyTaskService : IMyTaskService
    {
        private readonly IMyTaskRepository _myTaskRepository;

        public MyTaskService(IMyTaskRepository myTaskRepository)
        {
            _myTaskRepository = myTaskRepository;
        }
        public async Task<MyTask> CreateTask(MyTask myTask)
        {
            return await _myTaskRepository.CreateTask(myTask);
        }

        async Task<int?> IMyTaskService.DeleteTask(int id)
        {
            return await _myTaskRepository.DeleteTask(id);
        }

        public async Task<List<MyTask>> GetAllTasks()
        {
            return await _myTaskRepository.GetAllTasks();
        }

        public async Task<MyTask> GetTaskById(int id)
        {
            return await _myTaskRepository.GetTaskById(id);
        }

        public async Task<int> UpdateTask(int id, MyTask myTask)
        {
            return await _myTaskRepository.UpdateTask(id, myTask);
        }


    }
}
