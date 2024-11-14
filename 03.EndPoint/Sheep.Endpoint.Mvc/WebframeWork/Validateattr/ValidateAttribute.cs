using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Sheep.Endpoint.Mvc.WebframeWork.Validateattr
{
    public class ValidateAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var ctrl = (Controller)context.Controller;

                var view = new ViewResult
                {
                    ViewName = context.RouteData.Values["Action"].ToString(),
                    ViewData = ctrl.ViewData
                };

                context.Result = view;
            }
        }
    }

}
