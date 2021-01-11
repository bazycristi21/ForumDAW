using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ForumDAW.Models
{
    public class ValidB: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Question q = (Question)validationContext.ObjectInstance;
            bool condition = q.Description.Contains("?");
            return condition ? ValidationResult.Success : new ValidationResult("Descrierea intrebarii trebuia sa contina simbolul ?");
        }
    }
}