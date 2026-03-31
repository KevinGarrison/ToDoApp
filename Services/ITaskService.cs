using ToDoApp.DTOs;
using ToDoApp.Models;

namespace ToDoApp.Services;

public interface ITaskService
{
    IEnumerable<TaskDto> GetTasks();
    void AddTask(string title);
    bool ToggleTask(int id);
    bool DeleteTask(int id);
}