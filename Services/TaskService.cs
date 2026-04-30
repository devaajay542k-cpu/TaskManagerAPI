public class TaskService
{
    public static List<TaskItem> TaskItems = new List<TaskItem>();

    public List<TaskItem> GetTasks()
    {
        return TaskItems;
    }

    public TaskItem GetTask(int id)
    {
        TaskItem task=TaskItems.FirstOrDefault(t=>t.Id==id);
        if(task==null) return null;

        return task;
    }

    public TaskItem postTask(TaskItem TaskItem)
    {
        TaskItem.Id=TaskItems.Count+1;
        TaskItems.Add(TaskItem);
        return TaskItem;

    }

    public TaskItem? updateTask(int id,TaskItem TaskItem)
    {
        TaskItem task=TaskItems.FirstOrDefault(t=>t.Id==id);
        if(task==null) return null;

        task.Title=TaskItem.Title;
        task.Description=TaskItem.Description;

        return task;
    }

    public bool delTask(int id)
    {
        var task=TaskItems.FirstOrDefault(t=>t.Id==id);
        if(task==null) return false;

        TaskItems.Remove(task);
        return true;


    }


}