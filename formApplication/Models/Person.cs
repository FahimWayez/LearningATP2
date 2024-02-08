using FormSubmission.Annotation;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{

    public class Person
    {
        [Required(ErrorMessage = "Please provide name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must contain only alphabets and spaces")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a username")]
        [RegularExpression(@"^[a-zA-Z0-9!@#$%^&*()]*$", ErrorMessage = "Username must contain only alphanumeric characters and special characters")]
        [StringLength(10, ErrorMessage = "Username must be maximum 10 characters")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select a profession")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Please provide a valid ID")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must be in the format xx-xxxxx-x")]
        public string Id { get; set; }

        [MatchingIdAndEmail(ErrorMessage = "ID and Email prefixes must match.")]
        [Required(ErrorMessage = "Please provide an email")]
        [RegularExpression(@"^\d{2}-\d{5}-\d@student.aiub.edu$", ErrorMessage = "Email must be in the format xx-xxxxx-x@student.aiub.edu")]
        public string Email { get; set; }

        public string[] Hobbies { get; set; }
    }
}
