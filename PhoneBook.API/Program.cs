using FluentValidation.AspNetCore;
using PhoneBook.BLL;
using PhoneBook.BLL.Helpers;
using PhoneBook.BLL.Middlewares;
using PhoneBook.BLL.Validators.ContactDtoValidators;
using PhoneBook.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Web;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    //builder.Environment.WebRootPath = builder.Configuration.GetSection("FileSettings").GetSection("FilePath").Value;

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddCors();
    builder.Services.AddHttpContextAccessor();

    // Add services to the container.
    builder.Services.AddDbContext(builder.Configuration);

    builder.Services.RegisterServices(builder.Configuration);

    builder.Services.AddControllers();
    //builder.Services.AddControllers(options =>
    //{
    //    options.Filters.Add(typeof(ModelStateFeatureFilter));
    //}).AddNewtonsoftJson(options =>
    //{
    //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    //    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    //}).AddFluentValidation(options =>
    //{
    //    options.RegisterValidatorsFromAssembly(typeof(CreateContactDtoValidator).Assembly);
    //});

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //builder.Services.AddSwaggerGen(options =>
    //{
    //    options.SwaggerDoc("v1", new OpenApiInfo
    //    {
    //        Version = "v1",
    //        Title = "PhoneBook API",
    //        Description = "An ASP.NET Core Web API for managing PhoneBook items",
    //        TermsOfService = new Uri("https://example.com/terms")
    //    });

    //    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    //});

    var app = builder.Build();

    await app.DatabaseMigrate();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(x =>
    {
        x.SetIsOriginAllowed(_ => true);
        x.AllowAnyMethod();
        x.AllowAnyHeader();
        x.AllowCredentials();
        x.WithExposedHeaders("Content-Disposition");
    });

    app.UseStaticFiles(new StaticFileOptions()
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type");
        }
    });

    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseRouting();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}