using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;

public class TaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public List<TaskItem> GetTasks()
    {
        return _context.Tasks.ToList();
    }

    public TaskItem? GetTask(int id)
    {
        return _context.Tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem CreateTask(TaskItem taskItem)
    {
        _context.Tasks.Add(taskItem);
        _context.SaveChanges();
        return taskItem;
    }

    public TaskItem? UpdateTask(int id, TaskItem updatedTask)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return null;

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;

        _context.SaveChanges();
        return task;
    }

    public bool DeleteTask(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return true;
    }
}