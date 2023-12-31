﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface IMyTaskRepository
    {
        Task<List<MyTask>> GetAllTasks();
        Task<MyTask> GetTaskById(int id);
        Task<MyTask> CreateTask(MyTask myTask);
        Task<int> UpdateTask(int id, MyTask myTask);

        Task<int> DeleteTask(int id);
    }
}
