using mvcDay2.Models;
using mvcDay2.viewmodel;
using System.ComponentModel.DataAnnotations;

namespace mvcDay2.servervalidation
{
    public class uniqnameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            employeevaild employee = (employeevaild) validationContext.ObjectInstance;
            banhacontext context = new banhacontext();

            var count = context.employees.Where(e=>e.fname == value.ToString()  && e.Dno == employee.Dno).ToList();
            if(count.Count > 0 ) {

                return new ValidationResult("error");
            
            }

            return ValidationResult.Success;
        }
    }
}
