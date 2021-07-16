using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSite.Services.Abstractions;

namespace WebSite.Middlewares
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRateLimitService _rateLimitService;
        public RateLimitMiddleware(RequestDelegate next, IRateLimitService rateLimitService)
        {
            _next = next;
            _rateLimitService = rateLimitService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress;
            var url = context.Request.Path.ToUriComponent();

            var result = await _rateLimitService.CheckRateLimit($"{ip}{url}");

            if (result.CheckRateLimit)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 429;
                await context.Response.WriteAsync("429 Too many request. Ohladite vashe");
            }
        }
    }
}