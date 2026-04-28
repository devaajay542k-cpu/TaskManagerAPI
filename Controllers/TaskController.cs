using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase 
{
    public static List<TaskItem> TaskItems = new List<TaskItem>();

    [HttpGet("/gettasks")]
    public ActionResult<List<TaskItem>> GetTasks()
    {
        return TaskItems;
    }

    [HttpPost("/createtask")]
    public ActionResult<TaskItem> CreateTask(TaskItem task)
    {
        task.Id = TaskItems.Count + 1;
        TaskItems.Add(task);
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

}