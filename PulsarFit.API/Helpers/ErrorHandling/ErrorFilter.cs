using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace PulsarFit.API.Helpers.ErrorHandling
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ModelState.AddModelError("ERROR", context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var list = context.ModelState.Where(x => x.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors.Select(z => z.ErrorMessage).ToList()).ToList();

            context.Result = new JsonResult(new
            {
                errors = list
            });

            base.OnException(context);
        }
    }
}
