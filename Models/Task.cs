using System.ComponentModel.DataAnnotations;
using TaskTracker.Models.Attributes;

namespace TaskTracker.Models;

public class Task
{
    [Key, Required]
    public int Id { get; set; }
    public int ProjectId { get; set; }
    [Required, StringLength(40)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [ValidEnum]
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
    public int Priority { get; set; }
}