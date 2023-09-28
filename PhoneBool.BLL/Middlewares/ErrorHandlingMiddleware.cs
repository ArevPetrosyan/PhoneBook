using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhoneBook.BLL.Middlewares;
public class ErrorHandlingMiddleware
{
    public readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, logger);
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
    {
        context.Response.ContentType = "application/json";
        Result responseResult;

        if (ex is DbUpdateException dbExceptin && dbExceptin.InnerException is Npgsql.PostgresException inEx && inEx.SqlState == "23505")
        {
            //23505 unique key violates exception
            responseResult = Result.Error("Entered incorrect Data");

            logger.LogError(ex, "ErrorHandlingMiddleware Db_Error");
        }
        else if (ex is DbUpdateException)
        {
            responseResult = Result.Error("Oops! Something went wrong");
            logger.LogError(ex, "ErrorHandlingMiddleware Db_Error");
        }
        else
        {
            responseResult = Result.Error("Oops! Something went wrong");
            logger.LogError(ex, "ErrorHandlingMiddleware");
        }

        context.Response.StatusCode = 500;

        var result = JsonSerializer.Serialize(responseResult, new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(result);
    }
}