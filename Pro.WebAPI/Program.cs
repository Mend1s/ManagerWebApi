using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pro.API.Configuration;
using Pro.Data.Context;
using Pro.WebAPI.Configuration;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
//builder.AddSerilog(builder.Configuration, "Sample JsReport");
//Log.Information("Starting API");

builder
    .Services
    .AddControllersWithViews();


builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Pro WebAPI", Version = "v1" });

    //opt.CustomEndpointOperationIds();
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ResolveDependecies();

builder.AddJsReport();

builder.Services.AddCors(options =>
{
    //options.AddDefaultPolicy(builder =>
    //{
    //    builder.WithOrigins("http://localhost:4200") // Permita solicitações do seu frontend Angular
    //           .AllowAnyMethod()
    //           .AllowAnyHeader();
    //});

    options.AddPolicy("Development",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors("Development");
app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
