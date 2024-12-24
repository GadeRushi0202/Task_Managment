using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Task_Management.Data;
using Task_Management.Models;

namespace Task_Management.Repositry
{
    public class TaskManagementRepo : ITaskManagementRepo
    {
        private readonly ApplicationDbContext db;
        public TaskManagementRepo(ApplicationDbContext db) 
        { 
            this.db = db;
        }
        public int AddTask(TaskManagement taskManagement)
        {
            db.TaskManagements.Add(taskManagement); // Adds the new task to the `Tasks` DbSet
            int result = db.SaveChanges(); // Saves changes to the database
            return result; // Returns the number of affected rows
        }

        public int DeleteTask(int id)
        {
            int res = 0;
            var result = db.TaskManagements.Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
            {

                db.TaskManagements.Remove(result);
                res = db.SaveChanges();


            }

            return res;
        }

        public IEnumerable<TaskManagement> GetAllTasks()
        {
            return db.TaskManagements.ToList();
        }

        public TaskManagement GetTaskById(int id)
        {
            var result = db.TaskManagements.Where(db => db.Id == id).SingleOrDefault();

            return result;
        }

        public int UpdateTask(TaskManagement taskManagement)
        {
            int res = 0;
            var result = db.TaskManagements.Where(x => x.Id == taskManagement.Id).FirstOrDefault();
            if (result != null)
            {

                result.Name = taskManagement.Name;
                result.Description = taskManagement.Description;
                result.DueDate = taskManagement.DueDate;
                result.IsCompleted = taskManagement.IsCompleted;
                res = db.SaveChanges();

            }
            return res;
        }

        public int MarkTaskAsComplete(int id)
        {
            var task = db.TaskManagements.FirstOrDefault(x => x.Id == id); // Locate the task
            if (task != null)
            {
                task.IsCompleted = true; // Mark as complete
                return db.SaveChanges(); // Save changes
            }
            return 0; // Return 0 if task not found
        }

        public int MarkTaskAsPending(int id)
        {
            var task = db.TaskManagements.FirstOrDefault(x => x.Id == id); // Locate the task
            if (task != null)
            {
                task.IsCompleted = false; // Mark as pending
                return db.SaveChanges(); // Save changes
            }
            return 0; // Return 0 if task not found
        }

    }
}
