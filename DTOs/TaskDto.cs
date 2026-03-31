namespace ToDoApp.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}