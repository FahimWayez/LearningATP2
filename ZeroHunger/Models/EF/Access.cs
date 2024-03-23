using System.ComponentModel.DataAnnotations;

namespace Zero_Hunger.Models.EF
{
    public class Access
    {
        [Key]
        public string Name { get; set; }
    }
}