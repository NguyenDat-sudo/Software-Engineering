﻿using System.ComponentModel.DataAnnotations;

namespace SE1.Models
{
    public class Printer2
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Active { get; set; } //false is unable, true is able
    }
}
