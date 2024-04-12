using System;
using System.Web.Mvc;
using TestProject.Utils;

namespace TestProject.Filters
{
    // Создание фильтра исключений
    public class HandleExceptionsAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var ex = filterContext.Exception;
                Logger.LogException(ex);  // Логирование исключения

                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}