using System.ComponentModel.DataAnnotations;

namespace Refactoring.Domain
{
    public class MyEntity : IValidatableObject
    {
        public MyEntity(string stringValue)
        {
            StringValue = stringValue;
        }

        public string StringValue { get; set; }

        public void InvalidateThisObject()
        {
            StringValue = null;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(StringValue))
            {
                return new ValidationResult[] { new ValidationResult("You messed up."), };
            }

            return new ValidationResult[] { };
        }
    }
}