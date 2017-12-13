using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsError.Lib
{
    public class ValidatedClass
    {
        [EmailAddress]
        public string Email { get; set; }

        public bool Validate()
        {
            var results = new List<ValidationResult>();
            return Validator.TryValidateProperty(Email,
                new ValidationContext(this, null, null) { MemberName = nameof(Email) }, results);
        }
    }
}
