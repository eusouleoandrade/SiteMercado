using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SiteMercado.Teste.Domain.Exceptions;

namespace SiteMercado.Teste.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SiteMercado - API de Teste");
                c.RoutePrefix = string.Empty;
            });
        }

        public static void UseProblemDetailsExtension(this IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;

                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };

                        if (env.IsDevelopment())
                        {
                            problemDetails.Title = exception.Message;
                            problemDetails.Detail = exception.ToString();

                            if (exception is AppException appException1)
                            {
                                problemDetails.Status = StatusCodes.Status400BadRequest;
                                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                            }
                            else
                            {
                                problemDetails.Status = StatusCodes.Status500InternalServerError;
                                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
                            }
                        }
                        else
                        {
                            if (exception is AppException appException)
                            {
                                problemDetails.Title = "Exceção de Aplicação";
                                problemDetails.Status = StatusCodes.Status400BadRequest;
                                problemDetails.Detail = appException.Message;
                                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                            }
                            else
                            {
                                var logger = loggerFactory.CreateLogger("GlobalException");
                                logger.LogError($"Erro não esperado: {exception}");

                                problemDetails.Title = "Api indisponível";
                                problemDetails.Status = StatusCodes.Status500InternalServerError;
                                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
                                problemDetails.Detail = string.Empty;
                            }
                        }

                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";

                        var jsonProblemDetails = JsonConvert.SerializeObject(problemDetails);
                        await context.Response.WriteAsync(jsonProblemDetails);
                    }
                });
            });
        }
    }
}