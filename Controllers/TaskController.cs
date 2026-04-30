using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase 
{
    private TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }


    [HttpGet("/gettasks")]
    public ActionResult<List<TaskItem>> GetTasks()
    {
        return (_taskService.GetTasks());
    }

    [HttpPost("/createtask")]
    public ActionResult<TaskItem> CreateTask(TaskItem task)
    {
        return(_taskService.postTask(task));

    }

    [HttpPut("/updatetask/{id}")]
    public IActionResult UpdateTask(int id,TaskItem uptask)
    {
        var task=_taskService.updateTask(id,uptask);
        if(task==null) return NotFound();
        return Ok(task);
        
    }

    [HttpDelete("/deletetask/{id}")]
    public IActionResult DeleteTask(int id)
    {
        var sucess=_taskService.delTask(id);
        if(!sucess) return NotFound();

        var tasks=_taskService.GetTasks();

        return Ok(tasks);
    }

}