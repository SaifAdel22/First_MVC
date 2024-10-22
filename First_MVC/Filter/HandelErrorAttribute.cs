using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace First_MVC.Filter
{
    public class HandelErrorAttribute : Attribute , IExceptionFilter 
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = ("Error");
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Some Exception From HandleErrorattribute";
            context.Result = viewResult ;
        }
    }
}
 