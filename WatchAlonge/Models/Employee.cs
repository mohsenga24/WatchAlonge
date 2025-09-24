using System.ComponentModel.DataAnnotations;

namespace WatchAlonge.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string? Department { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
