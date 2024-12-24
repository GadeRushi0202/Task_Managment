using Microsoft.EntityFrameworkCore;
using Task_Management.Models;

namespace Task_Management.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TaskManagement> TaskManagements { get; set; }

    }
}
