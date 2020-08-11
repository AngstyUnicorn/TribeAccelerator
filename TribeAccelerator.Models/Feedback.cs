using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TribeAccelerator.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Max 50 characters allowed")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
