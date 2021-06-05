using Microsoft.EntityFrameworkCore;
using PerfectChannel.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Services
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TodoTaskContext _context;

        public TodoTaskRepository(TodoTaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasksAsync() => await _context.TodoTask.ToListAsync();

        public async Task<TodoTask> GetTaskByIdAsync(int id) => await _context.TodoTask.FindAsync(id);

        public async Task<TodoTask> PostTaskAsync(TodoTask task)
        {
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();

            return await GetTaskByIdAsync(task.Id);
        }

        public async Task<TodoTask> PutTaskAsync(TodoTask task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return task;
            
        }
    }
}
