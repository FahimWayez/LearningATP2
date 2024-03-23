using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeroHunger.Models.EF
{
    public class Restaurant
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public User User { get; set; }

        [Required]
        public string Name { get; set; }
    }
}