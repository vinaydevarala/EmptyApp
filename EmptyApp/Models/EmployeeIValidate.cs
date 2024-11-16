using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EmptyApp.Models
{
    public class EmployeeIValidate:IValidatableObject
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }=string.Empty;

        //[BindNever]
        public string? Salary { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EmployeeId.HasValue && EmployeeId < Id)
            {
               yield return new ValidationResult("Employee id IS NOT LESS THAN ID", new[] {nameof(EmployeeId) });
            }
            if (Name.Length > 10)
            {
                yield return new ValidationResult("Name Should not Greater than 10 letters");
            }
            if(Id<2)
            {
                yield return new ValidationResult("Id is greater than" +
                    " 2");
            }
        }
    }
}
