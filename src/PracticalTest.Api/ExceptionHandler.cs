using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PracticalTestApi.Exceptions;
using PracticalTestApi.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PracticalTestApi
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(JsonConvert.SerializeObject(new ErrorDto
            {
                Message = "Internal Server Error",
                Details = new[] { exception.Message },
                StatusCode = (int)HttpStatusCode.InternalServerError
            }));
        }
    }
}
