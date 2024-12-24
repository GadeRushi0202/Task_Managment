using Task_Management.Models;

namespace Task_Management.Services
{
    public interface ITaskManagementServices
    {
        int AddTask(TaskManagement taskManagement); // Adds a new task and returns its ID.

        IEnumerable<TaskManagement> GetAllTasks(); // Retrieves all tasks.

        int DeleteTask(int id); // Deletes a task by ID and returns the number of affected rows.

        TaskManagement GetTaskById(int id); // Retrieves a specific task by its ID.

        int UpdateTask(TaskManagement taskManagement); // Updates an existing task and returns the number of affected rows.

        int MarkTaskAsComplete(int id);
        public int MarkTaskAsPending(int id);
    }
}
