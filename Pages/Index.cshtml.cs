using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.DTOs;
using ToDoApp.Services;

namespace ToDoApp.Pages;

public class IndexModel : PageModel
{
    private readonly ITaskService _taskService;

    public IndexModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IEnumerable<TaskDto> Tasks { get; private set; } = [];

    [BindProperty]
    public string NewTaskTitle { get; set; } = string.Empty;

    public void OnGet()
    {
        LoadTasks();
    }

    public IActionResult OnPostAdd()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
        {
            LoadTasks();
            ModelState.AddModelError(nameof(NewTaskTitle), "Task title is required.");
            return Page();
        }

        _taskService.AddTask(NewTaskTitle.Trim());
        return RedirectToPage();
    }

    public IActionResult OnPostToggle(int id)
    {
        _taskService.ToggleTask(id);
        return RedirectToPage();
    }

    public IActionResult OnPostDelete(int id)
    {
        _taskService.DeleteTask(id);
        return RedirectToPage();
    }

    private void LoadTasks()
    {
        Tasks = _taskService.GetTasks();

    }
}
