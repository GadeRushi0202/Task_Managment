using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management.Models
{
    [Table("Task_Management")]
    public class TaskManagement
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
