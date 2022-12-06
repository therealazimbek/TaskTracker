using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TaskTracker.Models.Attributes;

namespace TaskTracker.Models;

public class Project
{
    [Key, Required]
    public int Id { get; set; }
    [Required, StringLength(40)]
    [ProjectNameUnique(nameof(Id))]
    public string Name { get; set; } = string.Empty;
    [CheckDateRange]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [CheckDateRange]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    [ValidEnum]
    public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
    public int Priority { get; set; }
    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}