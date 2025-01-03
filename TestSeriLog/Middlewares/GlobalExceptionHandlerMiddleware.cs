using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using TestSeriLog.Exceptions;

namespace TestSeriLog.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (APIException ex)
            {

                _logger.LogError($"Error: {ex.Message}");
                
                //Set up the response status code 
                context.Response.StatusCode = ex.StatusCode;
                //Set up the response type to Json
                context.Response.ContentType = "application/json";
                //create new object {statusCode, Message, List<ErrorMessage>}
                var finalResponse = new { ex.StatusCode, ex.Message, ex.Data };
                //Create API Exception and serialize to Json 
                var result = JsonConvert.SerializeObject(finalResponse);
                //Write error json to response body 
                await context.Response.WriteAsync(result);

            }
            catch (Exception ex)
            {

                _logger.LogError($"An Unhadled exception : {ex}");
                //Set up the response status code 
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //Set up the response type to Json
                context.Response.ContentType = "application/json";
                //Create API Exception and serialize to Json 
                var exception = ex.Message;
                //Write error json to response body
                await context.Response.WriteAsync(exception);
            }
        }
    }
}