using System.ComponentModel.DataAnnotations;

namespace Zero_Hunger.Models.EF
{
    public class Status
    {
        [Key]
        public string Name { get; set; }
    }
}