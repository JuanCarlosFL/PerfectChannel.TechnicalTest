using PerfectChannel.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Services
{
    public interface ITodoTaskRepository
    {
        Task<IEnumerable<TodoTask>> GetAllTasksAsync();

        Task<TodoTask> GetTaskByIdAsync(int id);

        Task<TodoTask> PostTaskAsync(TodoTask task);
    }
}
