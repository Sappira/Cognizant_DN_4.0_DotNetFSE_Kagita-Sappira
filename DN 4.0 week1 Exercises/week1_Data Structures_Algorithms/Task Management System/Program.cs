using System;

// Task class
public class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string Status { get; set; }
}

// Node for singly linked list
public class TaskNode
{
    public Task Data { get; set; }
    public TaskNode Next { get; set; }

    public TaskNode(Task task)
    {
        Data = task;
        Next = null;
    }
}

// Singly Linked List for tasks
public class TaskList
{
    private TaskNode head;

    public void AddTask(Task task)
    {
        TaskNode newNode = new TaskNode(task);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            TaskNode current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }
        Console.WriteLine("Task added.");
    }

    public Task SearchTask(int taskId)
    {
        TaskNode current = head;
        while (current != null)
        {
            if (current.Data.TaskId == taskId)
                return current.Data;
            current = current.Next;
        }
        return null;
    }

    public void DeleteTask(int taskId)
    {
        if (head == null) return;

        if (head.Data.TaskId == taskId)
        {
            head = head.Next;
            Console.WriteLine("Task deleted.");
            return;
        }

        TaskNode current = head;
        while (current.Next != null && current.Next.Data.TaskId != taskId)
            current = current.Next;

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void Traverse()
    {
        Console.WriteLine("\nTask List:");
        TaskNode current = head;
        while (current != null)
        {
            var t = current.Data;
            Console.WriteLine($"ID: {t.TaskId}, Name: {t.TaskName}, Status: {t.Status}");
            current = current.Next;
        }
    }
}

public class Program
{
    public static void Main()
    {
        TaskList taskList = new TaskList();

        taskList.AddTask(new Task { TaskId = 1, TaskName = "Design DB", Status = "Pending" });
        taskList.AddTask(new Task { TaskId = 2, TaskName = "Build API", Status = "In Progress" });

        taskList.Traverse();

        var found = taskList.SearchTask(2);
        Console.WriteLine("\nSearch Result: " + (found != null ? found.TaskName : "Not found"));

        taskList.DeleteTask(1);
        taskList.Traverse();
    }
} 