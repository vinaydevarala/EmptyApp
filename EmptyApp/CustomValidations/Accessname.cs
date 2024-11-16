using System.ComponentModel.DataAnnotations;
namespace EmptyApp.CustomValidations
{
    public class Accessname:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value.Equals("Vinay"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Enetered Name Is Not Access Name Please Enter valid Name");
            }
        }
    }
}
