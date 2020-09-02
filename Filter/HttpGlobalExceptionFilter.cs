using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorService.Filter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment env;
        public HttpGlobalExceptionFilter(IHostEnvironment env)
        {
            this.env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (this.env.IsDevelopment())
            {
            }
        }
    }
}
