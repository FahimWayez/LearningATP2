using FormSubmission.Models;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Annotation
{
    //[AttributeUsage(AttributeTargets.Class)]
    public class MatchingIdAndEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;

            if (person.Id != null && person.Email != null)
            {
                var idPrefix = person.Id.Substring(0, 10);
                var emailPrefix = person.Email.Substring(0, 10);

                if (idPrefix != emailPrefix)
                {
                    return new ValidationResult("ID and Email prefixes must match.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
