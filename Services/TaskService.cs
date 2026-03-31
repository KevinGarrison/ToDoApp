using ToDoApp.DTOs;
using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;
    public TaskService(AppDbContext context) => _context = context;

    public IEnumerable<TaskDto> GetTasks() =>
        _context.Tasks
            .OrderBy(t => t.IsCompleted)
            .ThenBy(t => t.Id)
            .Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            })
            .ToList();

    public void AddTask(string title)
    {
        _context.Tasks.Add(new TaskItem
        {
            Title = title,
            IsCompleted = false
        });

        _context.SaveChanges();
    }

    public bool ToggleTask(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
        {
            return false;
        }

        task.IsCompleted = !task.IsCompleted;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteTask(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
        {
            return false;
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return true;
    }
}