using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Buber.API.Filters;

public class ErrorHandlingAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails{
            Title = "An error has occured processing your request and handled by ExceptionAttribute filter",
            Status = (int)HttpStatusCode.InternalServerError,

        };
        
        context.Result = new ObjectResult(problemDetails);

        // context.Result = new ObjectResult(new {Message = "An error has occured processing your request and handled by ExceptionAttribute filter"})  // default approach for exception attribute
        // {
        //     StatusCode = 500 
        // };
        context.ExceptionHandled = true;

    }
}