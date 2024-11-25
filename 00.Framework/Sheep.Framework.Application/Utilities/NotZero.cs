using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace Sheep.Framework.Application.Utilities
{
    public class NotZero : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object value)
        {
          
            if (Convert.ToInt32(value)==0) return false;
           return true;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-ZeroNotAllow", ErrorMessage);
        }
    }
}
