using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.EF
{
    public class Status
    {
        [Key]
        public string Name { get; set; }
    }
}