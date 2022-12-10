using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class Books 
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Category { get; set; }
    }
}
