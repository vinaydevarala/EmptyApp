using EmptyApp.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace EmptyApp.Models
{
    public class Student
    {
        [Required]
        public int? Id { get; set; }
        [MinLength(10,ErrorMessage ="Required chars should not be lower than 10")]
        public string Name { get; set; }
        [Required]
        //custom validation
        [Accessname]
        public string AccessName { get; set; } = "ravi";
        [Required]
        public int PreviousSal { get; set; }

        [Required]
        [CheckSal("PreviousSal", "expectedSal",ErrorMessage ="Curremt salary must be greaterthan or equal to previous sal")]
        public int CurentSal { get; set; }

        [Required]
     
        public int expectedSal { get; set; }
    }
}
