
using Microsoft.VisualBasic;
using Task_Management.Models;

namespace Task_Management.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _taskList;
        public TaskService()
        {
            _taskList = new List<TaskItem>();
        }

        TaskItem ITaskService.CreateTask(CreateTaskRequest task)
        {
            TaskItem newTask = new TaskItem()
            {
                Id = _taskList.Count + 1,
                TaskDetails = task.TaskDetails,
                DueDate = task.DueDate,
            };

            _taskList.Add(newTask);

            return newTask;
        }

        TaskItem? ITaskService.GetTask(int id)
        {
            return _taskList.FirstOrDefault(task => task.Id == id);
        }

        List<TaskItem> ITaskService.GetAllTasks(StatusEnum? status, int? year, int? month, int? day)
        {
            if (status == null && year == null && month == null && day == null)
            {
                return _taskList;
            }
            List<TaskItem> returnList = _taskList;
            if (status != null)
            {
                returnList = returnList.FindAll(task => task.Status == status);
            }
            if (day != null)
            {
                returnList = returnList.FindAll(task => task.DueDate.Day == day);
            }
            if (month != null)
            {
                returnList = returnList.FindAll(task => task.DueDate.Month == month);
            }
            if (year != null)
            {
                returnList = returnList.FindAll(task => task.DueDate.Year == year);
            }
            return returnList;
        }

        TaskItem? ITaskService.UpdateTask(int Id, UpdateTaskRequest task)
        {
            int taskIndex = _taskList.FindIndex(task => task.Id == Id);
            if (taskIndex >= 0)
            {
                var oldTask = _taskList[taskIndex];

                oldTask.TaskDetails = task.TaskDetails == null ? oldTask.TaskDetails : task.TaskDetails;
                oldTask.Status = (StatusEnum)(task.Status == null ? oldTask.Status : task.Status);
                oldTask.DueDate = (DateTime)(task.DueDate == null ? oldTask.DueDate : task.DueDate);
                oldTask.LastUpdatedAt = DateTime.Now;
                _taskList[taskIndex] = oldTask;

                return oldTask;
            }
            return null;
        }

        bool ITaskService.DeleteTask(int Id)
        {
            int taskIndex = _taskList.FindIndex(task => task.Id == Id);
            if (taskIndex == -1)
            {
                return false;
            }
            _taskList.RemoveAt(taskIndex);
            return true;
        }
    }
}
