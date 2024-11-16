using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmptyApp.CustomValidations
{
    public class CheckSal:ValidationAttribute
    {
        //these values are injected  by model 
        public CheckSal(string PrevSal,string Expect ) 
        {
            prevSal = PrevSal;
            ExpectSal = Expect;
        }

        public string prevSal { get; set; }
        public string ExpectSal { get; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int CurrentSal =Convert.ToInt32(value);
              //Extracting data from model values through constructor
                PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(prevSal);
                PropertyInfo? propertyInfo1 = validationContext.ObjectType.GetProperty(ExpectSal);

                int PrevSal=Convert.ToInt32( propertyInfo.GetValue(validationContext.ObjectInstance));
                int Expected = Convert.ToInt32(propertyInfo1.GetValue(validationContext.ObjectInstance));
                if (Expected>CurrentSal&& CurrentSal > PrevSal)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                  
                }
            }
            else
            {
                return null;
            }
           
        }
    }
}
