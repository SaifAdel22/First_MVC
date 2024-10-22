using Microsoft.AspNetCore.Mvc.Filters;

namespace First_MVC.Filter
{
    public class MyCustomAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           // throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.
        }
    }
}
