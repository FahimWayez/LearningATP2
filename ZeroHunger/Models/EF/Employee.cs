using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.EF
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}