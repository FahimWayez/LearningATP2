using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.EF
{
    public class Access
    {
        [Key]
        public string Name { get; set; }
    }
}