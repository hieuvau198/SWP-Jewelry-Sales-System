﻿using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
{
    public class Jewel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
