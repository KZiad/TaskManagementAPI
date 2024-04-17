
using Task_Management.Models;

namespace Task_Management.Services
{
    public interface ITaskService
    {
        TaskItem CreateTask(CreateTaskRequest task);
        TaskItem? GetTask(int id);
        List<TaskItem> GetAllTasks(StatusEnum? status, int? year, int? month, int? day);
        TaskItem? UpdateTask(int Id,  UpdateTaskRequest task);
        bool DeleteTask(int Id);
    }
}
