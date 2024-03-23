using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeroHunger.Models.EF
{
    public class Food
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public DateTime ExpireTime { get; set; }


        public DateTime? CompleteTime { get; set; }

        [Required]
        public string Amount { get; set; }

        [Required]
        [ForeignKey("Status")]
        public string StatusName { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Employee")]
        public Guid? AssignedTo { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}