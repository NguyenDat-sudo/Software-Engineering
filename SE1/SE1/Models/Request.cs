using System.ComponentModel.DataAnnotations;

namespace SE1.Models
{
    public class Request
    {
        [Key]
        public int RId { get; set; }
        public DateTime Date { get; set; }
        public int Paper { get; set; }
        public string Document_name { get; set; }
        public DateTime Deliver_date { get; set; }

        
    }
}
