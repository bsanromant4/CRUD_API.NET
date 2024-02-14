using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Net;
using System.Text.Json;

namespace RestAPI_Maxxi.Middleware
{
    public static class UseExceptionHandler
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (errorFeature != null)
                {
                    var exception = errorFeature.Error;

                    var errorResponse = new
                    {
                        error = "Se ha producido un error interno en el servidor.",
                        message = exception.Message
                    };

                    var jsonResponse = JsonSerializer.Serialize(errorResponse);

                    await context.Response.WriteAsync(jsonResponse);
                }
            });
        });

            app.UseRouting();
        }
    }
}
