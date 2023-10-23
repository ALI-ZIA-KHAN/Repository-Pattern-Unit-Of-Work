using CRUDOperationInDotNetCore.Data;
using CRUDOperationInDotNetCore.Data.Repo;
using CRUDOperationInDotNetCore.Interfaces;
using CRUDOperationInDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.



//The code you provided is configuring Entity Framework Core's database context within an ASP.NET Core application. Let's break down what's happening here:
//builder.Services: This line of code is part of the configuration process in an ASP.NET Core application, where builder is typically an instance of WebHostBuilder, HostBuilder, or Host (depending on the application type). It allows you to configure various services and components for your application.

//AddDbContext<BrandContext>: This method configures the application to use the BrandContext as the database context for Entity Framework Core. It tells the application that you want to use this context to interact with your database.

//(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BrandCS")): This is a lambda expression that configures how the BrandContext should connect to the database. Let's break it down further:

//options =>: This part indicates that you're defining options for the database context.

//options.UseSqlServer(...): This is a method call on the options object that specifies the database provider you want to use. In this case, it indicates that you want to use Microsoft SQL Server as the database.

//builder.Configuration.GetConnectionString("BrandCS"): This part retrieves the connection string named "BrandCS" from your application's configuration. The GetConnectionString method fetches the connection string from the configuration, 
builder.Services.AddDbContext<BrandContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BrandCS")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials


app.UseAuthorization();

app.MapControllers();

app.Run();
