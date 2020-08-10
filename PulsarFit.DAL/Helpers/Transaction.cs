using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using PulsarFit.DAL.EF;
using System.Threading.Tasks;
using System;

namespace PulsarFit.DAL.Helpers
{
    public class Transaction : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var dbContext = context.HttpContext.RequestServices.GetRequiredService<DatabaseContext>();

            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                var result = await next();

                if (result.Exception != null)
                    transaction.Rollback();
                else
                    transaction.Commit();
            }
        }
    }
}
