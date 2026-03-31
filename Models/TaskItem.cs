namespace ToDoApp.Models;

public class TaskItem {
    public int Id { get; private set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
    
}