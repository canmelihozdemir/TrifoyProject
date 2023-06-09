﻿using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using TrifoyProject.Core.DTOs;
using TrifoyProject.Service.Exceptions;

namespace TrifoyProject.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config=>
            {
                config.Run(async context=>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature?.Error switch
                    {
                        ClientSideException=>400,
                        NotFoundException => 404,
                        _=>500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDTO<NoContentDTO>.Fail(statusCode,exceptionFeature!.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
