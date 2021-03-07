using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SiteMercado.Teste.WebApp.Extensions
{
    public static class AppExtensions
    {
        public static void UseGlobalExceptionExtension(this IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (exceptionHandlerFeature != null)
                        {
                            var exception = exceptionHandlerFeature.Error;

                            var logger = loggerFactory.CreateLogger("GlobalException");
                            logger.LogError($"Erro não esperado: {exception}");

                            context.Response.Redirect("/Error/InternalServerError");
                        }

                        return System.Threading.Tasks.Task.CompletedTask;
                    });
                });
            }
        }

        public static void UseGlobalPageExtension(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                {
                    string originalUrl = $"{context.Request.Host.Value}{context.Request.Path.Value}";
                    context.Items[nameof(originalUrl)] = originalUrl;
                    context.Request.Path = "/Error/PageNotFound";

                    await next();
                }
            });
        }
    }
}
