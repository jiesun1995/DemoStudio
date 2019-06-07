using GlobalException.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GlobalException.Infrastructure.Filters
{
    public class PointGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<PointGlobalExceptionFilter> _logger;

        public PointGlobalExceptionFilter(IHostingEnvironment environment, ILogger<PointGlobalExceptionFilter> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception.GetType() == typeof(PointException))
            {
                context.Result = new JsonResult(new
                {
                    code = 1,
                    message = context.Exception.Message,
                });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    code = 1,
                    message = "操作失败"
                });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            context.ExceptionHandled = true;
        }
    }
}
