using System.ComponentModel.DataAnnotations;

namespace WatchAlonge.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string ? category { get; set; }



    }
}
