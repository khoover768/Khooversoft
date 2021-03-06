﻿using Khooversoft.Net;
using Khooversoft.Toolbox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Khooversoft.AspMvc
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private IWorkContext _context;

        public GlobalExceptionFilter(IWorkContext context)
        {
            Verify.IsNotNull(nameof(context), context);

            _context = context;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode code = Utility.CalculateStatusCode(context.Exception);

            var errorMessage = new ErrorMessageContractV1
            {
                HttpStatus = (int)code,
                Message = context.Exception.Message,
                ExceptionType = context.Exception.GetType().FullName,
                DetailMessage = context.Exception.StackTrace,
            };

            context.Result = new ObjectResult(errorMessage)
            {
                StatusCode = (int)code,
                DeclaredType = typeof(ErrorMessageContractV1)
            };

            ToolboxEventSource.Log.Error(_context, nameof(GlobalExceptionFilter), context.Exception);
        }
    }
}
