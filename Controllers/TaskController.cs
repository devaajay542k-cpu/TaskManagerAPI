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
        //return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task); //new stuff...,,
        return Ok(task);

    }

    [HttpPut("/updatetask/{id}")]
    public IActionResult UpdateTask(int id,TaskItem uptask)
    {
        var task=TaskItems.FirstOrDefault(t=>t.Id==id);
        if(task==null) return NotFound();

        task.Title=uptask.Title;
        task.Description=uptask.Description;

        return Ok(task);
        
    }

    [HttpDelete("/deletetask/{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task=TaskItems.FirstOrDefault(t=>t.Id==id);
        if(task==null) return NotFound();

        TaskItems.Remove(task);
        return Ok(TaskItems);
    }

}