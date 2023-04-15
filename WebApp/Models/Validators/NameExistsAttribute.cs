using System.ComponentModel.DataAnnotations;
using WebApp.Data;
using WebApp.Models;

public class NameExistsAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || validationContext == null) return null;

        if (validationContext.ObjectInstance == null 
                ||
                !(validationContext.ObjectInstance is ManagerModel))
        {
            throw new ArgumentException("NameExistsAttribute contains wrong object");
        }

        var manager =  validationContext.ObjectInstance as ManagerModel;
        var ctx = validationContext.GetService<ApplicationDbContext>();

        if ( ctx.Mangers.Any(s => s.Id != manager.Id && s.Name == value.ToString()))
        {
            return new ValidationResult("Name exists");
        }
        return ValidationResult.Success;
    }
}