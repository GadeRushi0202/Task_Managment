using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Models;
using Task_Management.Services;

namespace Task_Management.Controllers
{
    public class TaskManagementController : Controller
    {
        private readonly ITaskManagementServices services;
        public TaskManagementController(ITaskManagementServices services)
        {
            this.services = services;
        }

        // GET: TaskManagementController
        public ActionResult Index()
        {
            var model = services.GetAllTasks();
            return View(model);
        }

        // GET: TaskManagementController/Details/5
        public ActionResult Details(int id)
        {
            var result = services.GetTaskById(id);
            return View(result);
        }

        // GET: TaskManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskManagement taskManagement)
        {
            try
            {
                int result = services.AddTask(taskManagement);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = services.GetTaskById(id);
            return View(result);
        }

        // POST: TaskManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskManagement taskManagement)
        {
            try
            {
                int result = services.UpdateTask(taskManagement);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();//regenarate main page
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: TaskManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = services.GetTaskById(id);
            return View(result);
        }

        // POST: TaskManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = services.DeleteTask(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    return View();

                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        // GET: Mark a Task as Complete
        public IActionResult MarkComplete(int id)
        {
            var task = services.GetTaskById(id);
            if (task == null)
            {
                return NotFound(); // Return a 404 if the task does not exist
            }
            return View(task); // Pass the task to the view
        }

        // POST: Mark a Task as Complete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkCompleteConfirmed(int id)
        {
            try
            {
                int result = services.MarkTaskAsComplete(id);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index)); // Redirect to the task list after marking as complete
                }
                else
                {
                    ModelState.AddModelError("", "Unable to mark task as complete.");
                    return RedirectToAction(nameof(Index)); // Redirect to the task list even if failed
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index)); // Redirect to task list in case of an exception
            }
        }
        // GET: Mark a Task as Pending
        public IActionResult MarkPending(int id)
        {
            var task = services.GetTaskById(id);
            if (task == null)
            {
                return NotFound(); // Task does not exist
            }
            return View(task); // Pass the task to the view
        }

        // POST: Mark a Task as Pending
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkPendingConfirmed(int id)
        {
            try
            {
                int result = services.MarkTaskAsPending(id);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index)); // Redirect to task list
                }
                else
                {
                    ModelState.AddModelError("", "Unable to mark task as pending.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index)); // Redirect to task list in case of an exception
            }
        }
    }
}
