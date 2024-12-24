using Task_Management.Models;
using Task_Management.Repositry;

namespace Task_Management.Services
{
    public class TaskManagementServices : ITaskManagementServices
    {
        private readonly ITaskManagementRepo repo;
        public TaskManagementServices(ITaskManagementRepo repo)
        {
            this.repo = repo;
        }
        public int AddTask(TaskManagement taskManagement)
        {
            return repo.AddTask(taskManagement);
        }

        public int DeleteTask(int id)
        {
            return repo.DeleteTask(id);
        }

        public IEnumerable<TaskManagement> GetAllTasks()
        {
            return repo.GetAllTasks();
        }

        public TaskManagement GetTaskById(int id)
        {
            return repo.GetTaskById(id);
        }

        public int MarkTaskAsComplete(int id)
        {
            return repo.MarkTaskAsComplete(id);
        }

        public int MarkTaskAsPending(int id)
        {
            return repo.MarkTaskAsPending(id);
        }

        public int UpdateTask(TaskManagement taskManagement)
        {
            return repo.UpdateTask(taskManagement);
        }
    }
}
