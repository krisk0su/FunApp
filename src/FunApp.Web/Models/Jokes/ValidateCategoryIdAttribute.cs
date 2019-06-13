using System.ComponentModel.DataAnnotations;
using FunApp.Services.DataServices;

namespace FunApp.Web.Models.Jokes
{
    public class ValidateCategoryIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (ICategoryService) validationContext
                .GetService(typeof(ICategoryService));


            if (service.IsCategoryIdValid((int) value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid category ID!");
            }
        }
    }
}