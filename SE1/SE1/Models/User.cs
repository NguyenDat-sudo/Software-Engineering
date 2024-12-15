using System.ComponentModel.DataAnnotations;

namespace SE1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        public long Phone { get; set; }

    }
}
